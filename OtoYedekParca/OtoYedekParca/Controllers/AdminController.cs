using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtoYedekParca.Business.Abstracts;
using OtoYedekParca.Entity;
using OtoYedekParca.ViewModels;

namespace OtoYedekParca.Controllers
{
    // [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUrunGrupService _urunGrupService;
        private readonly IUrunService _urunService;
        private readonly IMarkaService _markaService;
        private readonly IModelService _modelService;
        private readonly ITipService _tipService;

        public AdminController(IMarkaService markaService,IModelService modelService,ITipService tipService,IUrunService urunService,IUrunGrupService urunGrupService)
        {
            _urunService = urunService;
            _markaService = markaService;
            _modelService = modelService;
            _tipService = tipService;
            _urunGrupService = urunGrupService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Urun()
        {
            TanimlamaViewModel model = new TanimlamaViewModel()
            {
                markalar = _markaService.GetAll().Data,
                modeller = _modelService.GetAll().Data,
                tipler = _tipService.GetAll().Data,
                urunGruplari = _urunGrupService.GetAll().Data
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Urun(Urun urun)
        {
            //eksik

            return RedirectToAction("Admin","Index");
        }

        [HttpGet]
        public IActionResult Marka()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Marka(Marka marka)
        {
            marka.Pasif = false;
            marka.Siralama = 0;
            _markaService.Add(marka);

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Tip()
        {
            TanimlamaViewModel model = new TanimlamaViewModel()
            {
                markalar = _markaService.GetAll().Data
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Tip(Tip tip)
        {
            tip.Pasif = false;
            tip.Siralama = 0;
            _tipService.Add(tip);

            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        public IActionResult Model()
        {
            TanimlamaViewModel model = new TanimlamaViewModel()
            {
                markalar = _markaService.GetAll().Data,
                tipler = _tipService.GetAll().Data
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Model(Model model)
        {
            model.Pasif = false;
            model.Siralama = 0;
            _modelService.Add(model);

            return RedirectToAction("Index","Home");
        }

    }
}