using System.ComponentModel.DataAnnotations;

namespace ComplianceBuddy.Models
{
  public class Inspection
  {
    public int Id { get; set; }
    [Required]
    public string VehicleId { get; set; } = null!;
    public DateTime Date { get; set; } = DateTime.Now;
    [Required]
    public bool Passed { get; set; }
  }
}
