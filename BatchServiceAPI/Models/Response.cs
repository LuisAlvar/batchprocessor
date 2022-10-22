using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchServiceAPI.Models
{
  public class Response
  {
    public string BatchId { get; set; }
    public string SolutionId { get; set; }
    public string SolutionResponse { get; set; }
  }
}
