using System.ComponentModel.DataAnnotations;

namespace ComplianceBuddy.Models
{
  public class HomeViewModel
  {
    public IEnumerable<Vehicle> vehicles { get; set; } = null!;
    public IEnumerable<Inspection> inspections { get; set; } = null!;
  }
}
