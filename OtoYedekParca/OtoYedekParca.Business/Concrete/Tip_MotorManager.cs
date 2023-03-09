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
    public class Tip_MotorManager : ITip_MotorService
    {
        private readonly ITip_MotorDal _tip_MotorDal;

        public Tip_MotorManager(ITip_MotorDal tip_MotorDal)
        {
            _tip_MotorDal = tip_MotorDal;
        }

        public IResult Add(Tip_Motor tip_Motor)
        {
           _tip_MotorDal.InsertAsync(tip_Motor);
           return new SuccessResult();
        }

        public IResult Delete(Tip_Motor tip_Motor)
        {
            _tip_MotorDal.Delete(tip_Motor);
           return new SuccessResult();
        }

         public IDataResult<List<Tip_Motor>> GetAll(Expression<Func<Tip_Motor, bool>> expression = null)
        {
            if(expression == null)
            {
            return new SuccessDataResult<List<Tip_Motor>>(_tip_MotorDal.GetAll());
            }
            return new SuccessDataResult<List<Tip_Motor>>(_tip_MotorDal.GetAll(expression));
        }

         public IDataResult<Tip_Motor> GetById(Expression<Func<Tip_Motor, bool>> expression)
        {
            return new SuccessDataResult<Tip_Motor>(_tip_MotorDal.GetAll(expression).First());
        }

        public IResult Update(Tip_Motor tip_Motor)
        {
            _tip_MotorDal.Update(tip_Motor);
           return new SuccessResult();
        }
    }
}