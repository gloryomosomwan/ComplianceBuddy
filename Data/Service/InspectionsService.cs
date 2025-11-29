using ComplianceBuddy.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceBuddy.Data.Service
{
  public class InspectionsService : IInspectionsService
  {

    private readonly ApplicationDbContext _context;
    public InspectionsService(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task Add(Inspection inspection)
    {
      _context.Inspections.Add(inspection);
      await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Inspection>> GetAll(string userId)
    {
      var inspections = await _context.Inspections
      .Where(inspection => inspection.UserId == userId)
      .ToListAsync();
      return inspections;
    }

    public async Task<Inspection?> GetById(int id)
    {
      return await _context.Inspections.FindAsync(id);
    }

    public async Task Update(Inspection inspection)
    {
      _context.Inspections.Update(inspection);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(Inspection inspection)
    {
      _context.Inspections.Remove(inspection);
      await _context.SaveChangesAsync();
    }
  }
}