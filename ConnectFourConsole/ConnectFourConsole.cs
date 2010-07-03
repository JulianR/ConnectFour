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

    private static GameBoard Test()
    {
      var state = new Player[7, 6];

      for (int i = 0; i < 7; i++)
      {
        for (int j = 0; j < 6; j++)
        {
          state[i, j] = Player.None;
        }
      }

      for (int i = 0; i < 3; i++)
      {
        state[i, 5] = Player.AI;
      }

      var board = new GameBoard(state);

      var game = new Game(board, Player.AI);

      var generator = new DynamicMoveOrdering();

      generator.GetMovesForTurn(game);

      return board;
    }

    public static Game CreateConsoleGame()
    {
      var game = new Game(Player.Human)
      {
        Input = new ConsoleInput(),
        //SearchStrategy = new Minimax(),
        SearchStrategy = new Negamax(),
        MoveGenerator = new LeftToRightMoveOrdering()
      };

      var renderer = new ConsoleInterface();

      game.Invalidated += renderer.Draw;

      return game;
    }
  }
}
