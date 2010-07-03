using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectFourCore
{

  public enum InputCommand
  {
    Invalid,
    MoveLeft,
    MoveRight,
    Drop
  }

  public interface IGameInput
  {
    InputCommand GetInput();
  }
}
