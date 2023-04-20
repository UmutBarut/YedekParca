using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OtoYedekParca.Core.Entity;

namespace OtoYedekParca.Entity
{
    public class Urun : IEntity
    {
        [Key]
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string Barkod { get; set; }
        public string? ImagePath { get; set; }
        public string Olcu { get; set; }
        public string Aciklama { get; set; }
        public bool Pasif { get; set; }
        public int Fiyat { get; set; }
        public int MaxStok { get; set; }
        public int MinStok { get; set; }
        public int Miktar { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public int GrupId { get; set; }
    }
}