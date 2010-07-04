using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;
using ConnectFour.Evaluation;

namespace ConnectFour.SearchStrategies
{

  public class Negamax : ISearchStrategy
  {
    #region ISearchStrategy Members

    private int[] moves;
    private Game game;
    private GameBoard board;
    private int bestColumn;
    private int score;

    public int FindBestColumnIndex(Game game)
    {
      this.game = game;
      this.board = game.Board;

      NodesEvaluated = 0;

      moves = this.game.MoveGenerator.GetMovesForTurn(this.game);

      this.score = DoNegamax(0, -100000, 100000, Player.AI);

      return this.bestColumn;
    }

    public int NodesEvaluated { get; private set; }

    private int DoNegamax(int depth, int alpha, int beta, Player player)
    {
      Player winner;
      if (Evaluator.IsLeafNode(game, out winner))
      {
        //Logger.Log("Leaf node, winner is " + winner);
        return winner == player ? (10000 / depth) : (-10000 / depth);
      }
      else if (depth == Constants.RecursionDepth)
      {
        //Logger.Log("Reached maximum depth of " + depth);
        //Logger.Log("Value of board for player " + player + " is " + Evaluator.Evaluate(game, depth, player));
        NodesEvaluated++;
        return Evaluator.Evaluate(game, player);
      }

      //Logger.Log("Turn of " + player);

      foreach (var move in moves)
      {
        //Logger.Log("Move in column " + move + " for player " + player);
        int row;

        if (board.DoMove(move, player, out row))
        {
          //Logger.LogBoard(game.Board);

          //Logger.Log("Recursion to depth " + (depth + 1) + ", player switch");

          var value = -DoNegamax(depth + 1, -beta, -alpha, (Player)1 - (int)player);

          board.UndoMove(move, row, player);

          if (value > alpha)
          {
            alpha = value;
            if (player == Player.AI && depth == 0)
            {
              bestColumn = move;
              //Logger.Log("New best column: " + bestColumn + ", value: " + value);
            }
          }

          if (alpha >= beta)
          {
            return alpha;
          }

        }
      }
      return alpha;
    }

    #endregion
  }
}
