using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;
using ConnectFour.Evaluation;

namespace ConnectFour.SearchStrategies
{
  //public class Minimax : ISearchStrategy
  //{
  //  private int[] moves;
  //  private Game game;
  //  private GameBoard board;
  //  private int bestColumn;
  //  private int score;

  //  public int FindBestColumnIndex(Game game)
  //  {
  //    this.game = game;
  //    this.board = game.Board;

  //    moves = this.game.MoveGenerator.GetMovesForTurn(this.game);

  //    this.score = Max(Constants.RecursionDepth);

  //    Console.WriteLine(score);

  //    return this.bestColumn;
  //  }

  //  private int Max(int depth)
  //  {
  //    Player winner;
  //    if (Evaluator.IsLeafNode(this.game, out winner) || depth == 0)
  //    {
  //      return Evaluator.Evaluate(this.game, depth);
  //    }

  //    int score = int.MinValue;

  //    foreach (var move in this.moves)
  //    {
  //      int row;

  //      if (board.DoMove(move, Player.AI, out row))
  //      {

  //        int value = Min(depth - 1);

  //        if (value > score)
  //        {
  //          score = value;
  //          this.bestColumn = move;
  //        }

  //        board.UndoMove(move, row, Player.AI);
  //      }
  //    }

  //    return score;

  //  }

  //  private int Min(int depth)
  //  {
  //    Player winner;
  //    if (Evaluator.IsLeafNode(this.game, out winner) || depth == 0)
  //    {
  //      return Evaluator.Evaluate(this.game, depth);
  //    }

  //    int score = int.MinValue;

  //    foreach (var move in this.moves)
  //    {
  //      int row;

  //      if (board.DoMove(move, Player.Human, out row))
  //      {

  //        int value = Max(depth - 1);

  //        if (value > score)
  //        {
  //          score = value;
  //        }

  //        board.UndoMove(move, row, Player.Human);
  //      }
  //    }

  //    return score;
  //  }

  //}
}
