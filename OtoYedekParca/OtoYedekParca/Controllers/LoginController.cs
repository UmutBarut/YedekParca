using Microsoft.AspNetCore.Mvc;
using OtoYedekParca.Entity;
using OtoYedekParca.Dataaccess.Concrete.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OtoYedekParca.ViewModels;

namespace OtoYedekParca.Controllers
{
   [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;
        public LoginController(UserManager<User> userManager, SignInManager<User> signinManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signinManager = signinManager;
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("User");
            ViewData["Title"] = "Çıkış yapılıyor...";
            await _signinManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            ViewData["Title"] = "Panele Giriş";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserSignInViewModel p)
        {
            ViewData["LoginResult"] = "";
            ViewData["Title"] = "Giriş Yapılıyor";
            if (ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(p.UserName, p.Password, false, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "admin");
                }
                else
                {
                    ViewData["LoginResult"] = "Kullanıcı adı veya parola hatalı.";
                    return View(p);
                }
            }
            else
            {
                return View(p);
            }
        }

        // [Authorize(Roles = "Admin")]
        // [HttpGet]
        // public IActionResult Register()
        // {
        //     ViewData["Title"] = "Kullanıcı Kayıt";
        //     return View();
        // }

        // [Authorize(Roles = "Admin")]

        // [HttpPost]
        // public async Task<IActionResult> Register(UserSignUpViewModel p)
        // {

        //     ViewData["Title"] = "Kayıt ediliyor..";
        //     if (ModelState.IsValid)
        //     {
        //         Kullanici user = new Kullanici()
        //         {
        //             Email = p.Email,
        //             UserName = p.UserName,
        //         };
        //         var result = await _userManager.CreateAsync(user, p.Password);

        //         if (result.Succeeded)
        //         {
        //             return RedirectToAction("Index", "Users");

        //         }
        //         else
        //         {
        //             foreach (var item in result.Errors)
        //             {
        //                 ModelState.AddModelError("", item.Description);

        //             }
        //         }
        //     }
        //     return View(p);
        // }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}