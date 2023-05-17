using OtoYedekParca.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace OtoYedekParca.Components
{
    public class Aside : ViewComponent
    {
        
        private readonly UserManager<User> _userManager;

        public Aside(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View("_Toolbar",user);
        }
    }
}