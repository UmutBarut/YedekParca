using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OtoYedekParca.ViewModels
{
    public class UserSignUpViewModel
    {
    
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Email { get; set; }
        public string AdSoyad { get; set; }
        public string PhoneNumber { get; set; }
    
    }
}