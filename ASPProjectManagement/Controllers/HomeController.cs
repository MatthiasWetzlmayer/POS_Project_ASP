using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ASPProjectManagementDb;
using ASPProjectManagement.Models;

namespace ASPProjectManagement.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
	private readonly ASPProjectManagementContext db;
	public HomeController(ILogger<HomeController> logger, ASPProjectManagementContext db)
	{
      _logger = logger;
	  this.db = db;
	}

    public IActionResult Index()
    {
      try
      {
        int nr = db.Projects.Count();
        ViewBag.Ok = $"Database Ok";
        ViewBag.Message = $"Database Ok: Nr Projects = {nr}";
      }
      catch (Exception exc)
      {
        ViewBag.Error = $"Database Not Ok";
        ViewBag.Message = $"Error = {exc.Message}";
      }
      return View();
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
}
