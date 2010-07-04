using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFour.SearchStrategies;
using ConnectFour;
using ConnectFourCore;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;

namespace Benchmarks
{

  public class InvalidGameInput : IGameInput
  {
    public InputCommand GetInput()
    {
      return InputCommand.Invalid;
    }
  }

  public class Program
  {
    static void Main(string[] args)
    {
      Process.GetCurrentProcess().PriorityBoostEnabled = true;
      Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

      const int iterations = 10;

      var searchDepths = new[] { 6, 9 };
      var searchStrategies = new[] 
      { 
        new
        {
          Name = "Alpha-beta", Type = typeof(AlphaBeta)
        }, 
        new
        {
          Name = "Minimax",Type = typeof(Minimax)
        } 
      };

      var moveOrderStrategies = new[] 
      {
        new
        { 
          Name = "Links naar rechts", Type = typeof(LeftToRightMoveOrdering)
        }, 
        new
        {  
          Name = "Statisch",Type =typeof(StaticMoveOrdering)
        }, 
        new
        {  
          Name = "Dynamisch",Type =typeof(DynamicMoveOrdering) 
        }
      };

      var initialStates = new[] 
      { 
        new
        { 
          Name = "Situatie 1", 
          State = InitialBoardState.GetTestPositionOne()
        }, 
        new
        {
          Name = "Situatie 2", 
          State = InitialBoardState.GetTestPositionTwo() 
        }
      };

      var sb = new StringBuilder();
      foreach (var searchDepth in searchDepths)
      {
        sb.AppendLine("Diepte " + searchDepth);
        sb.AppendLine();

        foreach (var state in initialStates)
        {
          sb.AppendLine(state.Name);
          sb.AppendLine();
          foreach (var moveOrdering in moveOrderStrategies)
          {
            sb.AppendLine(moveOrdering.Name);
            sb.AppendLine();

            foreach (var search in searchStrategies)
            {
              Console.WriteLine("Processing " + search.Name);
              TimeSpan time = TimeSpan.Zero;
              int bestColumn = 0;
              int nodesEvaluated = 0;
              for (int i = 0; i < iterations; i++)
              {
                var board = new GameBoard(state.State);
                var game = new Game(board, Player.Human)
                {
                  RecursionDepth = searchDepth,
                  Input = new InvalidGameInput(),
                  SearchStrategy = Activator.CreateInstance(search.Type) as ISearchStrategy,
                  MoveGenerator = Activator.CreateInstance(moveOrdering.Type) as IMoveOrderStrategy,
                };

                game.Start();
                time += game.TimeTaken;
                nodesEvaluated = game.NodesEvaluated;
                bestColumn = game.LastBestColumn;
                GC.Collect();
              }

              sb.AppendLine
              (
                search.Name + ": " + nodesEvaluated
                + " nodes doorzocht, duurde: "
                + new TimeSpan(time.Ticks / iterations).TotalMilliseconds + " ms, " 
                + "beste kolom: " + bestColumn
              );
            }
            sb.AppendLine();
          }
        }
      }

      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "benchmark");

      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }

      using (StreamWriter outfile =
            new StreamWriter(Path.Combine(path, Guid.NewGuid().ToString("N") + ".txt")))
      {
        outfile.Write(sb.ToString());
      }

    }
  }
}
