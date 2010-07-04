using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;
using System.ComponentModel;

namespace ConnectFour.SearchStrategies
{
  public sealed class StaticMoveOrdering : IMoveOrderStrategy
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
