using Microsoft.AspNetCore.Identity;

namespace OtoYedekParca.Entity
{
    public class User : IdentityUser
    {
        public string AdSoyad { get; set; }
        public bool Pasif { get; set; }
    }
}