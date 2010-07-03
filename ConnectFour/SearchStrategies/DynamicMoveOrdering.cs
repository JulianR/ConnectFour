using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;
using ConnectFour.Evaluation;

namespace ConnectFour.SearchStrategies
{
  public class DynamicMoveOrdering : IMoveOrderStrategy
  {
    #region IMoveOrderStrategy Members

    private const int scoreWeight = 10;

    public int[] GetMovesForTurn(Game game)
    {
      return (from c in Enumerable.Range(0, Constants.Columns)

              let combinationsInColumn = (from r in Enumerable.Range(0, Constants.Rows)
                                          where game.Board[c, r] == Player.None
                                          select TerminalPositionsTable.Get(c, r).Count()).Sum()

              let combinationsForPlayer = game.PlayerCombinations[Player.AI]

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
