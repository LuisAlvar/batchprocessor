using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BatchProcessor.EF.Models
{
  public class SolutionInfo
  {
    [Key]
    public int SolutionId { get; set; }

    [Required]
    public int RegionId { get; set; }

    [Required]
    public string AssemblyName { get; set; }

    [Required]
    public string AssemblyCreateAbleClass { get; set; }
  }
}
