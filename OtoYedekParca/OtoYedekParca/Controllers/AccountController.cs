using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OtoYedekParca.Business.Abstracts;
using OtoYedekParca.Entity;
using OtoYedekParca.ViewModels;

namespace OtoYedekParca.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;
        private User user;

        public AccountController(UserManager<User> userManager, IFileService fileService)
        {
            _userManager = userManager;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            user = await GetUser();
            ViewData["Title"] = user.UserName + " - Hesap Yönetimi";
            return View(user);
        }

        public async Task<IActionResult> EditProfile()
        {
            user = await GetUser();

            return View(user);
        }

         [HttpPost]
        public async Task<IActionResult> EditProfile(IFormFile file, User user)
        {
            var userx = await _userManager.GetUserAsync(HttpContext.User);
          
            userx.Email = user.Email;
            userx.PhoneNumber = user.PhoneNumber;
            userx.UserName = user.UserName;

            await _userManager.UpdateAsync(user);

            if(file != null)
            {
              await _fileService.Add(file,user);
            }

            

            return RedirectToAction("Index","Account");
        }







        // public async Task<IActionResult> UploadImage(IFormFile file)
        // {  
        //     user = await GetUser();
        //     await _fileService.Add(file, user);
        //     return RedirectToAction("Index");
        // }

        // [HttpGet]
        // public async Task<IActionResult> SifreDegistir()
        // {
        //     return View();
        // }

        // [HttpPost]
        // public async Task<IActionResult> SifreDegistir(UserChangePasswordViewModel p)
        // {
        //     var user = await _userManager.GetUserAsync(HttpContext.User);
        //     var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //     if (_userManager.CheckPasswordAsync(user, p.OldPassword).Result)
        //     {
        //         var result = await _userManager.ChangePasswordAsync(user, p.OldPassword, p.NewPassword);
        //         if (result.Succeeded)
        //         {
        //             return RedirectToAction("index", "hesap");
        //         }
        //         else
        //         {
        //             return View();
        //         }
        //     }
        //     else
        //     {
        //         return View();
        //     }
        // }


        // çağırmak için yazılan method
        [NonAction]
        private async Task<User> GetUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }
    
    }
}