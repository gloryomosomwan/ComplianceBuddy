using ComplianceBuddy.Data.Service;
using ComplianceBuddy.Models;
using Microsoft.AspNetCore.Mvc;

namespace ComplianceBuddy.Controllers
{

  public class VehiclesController : Controller
  {
    private readonly IVehiclesService _vehiclesService;
    public VehiclesController(IVehiclesService vehiclesService)
    {
      _vehiclesService = vehiclesService;
    }
    public async Task<IActionResult> Index()
    {
      var vehicles = await _vehiclesService.GetAll();
      return View(vehicles);
    }

    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Vehicle vehicle)
    {
      if (ModelState.IsValid)
      {
        await _vehiclesService.Add(vehicle);
        return RedirectToAction("Index");
      }
      return View(vehicle);
    }
  }
}