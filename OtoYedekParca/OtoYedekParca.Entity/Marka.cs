using System.ComponentModel.DataAnnotations;
using OtoYedekParca.Core.Entity;

namespace OtoYedekParca.Entity
{
    public class Marka : IEntity
    {
        [Key]
        public int MarkaId { get; set; }
        public string MarkaAdi { get; set; }
        public string? ImagePath { get; set; }
        public int Siralama { get; set; }
        public bool Pasif { get; set; }
    }
}