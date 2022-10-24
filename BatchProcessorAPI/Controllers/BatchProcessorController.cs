using BatchProcessorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BatchProcessorAPI.Controllers
{

  [ApiController]
  [Route("/api/[controller]")]
  public class BatchProcessorController : ControllerBase
  {
    public readonly ILogger<BatchProcessorController> _logger;

    public BatchProcessorController(ILogger<BatchProcessorController> logger)
    {
      _logger = logger;
    }

    [HttpPost]
    public ActionResult<BatchData> RunNormalProcess(BatchData data)
    {
      try
      {

      }
      catch (Exception ex)
      {
        
        throw;
      }

      return NotFound(data);
    }

    [HttpPost]
    public ActionResult<BatchData> RunSolutions(BatchData data)
    {
      try
      {

      }
      catch (Exception ex)
      { 

        throw;
      }
      return NotFound(data);
    }

    [HttpGet]
    public ActionResult GetSolutionList()
    {
      return NotFound();
    }

    [HttpGet]
    public ActionResult GetSolutionInfo()
    {
      return NotFound();
    }

    [HttpPost]
    public ActionResult CreateSolution()
    {

      return NotFound();
    }






  }
}
