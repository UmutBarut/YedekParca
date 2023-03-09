using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OtoYedekParca.Core.Dataaccess.EntityFramework;
using OtoYedekParca.Dataaccess.Abstracts;
using OtoYedekParca.Dataaccess.Concrete.Contexts;
using OtoYedekParca.Entity;

namespace OtoYedekParca.Dataaccess.Concrete
{
    public class UrunGrupDal : EfEntityRepositoryBase<UrunGrup, ApplicationDbContext>,IUrunGrupDal
    {
        
    }
}