using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OtoYedekParca.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {   var userName = User.Identity.Name;
            ViewData["UserName"] = userName;
            return View("Index");
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        
    }
}