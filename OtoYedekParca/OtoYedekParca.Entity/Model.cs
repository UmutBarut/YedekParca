using System.ComponentModel.DataAnnotations;
using OtoYedekParca.Core.Entity;

namespace OtoYedekParca.Entity
{
    public class Model : IEntity
    {
        [Key]
        public long ModelId { get; set; }
        public string ModelAdi { get; set; }
        public long TipId { get; set; }
        public long MarkaId { get; set; }
        public string? ImagePath { get; set; }
        public long Siralama { get; set; }
        public bool Pasif { get; set; }
    }
}