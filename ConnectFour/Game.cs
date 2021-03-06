﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFour;
using ConnectFour.Evaluation;
using ConnectFour.SearchStrategies;
using System.Diagnostics;
using System.Threading;

namespace ConnectFourCore
{
  public sealed class Game
  {
    public Game(GameBoard board, Player currentPlayer)
    {
      this.RecursionDepth = 7;
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

    public bool IsComputerVsComputer { get; set; }

    public event Action<Game> Invalidated;

    public PlayerCombinations PlayerCombinations { get; private set; }

    public TimeSpan TimeTaken { get; private set; }
    public TimeSpan? AverageTimeTaken { get; private set; }

    private TimeSpan totalTimeTaken;

    public Player? Winner { get; private set; }

    public int RecursionDepth { get; set; }

    public int LastBestColumn { get; private set; }



    public int NodesEvaluated
    {
      get
      {
        if (this.SearchStrategy != null)
        {
          return this.SearchStrategy.NodesEvaluated;
        }
        return 0;
      }
    }

    private int moveCount = 0;

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

    // Signal to listeners that the game changed state and probably needs a rerender
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
        if (CurrentPlayer == Player.Human && !IsComputerVsComputer)
        {
          InputCommand command;

          do
          {
            command = Input.GetInput();
            switch (command)
            {
              case InputCommand.MoveLeft:
                SelectedColumnIndex = Math.Max(0, --SelectedColumnIndex);
                Invalidate();
                break;
              case InputCommand.MoveRight:
                SelectedColumnIndex = Math.Min(Constants.Columns - 1, ++SelectedColumnIndex);
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
        else if (CurrentPlayer == Player.Human)
        {
          MakeDecision(Player.Human);
          Thread.Sleep(500);
          SwitchTurns();
        }
        else
        {
          MakeDecision(Player.AI);
          if (IsComputerVsComputer)
          {
            Thread.Sleep(500);
          }
          SwitchTurns();
        }
      }
      Console.ReadLine();
    }

    private void MakeDecision(Player maxPlayer)
    {
      Stopwatch sw = Stopwatch.StartNew();
      var column = this.SearchStrategy.FindBestColumnIndex(this, maxPlayer);
      sw.Stop();
      TimeTaken = sw.Elapsed;
      totalTimeTaken += sw.Elapsed;
      this.LastBestColumn = column;

      Drop(column);
      this.moveCount++;
    }

    private int Drop(int column)
    {
      int row;
      Board.DoMove(column, this.CurrentPlayer, out row);

      Player winner;

      if (Evaluator.IsLeafNode(this.Board, out winner))
      {
        this.gameIsOver = true;
        this.Winner = winner;
        this.AverageTimeTaken = new TimeSpan(totalTimeTaken.Ticks / moveCount);
      }

      this.Invalidate();

      

      return row;
    }
  }
}
