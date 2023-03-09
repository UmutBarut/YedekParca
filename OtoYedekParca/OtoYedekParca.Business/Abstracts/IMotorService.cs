using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OtoYedekParca.Core.Utilities.Results;
using OtoYedekParca.Entity;

namespace OtoYedekParca.Business.Abstracts
{
    public interface IMotorService
    {
        public IDataResult<List<Motor>> GetAll(Expression<Func<Motor, bool>> expression = null);
        public IDataResult<Motor> GetById(Expression<Func<Motor, bool>> expression);
        public IResult Add(Motor motor);
        public IResult Delete(Motor motor);
        public IResult Update(Motor motor);
    }
}