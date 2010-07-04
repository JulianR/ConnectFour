using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConnectFourCore;

namespace ConnectFour.SearchStrategies
{
  public interface ISearchStrategy
  {
    int FindBestColumnIndex(Game game);

    int NodesEvaluated { get; }
  }
}
