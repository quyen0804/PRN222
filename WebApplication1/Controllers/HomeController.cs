using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(){
            HomeModel message = new HomeModel();
            return View(message);
        }
        public string Hello() => "Hello, ASP.NET Core MVC";

        
    }
}
