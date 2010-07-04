using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;
using ConnectFour.Evaluation;
using System.Reflection;
using System.ComponentModel;

namespace ConnectFour.SearchStrategies
{
  public sealed class AlphaBeta : ISearchStrategy
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

      this.score = Negamax(0, -100000, 100000, Player.AI);

      return this.bestColumn;
    }

    public int NodesEvaluated { get; private set; }

    private int Negamax(int depth, int alpha, int beta, Player player)
    {
      Player winner;
      if (Evaluator.IsLeafNode(board, out winner))
      {
        // Give a lower score to wins further down the tree
        return winner == player ? (10000 / depth) : (-10000 / depth);
      }
      else if (depth == game.RecursionDepth)
      {
        NodesEvaluated++;
        return Evaluator.Evaluate(game, player);
      }

      foreach (var move in moves)
      {
        int row;

        if (board.DoMove(move, player, out row))
        {
          var value = -Negamax(depth + 1, -beta, -alpha, (Player)1 - (int)player);

          board.UndoMove(move, row, player);

          if (value > alpha)
          {
            alpha = value;
            if (player == Player.AI && depth == 0)
            {
              bestColumn = move;
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
