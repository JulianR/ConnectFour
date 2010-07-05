using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;
using ConnectFour.Evaluation;
using System.ComponentModel;

namespace ConnectFour.SearchStrategies
{
  public sealed class DynamicMoveOrdering : IMoveOrderStrategy
  {
    #region IMoveOrderStrategy Members

    private const int scoreWeight = 10;

    public int[] GetMovesForTurn(Game game)
    {
      // Order columns by AI player's score and the column's potential remaining score
      return (from c in Enumerable.Range(0, Constants.Columns)

              let combinationsInColumn = (from r in Enumerable.Range(0, Constants.Rows)
                                          where game.Board[c, r] == Player.None
                                          select TerminalPositionsTable.Get(c, r).Count()).Sum()

              let combinationsForPlayer = game.PlayerCombinations[game.CurrentPlayer]

              let scoreInColumn = (from r in Enumerable.Range(0, Constants.Rows)
                                   from x in TerminalPositionsTable.Get(c, r)
                                   select combinationsForPlayer[x]).Sum()

              let totalScore = combinationsInColumn + (scoreInColumn * scoreWeight)

              orderby totalScore descending

              select c).ToArray();

    }

    #endregion
  }
}
