using BatchServiceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchServiceAPI.Logic
{
  public interface IMessageProcessor
  {
    public string ExecuteMessage(ExternalData data);
  }
}
