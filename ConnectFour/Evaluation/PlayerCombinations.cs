using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;

namespace ConnectFour.Evaluation
{
  public class PlayerCombinations
  {
    private int[][] combinations;

    public PlayerCombinations(GameBoard board)
    {
      Init(board);
    }

    public void Init(GameBoard board)
    {
      combinations = new int[2][];
      for (int i = 0; i < 2; i++)
      {
        combinations[i] = new int[70];
      }

      for (int r = 0; r < Constants.Rows; r++)
      {
        for (int c = 0; c < Constants.Columns; c++)
        {
          var result = TerminalPositionsTable.Get(c, r);

          foreach (var item in result)
          {
            var pos = board[c, r];
            if (pos != Player.None)
            {
              this[pos][item]++;
            }
          }

        }
      }

    }

    public int[] this[Player player]
    {
      get
      {
        return combinations[(int)player];
      }
    }
  }
}
