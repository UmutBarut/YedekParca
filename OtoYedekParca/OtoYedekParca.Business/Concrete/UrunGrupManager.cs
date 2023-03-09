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
    public class UrunGrupManager : IUrunGrupService
    {
        private readonly IUrunGrupDal _urunGrupDal;

        public UrunGrupManager(IUrunGrupDal urunGrupDal)
        {
            _urunGrupDal = urunGrupDal;
        }

        public IResult Add(UrunGrup urunGrup)
        {
            _urunGrupDal.InsertAsync(urunGrup);
            return new SuccessResult();
        }

        public IResult Delete(UrunGrup urunGrup)
        {
            _urunGrupDal.Delete(urunGrup);
            return new SuccessResult();
        }

        public IDataResult<List<UrunGrup>> GetAll(Expression<Func<UrunGrup, bool>> expression = null)
        {
            if(expression == null)
            {
            return new SuccessDataResult<List<UrunGrup>>(_urunGrupDal.GetAll());
            }
            return new SuccessDataResult<List<UrunGrup>>(_urunGrupDal.GetAll(expression));
        }

        public IDataResult<UrunGrup> GetById(Expression<Func<UrunGrup, bool>> expression)
        {
            return new SuccessDataResult<UrunGrup>(_urunGrupDal.GetAll(expression).FirstOrDefault());
        }


        public IResult Update(UrunGrup urunGrup)
        {
            _urunGrupDal.Update(urunGrup);
            return new SuccessResult();
        }
    }
}