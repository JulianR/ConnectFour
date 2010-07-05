using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;
using ConnectFour.Evaluation;
using System.ComponentModel;

namespace ConnectFour.SearchStrategies
{
  public sealed class Minimax : ISearchStrategy
  {
    private int[] moves;
    private Game game;
    private GameBoard board;
    private int bestColumn;
    private int score;
    private Player maxPlayer;

    public int FindBestColumnIndex(Game game, Player maxPlayer)
    {
      this.game = game;
      this.board = game.Board;
      this.maxPlayer = maxPlayer;

      this.NodesEvaluated = 0;

      moves = this.game.MoveGenerator.GetMovesForTurn(this.game);

      this.score = Negamax(0, maxPlayer);

      return this.bestColumn;
    }

    public int NodesEvaluated { get; private set; }

    private int Negamax(int depth, Player player)
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

      int score = -100000;

      foreach (var move in this.moves)
      {
        int row;

        if (board.DoMove(move, player, out row))
        {
          var value = -Negamax(depth + 1, (Player)1 - (int)player);

          board.UndoMove(move, row, player);

          if (value > score)
          {
            score = value;
            if (player == maxPlayer && depth == 0)
            {
              bestColumn = move;
            }
          }
        }
      }

      return score;

    }

  }
}
