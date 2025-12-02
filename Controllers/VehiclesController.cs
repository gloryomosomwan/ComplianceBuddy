using ComplianceBuddy.Data.Service;
using ComplianceBuddy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ComplianceBuddy.Controllers
{

  public class VehiclesController : Controller
  {
    private readonly IVehiclesService _vehiclesService;
    private readonly UserManager<IdentityUser> _userManager;
    public VehiclesController(IVehiclesService vehiclesService, UserManager<IdentityUser> userManager)
    {
      _vehiclesService = vehiclesService;
      _userManager = userManager;
    }

    [Authorize]
    public async Task<IActionResult> Create()
    {
      var user = await _userManager.GetUserAsync(HttpContext.User);
      if (user == null)
      {
        return NotFound("User not found");
      }
      ViewData["UserId"] = user.Id;
      return View();
    }

    [Authorize]
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

    [Authorize]
    public async Task<IActionResult> Edit(int id)
    {
      var vehicle = await _vehiclesService.GetById(id);
      if (vehicle == null)
      {
        return NotFound();
      }
      return View(vehicle);
    }

    [Authorize]
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
          ModelState.AddModelError("", "Unable to save changes.");
        }
      }

      return View(vehicleToUpdate);
    }

    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
      var vehicle = await _vehiclesService.GetById(id);
      if (vehicle == null)
      {
        return NotFound();
      }
      await _vehiclesService.Delete(vehicle);
      return RedirectToAction("Index", "Home");
    }
  }
}