using OtoYedekParca.Core.Utilities.Results;
using OtoYedekParca.Entity;
using System.Linq.Expressions;


namespace OtoYedekParca.Business.Abstracts
{
    public interface IMarkaService
    {
        public IDataResult<List<Marka>> GetAll(Expression<Func<Marka, bool>> expression = null);
        public IDataResult<Marka> GetById(Expression<Func<Marka, bool>> expression);
        public IResult Add(Marka marka);
        public IResult Delete(Marka marka);
        public IResult Update(Marka marka);
    }
}