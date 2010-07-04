using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;

namespace ConnectFour
{
  public sealed class InitialBoardState
  {
    private Player[,] state;

    public InitialBoardState()
    {
      state = new Player[Constants.Columns, Constants.Rows];

      for (int i = 0; i < Constants.Columns; i++)
      {
        for (int j = 0; j < Constants.Rows; j++)
        {
          state[i, j] = Player.None;
        }
      }

    }

    public static implicit operator Player[,](InitialBoardState board)
    {
      return board.state;
    }

    public Player this[int column, int row]
    {
      get
      {
        return state[column, row];
      }
      set
      {
        state[column, row] = value;
      }
    }

    public static Player[,] GetTestPositionOne()
    {
      var state = new InitialBoardState();

      state[0, 5] = Player.Human;
      state[3, 5] = Player.AI;
      state[3, 4] = Player.Human;
      state[3, 3] = Player.AI;
      state[3, 2] = Player.AI;

      return state;
    }

    public static Player[,] GetTestPositionTwo()
    {
      var state = new InitialBoardState();

      state[0, 5] = Player.AI;
      state[0, 4] = Player.Human;
      state[1, 5] = Player.AI;
      state[1, 4] = Player.Human;
      state[2, 4] = Player.AI;
      state[2, 5] = Player.Human;
      state[3, 4] = Player.AI;
      state[3, 5] = Player.Human;
      state[4, 5] = Player.AI;
      state[4, 4] = Player.Human;
      state[5, 5] = Player.AI;
      state[5, 4] = Player.Human;
      state[6, 4] = Player.AI;
      state[6, 5] = Player.Human;

      return state;
    }

  }
}
