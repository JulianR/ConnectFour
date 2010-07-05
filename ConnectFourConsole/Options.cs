using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConnectFourConsole
{
  [Serializable]
  public class Options
  {
    public int RecursionDepth { get; set; }

    public string MoveOrderingStrategy { get; set; }

    public string SearchStrategy { get; set; }

    public string InitialState { get; set; }

    public bool IsComputerVsComputer { get; set; }

    public Options()
    {
      InitialState = "None";
    }

  }
}
