using System.ComponentModel.DataAnnotations;
using OtoYedekParca.Entity;

namespace OtoYedekParca.ViewModels
{
    public class AccountViewModel
    {
       
       
    [Display(Name = "Eski E-mailiniz")]
    public string OldEmail { get; set; }
    [Display(Name = "Yeni E-mailiniz")]
    public string NewEmail { get; set; }
   


        public string UserName { get; set; }
        public string Email { get; set; }
        public string? ImagePath { get; set; }
        public string? PhoneNumber { get; set; }
       
    }
}