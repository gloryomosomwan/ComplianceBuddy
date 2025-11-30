using ComplianceBuddy.Data.Service;
using ComplianceBuddy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ComplianceBuddy.Controllers
{

  public class InspectionsController : Controller
  {
    private readonly IInspectionsService _inspectionsService;
    private readonly UserManager<IdentityUser> _userManager;
    public InspectionsController(IInspectionsService inspectionsService, UserManager<IdentityUser> userManager)
    {
      _inspectionsService = inspectionsService;
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
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Inspection inspection)
    {
      if (ModelState.IsValid)
      {
        await _inspectionsService.Add(inspection);
        return RedirectToAction("Index");
      }
      return View(inspection);
    }

    [Authorize]
    public async Task<IActionResult> Edit(int id)
    {
      var inspection = await _inspectionsService.GetById(id);
      if (inspection == null)
      {
        return NotFound();
      }
      return View(inspection);
    }

    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, Inspection inspection)
    {
      if (id != inspection.Id)
      {
        return BadRequest();
      }

      if (ModelState.IsValid)
      {
        try
        {
          await _inspectionsService.Update(inspection);
          return RedirectToAction("Index");
        }
        catch
        {
          // Log the error (uncomment ex variable name and write a log.)
          ModelState.AddModelError("", "Unable to save changes. " +
              "Try again, and if the problem persists, " +
              "see your system administrator.");
        }
      }
      return View(inspection);
    }

    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
      var inspection = await _inspectionsService.GetById(id);
      if (inspection == null)
      {
        return NotFound();
      }
      return View(inspection);
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