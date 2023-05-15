using System.ComponentModel.DataAnnotations;

namespace OtoYedekParca.ViewModels
{
    public class UserSignInViewModel
    {
       
        [Required(ErrorMessage = "Lütfen Kullanıcı adınızı girin")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Lütfen şifrenizi girin")]
        public string Password { get; set; }

    }
}