using ComplianceBuddy.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceBuddy.Data.Service
{
  public class VehiclesService : IVehiclesService
  {

    private readonly ComplianceBuddyContext _context;
    public VehiclesService(ComplianceBuddyContext context)
    {
      _context = context;
    }

    public async Task Add(Vehicle vehicle)
    {
      _context.Vehicles.Add(vehicle);
      await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Vehicle>> GetAll()
    {
      var vehicles = await _context.Vehicles.ToListAsync();
      return vehicles;
    }
  }
}