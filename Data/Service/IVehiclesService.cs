using ComplianceBuddy.Models;

namespace ComplianceBuddy.Data.Service
{
  public interface IVehiclesService
  {
    Task<IEnumerable<Vehicle>> GetAll();
    Task Add(Vehicle vehicle);
  }
}