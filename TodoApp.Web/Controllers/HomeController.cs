using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoApp.Web.Models;

namespace TodoApp.Web.Controllers
{
    public class HomeController : Controller
    {
        // Logger instance for logging purposes
        public IActionResult Index()
        {
            return View();
        }

        // Privacy action to display privacy information
        public IActionResult Privacy()
        {
            return View();
        }

        // Error action to handle errors and display error information
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
