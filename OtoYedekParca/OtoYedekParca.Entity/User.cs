using Microsoft.AspNetCore.Identity;
using OtoYedekParca.Core.Entity;

namespace OtoYedekParca.Entity
{
     [Serializable]
    public class User : IdentityUser , IEntity
    {
        public string? ImagePath { get; set; }
        public bool IsAdmin { get; set; }
        public bool Pasif { get; set; }
    }
}