namespace ComplianceBuddy.Models
{
  public class HomeViewModel
  {
    public IEnumerable<VehicleViewModel> vehicles { get; set; } = null!;
    public IEnumerable<Inspection> inspections { get; set; } = null!;
  }
}
