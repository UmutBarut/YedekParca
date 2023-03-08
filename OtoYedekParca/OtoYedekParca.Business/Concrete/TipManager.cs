using OtoYedekParca.Business.Abstracts;
using OtoYedekParca.Core.Utilities.Results;
using OtoYedekParca.Dataaccess.Abstracts;
using OtoYedekParca.Entity;
using System.Linq.Expressions;


namespace OtoYedekParca.Business.Concrete
{
    public class TipManager : ITipService
    {
        private readonly ITipDal _tipDal;
        

        public TipManager(ITipDal tipDal)
        {
            _tipDal = tipDal;
            
        }

        public IResult Add(Tip tip)
        {
           _tipDal.InsertAsync(tip);
            return new SuccessResult();
        }

        public IResult Delete(Tip tip)
        {
            _tipDal.Delete(tip);
            return new SuccessResult();
        }

        public IDataResult<Tip> GetById(Expression<Func<Tip, bool>> expression)
        {
            return new SuccessDataResult<Tip>(_tipDal.GetAll(expression).First());
        }

        public IDataResult<List<Tip>> GetAll(Expression<Func<Tip, bool>> expression = null)
        {
            if(expression == null)
            {
            return new SuccessDataResult<List<Tip>>(_tipDal.GetAll());
            }
            return new SuccessDataResult<List<Tip>>(_tipDal.GetAll(expression));
        }

        public IResult Update(Tip tip)
        {
            _tipDal.Update(tip);
            return new SuccessResult();
        }
    }
}