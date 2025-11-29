using System.ComponentModel.DataAnnotations;

namespace ComplianceBuddy.Models
{
  public class Inspection
  {
    public int Id { get; set; }
    [Required]
    public string Vin { get; set; } = null!;
    public DateTime Date { get; set; } = DateTime.Now;
    [Required]
    public bool Passed { get; set; }
    public string UserId { get; set; } = null!;
  }
}
