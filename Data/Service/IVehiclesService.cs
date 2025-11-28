using ComplianceBuddy.Models;

namespace ComplianceBuddy.Data.Service
{
  public interface IVehiclesService
  {
    Task<IEnumerable<Vehicle>> GetAll(string userId);
    Task Add(Vehicle vehicle);
    Task<Vehicle?> GetById(int id);
    Task Update(Vehicle vehicle);
    Task Delete(Vehicle vehicle);
  }
}