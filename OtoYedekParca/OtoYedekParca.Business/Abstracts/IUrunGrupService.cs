using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OtoYedekParca.Core.Utilities.Results;
using OtoYedekParca.Entity;

namespace OtoYedekParca.Business.Abstracts
{
    public interface IUrunGrupService
    {
        public IDataResult<List<UrunGrup>> GetAll(Expression<Func<UrunGrup, bool>> expression = null);
        public IDataResult<UrunGrup> GetById(Expression<Func<UrunGrup, bool>> expression);
        public IResult Add(UrunGrup urunGrup);
        public IResult Delete(UrunGrup urunGrup);
        public IResult Update(UrunGrup urunGrup);
    }
}