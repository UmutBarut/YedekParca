
using System.ComponentModel.DataAnnotations;
using OtoYedekParca.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OtoYedekParca.Entity
{
    public class Tip : IEntity
    {
        [Key]
        public long TipId { get; set; }
        public string TipAdi { get; set; }
        public long MarkaId { get; set; }
        public long Siralama { get; set; }
        public bool Pasif { get; set; }
    }
}