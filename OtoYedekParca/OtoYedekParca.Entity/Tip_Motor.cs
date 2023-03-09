using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OtoYedekParca.Core.Entity;

namespace OtoYedekParca.Entity
{
    public class Tip_Motor : IEntity
    {
        [Key]
        public int Tip_MotorId { get; set; }
        public int MotorId { get; set; }
        public int TipId { get; set; }
    }
}