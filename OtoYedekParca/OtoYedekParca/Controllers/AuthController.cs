using Microsoft.AspNetCore.Mvc;
using OtoYedekParca.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using OtoYedekParca.ViewModels;
using Newtonsoft.Json;

namespace OtoYedekParca.Controllers
{
   [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;
        public AuthController(UserManager<User> userManager, SignInManager<User> signinManager, RoleManager<IdentityRole> roleManager)
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

        // [HttpGet]
        // public async Task<IActionResult> Login()
        // {
        //     ViewData["Title"] = "Panele Giriş";
        //     var user = HttpContext.Request.Cookies["User"];
        //     if (!string.IsNullOrEmpty(user))
        //     {
        //         UserSignInViewModel userToLogin = new UserSignInViewModel();
        //         JsonConvert.PopulateObject(user, userToLogin);
        //         if (userToLogin != null)
        //         {
        //             var result = await _signinManager.PasswordSignInAsync(userToLogin.UserName, userToLogin.Password, false, true);
        //             if (result.Succeeded)
        //             {
        //                 return RedirectToAction("Index", "Home");
        //             }
        //         }
        //     }
        //     return View();
        // }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            ViewData["Title"] = "Panele Giriş";
            var user = HttpContext.Request.Cookies["User"];
            if (!string.IsNullOrEmpty(user))
            {
                UserSignInViewModel userToLogin = JsonConvert.DeserializeObject<UserSignInViewModel>(user);
                if (userToLogin != null)
                {
                    var result = await _signinManager.PasswordSignInAsync(userToLogin.UserName, userToLogin.Password, false, true);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }

        // [HttpPost]
        // public async Task<IActionResult> Login(UserSignInViewModel p)
        // {
        //     ViewData["LoginResult"] = "";
        //     ViewData["Title"] = "Giriş Yapılıyor";
        //     if (ModelState.IsValid)
        //     {
        //         var result = await _signinManager.PasswordSignInAsync(p.UserName, p.Password, false, true);

        //         if(User.IsInRole("Admin"))
        //         {
        //             if(result.Succeeded)
        //             {
        //                 return RedirectToAction("Index", "Admin");
        //             }
        //             else
        //             {
        //                 ViewData["LoginResult"] = "Kullanıcı adı veya şifre hatalı.";
        //                 return View(p);
        //             }
        //         }
        //         else{
        //             if(result.Succeeded)
        //             {
        //                 return RedirectToAction("Index", "Home");
        //             }
        //             else
        //             {
        //                 ViewData["LoginResult"] = "Kullanıcı adı veya şifre hatalı.";
        //                 return View(p);
        //             }
        //         }
        //     }
        //     else
        //     {
        //         return View(p);
        //     }
        // }

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
                    // Kullanıcının oturum açtığını doğrula
                    var user = await _userManager.FindByNameAsync(p.UserName);
                    var roles = await _userManager.GetRolesAsync(user);

                    if (roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ViewData["LoginResult"] = "Kullanıcı adı veya şifre hatalı.";
                    return View(p);
                }
            }
            else
            {
                return View(p);
            }
        }


        

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Kayıt Ol";
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Register(UserSignUpViewModel p)
        {
            ViewData["Title"] = "Kayıt ediliyor..";
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Email = p.Email,
                    UserName = p.UserName,
                };
                var result = await _userManager.CreateAsync(user, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Users");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);

                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}