using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ComplianceBuddy.Models;
using Microsoft.AspNetCore.Authorization;

namespace ComplianceBuddy.Controllers;

public class HomeController : Controller
{
    [Authorize]
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Vehicles");
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
