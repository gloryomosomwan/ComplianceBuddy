using System.ComponentModel.DataAnnotations;

namespace ComplianceBuddy.Models
{
  public class Inspection
  {
    public int Id { get; set; }
    [Required(ErrorMessage = "VIN is required.")]
    [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN must be exactly 17 characters.")]
    public string Vin { get; set; } = null!;
    [Required(ErrorMessage = "An inspection date is required.")]
    public DateTime Date { get; set; } = DateTime.Today;
    public bool Passed { get; set; }
    public string UserId { get; set; } = null!;
  }
}
