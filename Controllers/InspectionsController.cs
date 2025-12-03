using ComplianceBuddy.Data.Service;
using ComplianceBuddy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ComplianceBuddy.Controllers
{

  public class InspectionsController : Controller
  {
    private readonly IInspectionsService _inspectionsService;
    private readonly IVehiclesService _vehiclesService;
    private readonly UserManager<IdentityUser> _userManager;
    public InspectionsController(IInspectionsService inspectionsService, IVehiclesService vehiclesService, UserManager<IdentityUser> userManager)
    {
      _inspectionsService = inspectionsService;
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

      var vehicles = await _vehiclesService.GetAll(user.Id);
      ViewData["Vehicles"] = new SelectList(vehicles, "Id", "Vin");

      ViewData["UserId"] = user.Id;
      return View();
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Inspection inspection)
    {
      inspection.Vehicle = await _vehiclesService.GetById(inspection.VehicleId);
      ModelState.Remove(nameof(inspection.Vehicle));
      if (TryValidateModel(inspection))
      {
        await _inspectionsService.Add(inspection);
        return RedirectToAction("Index", "Home");
      }
      else
      {
        // If model is invalid, re-populate the dropdown and return the view with errors.
        var allErrors = ModelState
            .Where(kvp => kvp.Value.Errors.Any())
            .Select(kvp => new
            {
              Key = kvp.Key,
              Errors = kvp.Value.Errors.Select(e => e.ErrorMessage ?? e.Exception?.Message).ToList()
            }).ToList();
        foreach (var i in allErrors)
        {
          foreach (var j in i.Errors)
          {
            Console.WriteLine(j);
          }
        }
        var user = await _userManager.GetUserAsync(HttpContext.User);
        var vehicles = await _vehiclesService.GetAll(user.Id);
        ViewData["Vehicles"] = new SelectList(vehicles, "Id", "Vin", inspection.VehicleId);
        ViewData["UserId"] = user.Id;
        // return RedirectToAction("Create");
        return View(inspection);
      }
    }

    [Authorize]
    public async Task<IActionResult> Edit(int id)
    {
      var inspection = await _inspectionsService.GetById(id);
      if (inspection == null)
      {
        return NotFound();
      }

      var user = await _userManager.GetUserAsync(HttpContext.User);
      var vehicles = await _vehiclesService.GetAll(user.Id);
      ViewData["Vehicles"] = new SelectList(vehicles, "Id", "Vin", inspection.VehicleId);

      return View(inspection);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ConfirmEdit(int id)
    {
      var inspectionToUpdate = await _inspectionsService.GetById(id);
      if (inspectionToUpdate == null)
      {
        return NotFound();
      }

      if (await TryUpdateModelAsync(
          inspectionToUpdate,
          "",
          i => i.VehicleId, i => i.Date, i => i.Passed))
      {
        try
        {
          await _inspectionsService.Update(inspectionToUpdate);
          return RedirectToAction("Index", "Home");
        }
        catch
        {
          ModelState.AddModelError("", "Unable to save changes");
        }
      }
      var user = await _userManager.GetUserAsync(HttpContext.User);
      var vehicles = await _vehiclesService.GetAll(user.Id);
      ViewData["Vehicles"] = new SelectList(vehicles, "Id", "Vin", inspectionToUpdate.VehicleId);
      return View("Edit", inspectionToUpdate);
    }

    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
      var inspection = await _inspectionsService.GetById(id);
      if (inspection == null)
      {
        return NotFound();
      }
      await _inspectionsService.Delete(inspection);
      return RedirectToAction("Index", "Home");
    }

    [Authorize]
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var inspection = await _inspectionsService.GetById(id);
      if (inspection == null)
      {
        return NotFound();
      }
      await _inspectionsService.Delete(inspection);
      return RedirectToAction("Index");
    }
  }
}