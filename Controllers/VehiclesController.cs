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

    public async Task<IActionResult> Edit(int id)
    {
      var vehicle = await _vehiclesService.GetById(id);
      if (vehicle == null)
      {
        return NotFound();
      }
      return View(vehicle);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id)
    {
      var vehicleToUpdate = await _vehiclesService.GetById(id);
      if (vehicleToUpdate == null)
      {
        return NotFound();
      }

      if (await TryUpdateModelAsync<Vehicle>(
            vehicleToUpdate,
            "",
            v => v.Vin,
            v => v.Make,
            v => v.Model,
            v => v.Year))
      {
        try
        {
          await _vehiclesService.Update(vehicleToUpdate);
          return RedirectToAction("Index");
        }
        catch
        {
          ModelState.AddModelError("", "Unable to save changes. Try again.");
        }
      }

      return View(vehicleToUpdate);
    }
  }
}