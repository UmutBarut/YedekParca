using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OtoYedekParca.Core.Utilities.Results;
using OtoYedekParca.Entity;

namespace OtoYedekParca.Business.Abstracts
{
    public interface IUrunService
    {
        public IDataResult<List<Urun>> GetAll(Expression<Func<Urun, bool>> expression = null);
        public IDataResult<Urun> GetById(Expression<Func<Urun, bool>> expression);
        public IResult Add(Urun urun);
        public IResult Delete(Urun urun);
        public IResult Update(Urun urun);
    }
}