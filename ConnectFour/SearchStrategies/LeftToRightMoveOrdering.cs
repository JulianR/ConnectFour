using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;

namespace ConnectFour.SearchStrategies
{

  public class LeftToRightMoveOrdering : IMoveOrderStrategy
  {
    #region IMoveOrderStrategy Members

    private int[] moves = new int[] { 0, 1, 2, 3, 4, 5, 6 };

    public int[] GetMovesForTurn(Game game)
    {
      return moves;
    }

    #endregion
  }
}
