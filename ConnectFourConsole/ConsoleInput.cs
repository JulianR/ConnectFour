using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;

namespace ConnectFourConsole
{
  public sealed class ConsoleInput : IGameInput
  {

    public InputCommand GetInput()
    {
      var key = Console.ReadKey();

      switch (key.Key)
      {
        case ConsoleKey.LeftArrow:
          return InputCommand.MoveLeft;
        case ConsoleKey.RightArrow:
          return InputCommand.MoveRight;
        case ConsoleKey.Spacebar:
          return InputCommand.Drop;
        default:
          return InputCommand.Invalid;
      }
    }

  }
}
