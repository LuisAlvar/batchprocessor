using System;
using System.Collections.Generic;
using System.Text;

namespace BatchClientCustomCL.WestARegion
{
  public class CaliforniaBatchWorkFlow
  {
    public string ProcessMessage(string message, string batchid)
    {
      try
      {
        return $"Processing the following message: {message} with the batchid({batchid})";
      }
      catch (Exception ex)
      {
        return $"Error occur with the CaliforniaBatchWorkflow.ProcessMesssage - Message {ex.Message} \n - Source {ex.Source} \n - Stack Trace {ex.StackTrace}";
      }
    }
  }
}
