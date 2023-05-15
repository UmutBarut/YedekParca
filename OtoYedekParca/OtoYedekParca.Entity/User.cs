using Microsoft.AspNetCore.Identity;

namespace OtoYedekParca.Entity
{
    public class User : IdentityUser
    {
        public string? ImagePath { get; set; }
        public bool IsAdmin { get; set; }
        public bool Pasif { get; set; }
    }
}