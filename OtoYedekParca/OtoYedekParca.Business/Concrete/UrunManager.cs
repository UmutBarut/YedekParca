using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OtoYedekParca.Business.Abstracts;
using OtoYedekParca.Core.Utilities.Results;
using OtoYedekParca.Dataaccess.Abstracts;
using OtoYedekParca.Entity;

namespace OtoYedekParca.Business.Concrete
{
    public class UrunManager : IUrunService
    {
        private readonly IUrunDal _urunDal;

        public UrunManager(IUrunDal urunDal)
        {
            _urunDal = urunDal;
        }

        public IResult Add(Urun urun)
        {
           _urunDal.InsertAsync(urun);
           return new SuccessResult();
        }

        public IResult Delete(Urun urun)
        {
           _urunDal.Delete(urun);
           return new SuccessResult();
        }

        public IDataResult<List<Urun>> GetAll(Expression<Func<Urun, bool>> expression = null)
        {
            if(expression == null)
            {
            return new SuccessDataResult<List<Urun>>(_urunDal.GetAll());
            }
            return new SuccessDataResult<List<Urun>>(_urunDal.GetAll(expression));
        }

        public IDataResult<Urun> GetById(Expression<Func<Urun, bool>> expression)
        {
            return new SuccessDataResult<Urun>(_urunDal.GetAll(expression).First());
        }

        public IResult Update(Urun urun)
        {
            _urunDal.Update(urun);
           return new SuccessResult();
        }
    }
}