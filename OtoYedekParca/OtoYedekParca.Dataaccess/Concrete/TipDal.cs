using OtoYedekParca.Core.Dataaccess.EntityFramework;
using OtoYedekParca.Dataaccess.Abstracts;
using OtoYedekParca.Dataaccess.Concrete.Contexts;
using OtoYedekParca.Entity;

namespace OtoYedekParca.Dataaccess.Concrete
{
    public class TipDal : EfEntityRepositoryBase<Tip, ApplicationDbContext>, ITipDal
    {
         
    }
}