using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace BatchProcessor.EF.Configuration
{
  public class ConfigurationDbContext
  {
    private readonly string ApplicaitonSettings = "EF.config";

    private readonly ILogger<ConfigurationDbContext> _logger;

    public ConfigurationDbContext(ILogger<ConfigurationDbContext> logger)
    {
      _logger = logger;
    }

    public static string GetAssemblyTopLevelDir(bool dlmode=false)
    {
      string binDir = $"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}";

      string path = Assembly.GetCallingAssembly().Location;

      var indexOfPart = path.IndexOf(binDir, StringComparison.OrdinalIgnoreCase);

      return path.Substring(0, indexOfPart);
    }


  }
}
