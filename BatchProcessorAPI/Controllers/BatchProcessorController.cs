using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchProcessorAPI.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class BatchProcessorController : ControllerBase
  {
    public readonly ILogger<BatchProcessorController> _logger;

    public BatchProcessorController(ILogger<BatchProcessorController> logger)
    {
      _logger = logger;
    }

  }
}
