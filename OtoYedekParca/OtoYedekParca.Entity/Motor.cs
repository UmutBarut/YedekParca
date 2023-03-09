using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OtoYedekParca.Core.Entity;

namespace OtoYedekParca.Entity
{
    public class Motor : IEntity
    {
        [Key]
        public int MotorId { get; set; }
        public string MotorAdi { get; set; }
        public string MotorGucu { get; set; }
        public string MotorHacmi { get; set; }
        public int SilindirSayisi { get; set; }
        public string Yakit { get; set; }
        public bool Pasif { get; set; }

    }
}