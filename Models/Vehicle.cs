using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

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

    // Foreign key for the user
    public string UserId { get; set; } = null;
    // Navigation property
    public IdentityUser User { get; set; }
  }
}
