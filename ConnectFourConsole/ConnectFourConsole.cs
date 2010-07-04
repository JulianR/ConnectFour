using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;
using ConnectFour.SearchStrategies;
using ConnectFour;
using System.IO;
using System.Xml.Serialization;

namespace ConnectFourConsole
{
  class ConnectFourConsole
  {
    static void Main(string[] args)
    {
      var game = LoadFromXml();
      game.Start();
    }

    private static Game LoadFromXml()
    {
      var dir = Directory.GetCurrentDirectory();

      var file = Path.Combine(dir, "Options.xml");

      using (var stream = new StreamReader(file))
      {

        XmlSerializer serializer = new XmlSerializer(typeof(Options));
        var options = serializer.Deserialize(stream) as Options;

        if (options == null)
        {
          throw new InvalidOperationException("Invalid XML file");
        }

        var searchStrategy = (from a in AppDomain.CurrentDomain.GetAssemblies()
                              let b = a.GetTypes().FirstOrDefault(t => t.Name == options.SearchStrategy)
                              select b).FirstOrDefault(b => b != null);

        if (searchStrategy == null)
        {
          throw new ArgumentException("Invalid search strategy");
        }

        var moveOrdering = (from a in AppDomain.CurrentDomain.GetAssemblies()
                            let b = a.GetTypes().FirstOrDefault(t => t.Name == options.MoveOrderingStrategy)
                            select b).FirstOrDefault(b => b != null);

        if (moveOrdering == null)
        {
          throw new ArgumentException("Invalid move ordering strategy");
        }

        var searchInstance = Activator.CreateInstance(searchStrategy) as ISearchStrategy;
        var moveInstance = Activator.CreateInstance(moveOrdering) as IMoveOrderStrategy;

        Player[,] state = null;

        if (options.InitialState != "None")
        {
          var method = typeof(InitialBoardState).GetMethod("Get" + options.InitialState);

          if (method == null)
          {
            throw new ArgumentException("Invalid initial state");
          }

          state = method.Invoke(null, null) as Player[,];

        }

        var board = new GameBoard(state);

        var game = new Game(board, Player.Human)
        {
          SearchStrategy = searchInstance,
          MoveGenerator = moveInstance,
          Input = new ConsoleInput(),
          RecursionDepth = options.RecursionDepth
        };

        var renderer = new ConsoleInterface();

        game.Invalidated += renderer.Draw;

        return game;
      }

    }

    public static Game CreateConsoleGame()
    {
      var game = new Game(Player.Human)
      {
        Input = new ConsoleInput(),
        SearchStrategy = new Minimax(),
        MoveGenerator = new DynamicMoveOrdering()
      };

      var renderer = new ConsoleInterface();

      game.Invalidated += renderer.Draw;

      return game;
    }
  }
}
