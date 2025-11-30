using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ComplianceBuddy.Models;
using Microsoft.AspNetCore.Authorization;
using ComplianceBuddy.Data.Service;
using Microsoft.AspNetCore.Identity;

namespace ComplianceBuddy.Controllers;

public class HomeController : Controller
{
    private readonly IInspectionsService _inspectionsService;
    private readonly IVehiclesService _vehiclesService;
    private readonly UserManager<IdentityUser> _userManager;
    public HomeController(IInspectionsService inspectionsService, IVehiclesService vehiclesService, UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
        _inspectionsService = inspectionsService;
        _vehiclesService = vehiclesService;
    }

    [Authorize]
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user != null)
        {
            var vehicles = await _vehiclesService.GetAll(user.Id);
            var inspections = await _inspectionsService.GetAll(user.Id);
            var vm = new HomeViewModel { vehicles = vehicles, inspections = inspections };
            return View(vm);
        }
        else
        {
            return NotFound("User not found");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
