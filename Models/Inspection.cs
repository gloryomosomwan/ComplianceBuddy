using System.ComponentModel.DataAnnotations;

namespace ComplianceBuddy.Models
{
  public class Inspection
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "An inspection date is required.")]
    public DateTime Date { get; set; } = DateTime.Today;
    public bool Passed { get; set; }
    public string UserId { get; set; } = null!;

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
  }
}
