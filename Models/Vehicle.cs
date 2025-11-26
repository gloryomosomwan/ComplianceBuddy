using System.ComponentModel.DataAnnotations;

namespace ComplianceBuddy.Models
{
  public class Vehicle
  {
    public int Id { get; set; }
    [Required]
    public string Vin { get; set; } = null!;
    [Required]
    public string Make { get; set; } = null!;
    [Required]
    public string Model { get; set; } = null!;
    [Required]
    public int Year { get; set; }
  }
}
