using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;
using ConnectFour.Evaluation;

namespace ConnectFour.SearchStrategies
{

  //function negamax(node, depth, α, β, color)
  //  if node is a terminal node or depth = 0
  //      return color * the heuristic value of node
  //  else
  //      foreach child of node
  //          α := max(α, -negamax(child, depth-1, -β, -α, -color))
  //          {the following if statement constitutes alpha-beta pruning}
  //          if α≥β
  //              return α
  //      return α

  public class Negamax : ISearchStrategy
  {
    #region ISearchStrategy Members

    private int[] moves;
    private Game game;
    private GameBoard board;
    private int bestColumn;
    private int score;

    public int FindBestColumnIndex(ConnectFourCore.Game game)
    {
      this.game = game;
      this.board = game.Board;

      moves = this.game.MoveGenerator.GetMovesForTurn(this.game);

      this.score = DoNegamax(0, int.MinValue, int.MaxValue, Player.AI);

      return this.bestColumn;
    }

    private int DoNegamax(int depth, int alpha, int beta, Player player)
    {
      Player winner;
      if (Evaluator.IsLeafNode(game, out winner))
      {
        Logger.Log("Leaf node, winner is " + winner);
        return winner == player ? (10000 / depth) : (-10000 / depth);
      }
      else if (depth == Constants.RecursionDepth)
      {
        Logger.Log("Reached maximum depth of " + depth);
        Logger.Log("Value of board for player " + player + " is " + Evaluator.Evaluate(game, depth, player));
        return Evaluator.Evaluate(game, depth, player);
      }

      Logger.Log("Turn of " + player);

      foreach (var move in moves)
      {
        Logger.Log("Move in column " + move + " for player " + player);
        int row;

        if (board.DoMove(move, player, out row))
        {
          Logger.LogBoard(game.Board);

          Logger.Log("Recursion to depth " + (depth + 1) + ", player switch");

          var value = -DoNegamax(depth + 1, -beta, -alpha, (Player)1 - (int)player);

          board.UndoMove(move, row, player);

          if (value > alpha)
          {
            alpha = value;
            if (player == Player.AI)
            {
              Logger.Log("New best column: " + bestColumn + ", value: " + value);
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
