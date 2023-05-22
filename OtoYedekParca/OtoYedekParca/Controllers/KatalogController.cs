using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OtoYedekParca.Business.Abstracts;
using OtoYedekParca.Entity;

namespace OtoYedekParca.Controllers
{
    [AllowAnonymous]
    public class KatalogController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUrunService _urunService;
        private readonly IUrunGrupService _urunGrupService;
        private readonly IMarkaService _markaService;
        private readonly IModelService _modelService;
        private readonly ITipService _tipService;
        private readonly ITip_MotorService _tipMotorService;
        private readonly IMotorService _motorService;


        public KatalogController(UserManager<User> userManager,IUrunService urunService, IUrunGrupService urunGrupService, IMarkaService markaService, IModelService modelService, ITipService tipService,ITip_MotorService tipMotorService ,IMotorService motorService)
        {
            _userManager = userManager;
            _urunService = urunService;
            _urunGrupService = urunGrupService;
            _markaService = markaService;
            _modelService = modelService;
            _tipService = tipService;
            _tipMotorService = tipMotorService;
            _motorService = motorService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}