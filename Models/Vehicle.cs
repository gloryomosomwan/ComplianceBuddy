using System.ComponentModel.DataAnnotations;

namespace ComplianceBuddy.Models
{
  public class Vehicle
  {
    public int Id { get; set; }

    [Required(ErrorMessage = "VIN is required.")]
    [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN must be exactly 17 characters.")]
    public string Vin { get; set; } = null!;

    [Required(ErrorMessage = "Vehicle make is required.")]
    public string Make { get; set; } = null!;

    [Required(ErrorMessage = "Vehicle model is required.")]
    public string Model { get; set; } = null!;

    [Required(ErrorMessage = "Vehicle year is required.")]
    [Range(1900, 2025, ErrorMessage = "Please enter a valid year between 1900 and 2025.")]
    public int Year { get; set; }

    public string UserId { get; set; } = null!;
  }
}
