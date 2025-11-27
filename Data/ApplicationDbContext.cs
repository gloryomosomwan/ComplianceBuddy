using ComplianceBuddy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComplianceBuddy.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
  public DbSet<Vehicle> Vehicles { get; set; }
  public DbSet<Inspection> Inspections { get; set; }
}
