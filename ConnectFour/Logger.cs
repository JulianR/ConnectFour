using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;
using System.IO;

namespace ConnectFour
{
  public static class Logger
  {
    private static StringBuilder builder = new StringBuilder();

    public static void LogBoard(GameBoard board)
    {
      builder.Append(board.ToString());

      builder.AppendLine();

    }

    public static void Clear()
    {
      builder.Clear();
    }

    public static void Log(string s)
    {
      builder.AppendLine(s);
      builder.AppendLine();
    }

    public static void Flush()
    {
      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "logs");

      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
      }

      using (StreamWriter outfile =
            new StreamWriter(Path.Combine(path, Guid.NewGuid().ToString("N") + ".txt")))
      {
        outfile.Write(builder.ToString());
      }


    }

  }
}
