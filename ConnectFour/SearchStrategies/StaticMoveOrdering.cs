using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;

namespace ConnectFour.SearchStrategies
{
  public class StaticMoveOrdering : IMoveOrderStrategy
  {
    #region IMoveOrderStrategy Members

    private int[] moves = new int[] { 3, 2, 4, 1, 5, 0, 6 };

    public int[] GetMovesForTurn(Game game)
    {
      return moves;
    }

    #endregion
  }
}
