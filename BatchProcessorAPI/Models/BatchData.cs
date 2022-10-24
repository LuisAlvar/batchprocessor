using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchProcessorAPI.Models
{
  public class BatchData
  {
    public List<string> BatchSystemRegionIds { get; set; }
    public List<string> BatchSolutionIds { get; set; }
  }
}
