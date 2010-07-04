using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ConnectFourCore;
using ConnectFour.SearchStrategies;
using ConnectFour.Evaluation;
using ConnectFour;

namespace ConnectFourTest
{
  [TestClass]
  public class ConnectFourTests
  {

    [TestMethod]
    public void BlockTestVertical()
    {
      for (int i = 0; i < Constants.Columns; i++)
      {
        BlockTestVertical(i);
      }
    }

    [TestMethod]
    public void BlockTestHorizontal()
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
        state[i, Constants.Rows - 1] = Player.Human;
      }

      var board = new GameBoard(state);

      var game = new Game(board, Player.Human)
      {
        MoveGenerator = new LeftToRightMoveOrdering(),
        SearchStrategy = new AlphaBeta(),
        Input = new MockGameInput()
      };

      game.Start();

      Assert.IsTrue
      (
        game.Board[3, Constants.Rows - 1] == Player.AI,
        "AI had er voor moeten kiezen om de speler te blokkeren."
      );

    }

    private void BlockTestVertical(int column)
    {
      var state = new InitialBoardState();

      for (int i = 3; i < 6; i++)
      {
        state[column, i] = Player.Human;
      }

      var board = new GameBoard(state);

      var game = new Game(board, Player.Human)
      {
        MoveGenerator = new LeftToRightMoveOrdering(),
        SearchStrategy = new AlphaBeta(),
        Input = new MockGameInput()
      };

      game.Start();

      Assert.IsTrue(game.Board[column, 2] == Player.AI, "AI had er voor moeten kiezen om de speler te blokkeren.");

    }
  }
}
