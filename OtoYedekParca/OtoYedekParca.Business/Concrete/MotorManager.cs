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
    public class MotorManager : IMotorService
    {
        private readonly IMotorDal _motorDal;

        public MotorManager( IMotorDal motorDal)
        {
            _motorDal = motorDal;
        }

        public IResult Add(Motor motor)
        {
            _motorDal.InsertAsync(motor);
            return new SuccessResult();
        }

        public IResult Delete(Motor motor)
        {
            _motorDal.Delete(motor);
            return new SuccessResult();
        }

        public IDataResult<List<Motor>> GetAll(Expression<Func<Motor, bool>> expression = null)
        {
            if(expression == null)
            {
            return new SuccessDataResult<List<Motor>>(_motorDal.GetAll());
            }
            return new SuccessDataResult<List<Motor>>(_motorDal.GetAll(expression));
        }

        public IDataResult<Motor> GetById(Expression<Func<Motor, bool>> expression)
        {
            return new SuccessDataResult<Motor>(_motorDal.GetAll(expression).First());
        }

        public IResult Update(Motor motor)
        {
             _motorDal.Update(motor);
            return new SuccessResult();
        }
    }
}