using OtoYedekParca.Core.Utilities.Results;
using OtoYedekParca.Entity;
using System.Linq.Expressions;


namespace OtoYedekParca.Business.Abstracts
{
    public interface ITipService 
    {
        public IDataResult<List<Tip>> GetAll(Expression<Func<Tip, bool>> expression = null);
        public IDataResult<Tip> GetById(Expression<Func<Tip, bool>> expression);
        public IResult Add(Tip tip);
        public IResult Delete(Tip tip);
        public IResult Update(Tip tip);
    }
}