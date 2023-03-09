using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OtoYedekParca.Core.Utilities.Results;
using OtoYedekParca.Entity;

namespace OtoYedekParca.Business.Abstracts
{
    public interface ITip_MotorService
    {
        public IDataResult<List<Tip_Motor>> GetAll(Expression<Func<Tip_Motor, bool>> expression = null);
        public IDataResult<Tip_Motor> GetById(Expression<Func<Tip_Motor, bool>> expression);
        public IResult Add(Tip_Motor tip_Motor);
        public IResult Delete(Tip_Motor tip_Motor);
        public IResult Update(Tip_Motor tip_Motor);
    }
}