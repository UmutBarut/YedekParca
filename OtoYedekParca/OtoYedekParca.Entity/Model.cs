using System.ComponentModel.DataAnnotations;
using OtoYedekParca.Core.Entity;

namespace OtoYedekParca.Entity
{
    public class Model : IEntity
    {
        [Key]
        public int ModelId { get; set; }
        public string ModelAdi { get; set; }
        public int TipId { get; set; }
        public int MarkaId { get; set; }
        public string? ImagePath { get; set; }
        public int Siralama { get; set; }
        public bool Pasif { get; set; }
    }
}