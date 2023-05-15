using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OtoYedekParca.Business.Abstracts;
using OtoYedekParca.Entity;
using OtoYedekParca.ViewModels;

namespace OtoYedekParca.Controllers
{
    // [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IUrunGrupService _urunGrupService;
        private readonly IUrunService _urunService;
        private readonly IMarkaService _markaService;
        private readonly IModelService _modelService;
        private readonly ITipService _tipService;
        private readonly IMotorService _motorService;
        

        public AdminController(IMarkaService markaService,IModelService modelService,ITipService tipService,IUrunService urunService,IUrunGrupService urunGrupService,IMotorService motorService,UserManager<User> userManager)
        {
            _userManager = userManager;
            _urunService = urunService;
            _markaService = markaService;
            _modelService = modelService;
            _tipService = tipService;
            _urunGrupService = urunGrupService;
            _motorService = motorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult KullaniciListele()
        {
            return View();
        }
        [HttpGet]
        public object GetUsers(DataSourceLoadOptions LoadOptions)
        {
            var result = _userManager.Users.ToList();
            return DataSourceLoader.Load(result, LoadOptions);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string key)
        {
            var newUser = await _userManager.FindByIdAsync(key);
            var appUser = await _userManager.GetUserAsync(HttpContext.User);
            if (newUser != null && newUser != appUser && !newUser.IsAdmin){
                var result = await _userManager.DeleteAsync(newUser);
                return Ok();
            }
            else{
                return BadRequest("Kendi kullanıcınızı veya bir admini silemezsiniz. Lütfen bize başvurun.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(string key, string values)
        {
            var newUser = await _userManager.FindByIdAsync(key);
            JsonConvert.PopulateObject(values, newUser);
            if (newUser.IsAdmin){
                var roleResult = await _userManager.AddToRoleAsync(newUser, "Admin");
            }
            else{
                var roleResult = await _userManager.RemoveFromRoleAsync(newUser, "Admin");
            }
            var result = await _userManager.UpdateAsync(newUser);
            if (result.Succeeded){
                return Ok("Kullanıcı güncellendi.");
            }
            else{
                return BadRequest("Kullanıcı güncellenirken hata oluştu.");
            }
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

        [HttpGet]
        public object GetAllMarka(DataSourceLoadOptions loadOptions)
        {
            var marka = _markaService.GetAll(c=>c.Pasif == false).Data;
            return DataSourceLoader.Load(marka, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddMarka(string values)
        {
            var marka = new Marka();
            JsonConvert.PopulateObject(values, marka);
            var result = _markaService.Add(marka);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateMarka(int key, string values)
        {
            var marka = _markaService.GetById(c=> c.MarkaId == key).Data;
            JsonConvert.PopulateObject(values, marka);
            var result = _markaService.Update(marka);
            return Ok(result);
        }
 
         [HttpDelete]
        public IActionResult DeleteMarka(int key)
        {
            var marka = _markaService.GetAll(c => c.MarkaId == key).Data.FirstOrDefault();
            marka.Pasif = true;
            var result = _markaService.Update(marka);
            return Ok(result);
        }


        // [HttpPost]
        // public IActionResult Marka(Marka marka)
        // {
        //     marka.Pasif = false;
        //     marka.Siralama = 0;
        //     _markaService.Add(marka);

        //     return RedirectToAction("Index","Home");
        // }

       

        [HttpGet]
        public IActionResult Model()
        {
            return View();
        }
 
        [HttpGet]
        public object GetAllModel(DataSourceLoadOptions loadOptions)
        {
            var model = _modelService.GetAll(c=>c.Pasif == false).Data;
            return DataSourceLoader.Load(model, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddModel(string values)
        {
            var model = new Model();
            JsonConvert.PopulateObject(values, model);
            var result = _modelService.Add(model);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateModel(int key, string values)
        {
            var model = _modelService.GetById(c=> c.ModelId == key).Data;
            JsonConvert.PopulateObject(values, model);
            var result = _modelService.Update(model);
            return Ok(result);
        }
 
         [HttpDelete]
        public IActionResult DeleteModel(int key)
        {
            var model = _modelService.GetAll(c => c.ModelId == key).Data.FirstOrDefault();
            model.Pasif = true;
            var result = _modelService.Update(model);
            return Ok(result);
        }


        [HttpGet]
        public IActionResult Tip()
        {
            return View();
        }

        [HttpGet]
        public object GetAllTip(DataSourceLoadOptions loadOptions)
        {
            var tip = _tipService.GetAll(c=>c.Pasif == false).Data;
            return DataSourceLoader.Load(tip, loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> AddTip(string values)
        {
            var tip = new Tip();
            JsonConvert.PopulateObject(values, tip);
            var result = _tipService.Add(tip);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateTip(int key, string values)
        {
            var tip = _tipService.GetById(c=> c.TipId== key).Data;
            JsonConvert.PopulateObject(values, tip);
            var result = _tipService.Update(tip);
            return Ok(result);
        }
 
         [HttpDelete]
        public IActionResult DeleteTip(int key)
        {
            var tip = _tipService.GetAll(c => c.TipId == key).Data.FirstOrDefault();
            tip.Pasif = true;
            var result = _tipService.Update(tip);
            return Ok(result);
        }


        // [HttpPost]
        // public IActionResult Tip(Tip tip)
        // {
        //     tip.Pasif = false;
        //     tip.Siralama = 0;
        //     _tipService.Add(tip);

        //     return RedirectToAction("Index","Home");
        // }

       

        

       

        [HttpPost]
        public IActionResult Model(Model model)
        {
            model.Pasif = false;
            model.Siralama = 0;
            _modelService.Add(model);

            return RedirectToAction("Index","Home");
        }

         [HttpGet]
        public IActionResult Motor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Motor(Motor motor)
        {
            motor.Pasif = false;
            _motorService.Add(motor);

            return RedirectToAction("Index","Home");
        }
    }
}