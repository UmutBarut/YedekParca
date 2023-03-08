using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtoYedekParca.Business.Abstracts;

namespace OtoYedekParca.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private readonly IMarkaService _markaService;
        private readonly IModelService _modelService;
        private readonly ITipService _tipService;

        public AdminController(IMarkaService markaService,IModelService modelService,ITipService tipService)
        {
            _markaService = markaService;
            _modelService = modelService;
            _tipService = tipService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}