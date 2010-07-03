using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;

namespace ConnectFourConsole
{
  public class ConsoleInterface : IGameRenderer
  {
    private Game game;
    public ConsoleInterface()
    {

    }

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
      for (int y = 0; y < Constants.Rows; y++)
      {
        for (int x = 0; x < Constants.Columns; x++)
        {
          Player player = game.Board[x, y];
          if (player == Player.Human)
          {
            Console.Write("|0");
          }
          else if (player == Player.AI)
          {
            Console.Write("|X");
          }
          else
          {
            Console.Write("|_");
          }
        }
        Console.Write("|");
        Console.WriteLine();
      }
    }
  }
}
