using ComplianceBuddy.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceBuddy.Data.Service
{
  public class VehiclesService : IVehiclesService
  {

    private readonly ApplicationDbContext _context;
    public VehiclesService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task Add(Vehicle vehicle)
    {
      _context.Vehicles.Add(vehicle);
      await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Vehicle>> GetAll(string userId)
    {
      var vehicles = await _context.Vehicles
      .Where(vehicle => vehicle.UserId == userId)
      .ToListAsync();
      return vehicles;
    }

    public async Task<Vehicle?> GetById(int id)
    {
      return await _context.Vehicles.FindAsync(id);
    }

    public async Task Update(Vehicle vehicle)
    {
      _context.Vehicles.Update(vehicle);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(Vehicle vehicle)
    {
      _context.Vehicles.Remove(vehicle);
      await _context.SaveChangesAsync();
    }
  }
}