using ComplianceBuddy.Models;
using Microsoft.EntityFrameworkCore;

namespace ComplianceBuddy.Data
{
  public class ComplianceBuddyContext : DbContext
  {
    public ComplianceBuddyContext(DbContextOptions<ComplianceBuddyContext> options) : base(options) { }

    public DbSet<Vehicle> Vehicles { get; set; }
    DbSet<Inspection> Inspections { get; set; }

  }
}