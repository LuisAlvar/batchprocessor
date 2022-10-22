using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchProcessorAPI.Models
{
  public class BatchStartData
  {
    public List<string> BatchSystemEnvIds { get; set; }
    public List<string> BatchSolutionIds { get; set; }
  }
}
