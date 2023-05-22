using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OtoYedekParca.Core.Entity;

namespace OtoYedekParca.Entity
{
    public class UrunGrup : IEntity
    {
        [Key]
        public int GrupId { get; set; }
        public string GrupAdi { get; set; }
        public bool Pasif { get; set; }
    }
}