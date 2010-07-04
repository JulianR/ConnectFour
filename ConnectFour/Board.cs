using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFour.Evaluation;

namespace ConnectFourCore
{
  public sealed class GameBoard
  {
    public Player[] Cells { get; private set; }

    private readonly int[] moves;

    public Game Game { get; set; }

    private bool[] inTerminalState = new bool[2];

    public GameBoard()
    {

      Cells = new Player[Constants.Columns * Constants.Rows];

      for (int i = 0; i < Cells.Length; i++)
      {
        Cells[i] = Player.None;
      }

      this.moves = new int[Constants.Columns];

      for (int i = 0; i < Constants.Columns; i++)
        moves[i] = Constants.Rows - 1;

    }

    public GameBoard(Player[,] initialState)
      : this()
    {
      for (int i = 0; i < initialState.GetLength(0); i++)
      {
        for (int j = 0; j < initialState.GetLength(1); j++)
        {
          if (initialState[i, j] != Player.None)
          {
            this[i, j] = initialState[i, j];

            if (j <= moves[i])
            {
              moves[i] = j -1;
            }

          }
        }
      }
    }

    public Player this[int column, int row]
    {
      get
      {
        return Cells[column + row * Constants.Columns];
      }
      private set
      {
        Cells[column + row * Constants.Columns] = value;
      }
    }

    public bool InTerminalState(Player player)
    {
      return inTerminalState[(int)player];
    }

    public bool DoMove(int column, Player p, out int row)
    {
      row = moves[column];

      if (row >= 0)
      {
        Cells[column + row * Constants.Columns] = p;

        moves[column]--;

        var combinations = this.Game.PlayerCombinations[p];

        foreach (int i in TerminalPositionsTable.Get(column,row))
        {
          combinations[i]++;

          if (combinations[i] == 4)
          {
            inTerminalState[(int)p] = true;
          }
        }

        return true;
      }
      else
      {
        return false;
      }
    }

    public void UndoMove(int column, int row, Player player)
    {
      var combinations = this.Game.PlayerCombinations[player];
      foreach (int i in TerminalPositionsTable.Get(column,row))
      {
        if (combinations[i] == 4)
        {
          inTerminalState[(int)player] = false;
        }
        combinations[i]--;
      }
      Cells[column + row * Constants.Columns] = Player.None;
      moves[column]++;
    }

    public override string ToString()
    {
      var sb = new StringBuilder();

      for (int y = 0; y < Constants.Rows; y++)
      {
        for (int x = 0; x < Constants.Columns; x++)
        {
          Player player = this[x, y];
          if (player == Player.Human)
          {
            sb.Append("|0");
          }
          else if (player == Player.AI)
          {
            sb.Append("|X");
          }
          else
          {
            sb.Append("|_");
          }
        }
        sb.Append("|");
        sb.AppendLine();
      }

      return sb.ToString();
    }

  }
}
