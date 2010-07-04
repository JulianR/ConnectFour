using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;
using ConnectFour.SearchStrategies;

namespace ConnectFourConsole
{
  class ConnectFourConsole
  {
    static void Main(string[] args)
    {

      var game = CreateConsoleGame();
      game.Start();
    }

    public static Game CreateConsoleGame()
    {
      var game = new Game(Player.Human)
      {
        Input = new ConsoleInput(),
        SearchStrategy = new Negamax(),
        MoveGenerator = new DynamicMoveOrdering()
      };

      var renderer = new ConsoleInterface();

      game.Invalidated += renderer.Draw;

      return game;
    }
  }
}
