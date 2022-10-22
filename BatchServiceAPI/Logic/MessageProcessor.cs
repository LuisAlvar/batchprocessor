using BatchServiceAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BatchServiceAPI.Logic
{
  public class MessageProcessor : IMessageProcessor
  {

    private readonly ILogger<MessageProcessor> _logger;

    private readonly IConfiguration _configuration;


    private string BatchCustomSolutionAssembly { get; set; }
    private string BatchCustomSolutionDLLName { get; set; }
    private string AssemblyCreateAbleClassName { get; set; }


    public MessageProcessor(ILogger<MessageProcessor> logger, IConfiguration configuration)
    {
      _logger = logger;
      _configuration = configuration;
    }

    private object ExecuteCustomSolutionMethod(ExternalData data)
    {
      BatchCustomSolutionAssembly = _configuration.GetValue<string>("BatchCustomSolutionDllPath");
      BatchCustomSolutionDLLName = _configuration.GetValue<string>("BatchCustomSolutionDllName");

      _logger.LogInformation($"{BatchCustomSolutionAssembly}");
      _logger.LogInformation($"{BatchCustomSolutionDLLName}");

      var assemblypath = System.IO.Path.Combine(BatchCustomSolutionAssembly, BatchCustomSolutionDLLName);
      assemblypath = assemblypath+ ".dll";
      _logger.LogInformation(assemblypath);

      Assembly _assembly;
      _assembly = Assembly.LoadFrom(assemblypath);

      Type type = _assembly.GetType(AssemblyCreateAbleClassName);
      var classobject = Activator.CreateInstance(type);

     
      object[] parameterObj = new object[2];
      parameterObj[0] = "Sending a Hello Message via ExecuteCustomSolutionMethod()";
      parameterObj[1] = data.BatchId;

      _logger.LogInformation($"Ready to execute custom solution method");

      return type.InvokeMember("ProcessMessage", BindingFlags.InvokeMethod, null, classobject, parameterObj);
    }


    public string ExecuteMessage(ExternalData data)
    {
      try
      {

        AssemblyCreateAbleClassName = _configuration.GetValue<string>("BatchCustomCreateAbleClass");
        AssemblyCreateAbleClassName = AssemblyCreateAbleClassName + "." + data.SolutionId;

        _logger.LogInformation($"{AssemblyCreateAbleClassName}");


        string response = ExecuteCustomSolutionMethod(data) as string;
        _logger.LogInformation($"Executed Custom Solution with a response of {response}");

        return response;
      }
      catch (Exception ex)
      {
        string strErrorMessage = $"ExecuteMessage - Message {ex.Message} - Source {ex.Message} - Stack Trace {ex.StackTrace}";
        _logger.LogError(strErrorMessage);
        return string.Empty;
      }
    }
  }
}
