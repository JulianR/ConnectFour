using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;

namespace ConnectFourTest
{
  public class MockGameInput : IGameInput
  {
    #region IGameInput Members

    public InputCommand GetInput()
    {
      return InputCommand.Invalid;
    }

    #endregion
  }
}
