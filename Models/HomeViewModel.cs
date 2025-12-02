namespace ComplianceBuddy.Models
{
  public class HomeViewModel
  {
    public IEnumerable<VehicleViewModel> Vehicles { get; set; } = null!;
    public IEnumerable<Inspection> Inspections { get; set; } = null!;
  }
}
