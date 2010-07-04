using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;

namespace ConnectFourConsole
{
  public class ConsoleInterface : IGameRenderer
  {

    public void Draw(Game game)
    {
      Console.Clear();
      for (int n = 0; n < Constants.Columns; n++)
      {
        if (n == game.SelectedColumnIndex)
        {
          Console.Write(" #");
        }
        else
          Console.Write("  ");
      }
      Console.WriteLine();
      Console.Write(game.Board.ToString());
      Console.WriteLine();
      Console.WriteLine("Time taken: " + game.TimeTaken.TotalMilliseconds + " ms");
      Console.WriteLine();
      Console.WriteLine
      (
        "Nodes evaluated: " 
        + game.NodesEvaluated 
        + " out of " 
        + Math.Pow(Constants.Columns, Constants.RecursionDepth)  
        + " leaf nodes."
      );
      Console.WriteLine();
      Console.WriteLine("Move ordering: " + ArrayToString(game.MoveGenerator.GetMovesForTurn(game)));


      if (game.Winner.HasValue)
      {
        Console.WriteLine();
        Console.WriteLine("Game was won by player " + game.Winner.Value);
      }
      if (game.AverageTimeTaken.HasValue)
      {
        Console.WriteLine();
        Console.WriteLine("Average time taken / move: " + game.AverageTimeTaken.Value.TotalMilliseconds + " ms");
      }
      Console.WriteLine();

    }

    private string ArrayToString<T>(T[] array)
    {
      return "[" + string.Join(",", array) + "]";
    }
  }
}
