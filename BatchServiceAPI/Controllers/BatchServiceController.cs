using BatchServiceAPI.Logic;
using BatchServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchServiceAPI.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class BatchServiceController: ControllerBase
  {
    private readonly ILogger<BatchServiceController> _logger;
    private readonly IMessageProcessor _processor;

    public BatchServiceController(ILogger<BatchServiceController> logger, IMessageProcessor processor)
    {
      _logger = logger;
      _processor = processor;
    }

    [HttpPost]
    public ActionResult<Response> ExecuteSolution(ExternalData data)
    {
      try
      {
        _logger.LogInformation($"Data Received: {JsonConvert.SerializeObject(data)}");
        var message = _processor.ExecuteMessage(data);

        return Ok(message);
      }
      catch (Exception ex)
      {
        string strErrorMessage = $"API Call Error Occur - Message {ex.Message} - Source {ex.Message} - Stack Trace {ex.StackTrace}";
        _logger.LogError(strErrorMessage);
        return NotFound();
      }
    }
  }
}
