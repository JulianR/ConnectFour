using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFour;
using ConnectFour.Evaluation;
using ConnectFour.SearchStrategies;

namespace ConnectFourCore
{
  public sealed class Game
  {
    public Game(GameBoard board, Player currentPlayer)
    {
      this.Board = board;
      board.Game = this;
      TerminalPositionsTable.Init();
      this.PlayerCombinations = new PlayerCombinations(board);
    }

    public Game()
      : this(Player.Human)
    {
    }

    public Game(Player player)
      : this(new GameBoard(), player)
    {
    }

    public Player CurrentPlayer { get; private set; }

    public int SelectedColumnIndex { get; private set; }

    public GameBoard Board { get; private set; }

    public IGameInput Input { get; set; }

    public IMoveOrderStrategy MoveGenerator { get; set; }

    public ISearchStrategy SearchStrategy { get; set; }

    public event Action<Game> Invalidated;

    public PlayerCombinations PlayerCombinations { get; private set; }

    private bool gameIsOver;

    public void Start()
    {
      SwitchTurns();
    }

    private void SwitchTurns()
    {

      switch (this.CurrentPlayer)
      {
        case Player.Human:
          this.CurrentPlayer = Player.AI;
          break;
        case Player.AI:
          this.CurrentPlayer = Player.Human;
          break;
        default:
          throw new InvalidOperationException("Invalid Player");
      }

      TakeTurn(this.CurrentPlayer);
    }

    private void Invalidate()
    {
      if (this.Invalidated != null)
      {
        Invalidated(this);
      }
    }

    private void TakeTurn(Player player)
    {
      if (!this.gameIsOver)
      {
        if (CurrentPlayer == Player.Human)
        {
          InputCommand command;

          do
          {
            command = Input.GetInput();
            switch (command)
            {
              case InputCommand.MoveLeft:
                Math.Max(0, --SelectedColumnIndex);
                Invalidate();
                break;
              case InputCommand.MoveRight:
                Math.Min(Constants.Columns, ++SelectedColumnIndex);
                Invalidate();
                break;
              case InputCommand.Drop:
                Drop(this.SelectedColumnIndex);
                break;
              case InputCommand.Invalid:
                this.gameIsOver = true;
                return;
            }
          }
          while (command != InputCommand.Drop);

          SwitchTurns();
        }
        else
        {
          MakeDecision();
          SwitchTurns();
        }
      }
    }

    private void MakeDecision()
    {
      var column = this.SearchStrategy.FindBestColumnIndex(this);

      Drop(column);

      Logger.Flush();
      Logger.Clear();

    }

    private int Drop(int column)
    {
      int row;
      Board.DoMove(column, this.CurrentPlayer, out row);
      this.Invalidate();

      Player winner;

      if (Evaluator.IsLeafNode(this, out winner))
      {
        this.gameIsOver = true;
        //Console.WriteLine();
        //Console.WriteLine(winner.ToString() + " WINS!");
        //Console.WriteLine("Average time / computer turn: " + new TimeSpan(this.averageTime.Ticks / this.nrOfMoves));
        //Console.WriteLine();
      }

      return row;
    }
  }
}
