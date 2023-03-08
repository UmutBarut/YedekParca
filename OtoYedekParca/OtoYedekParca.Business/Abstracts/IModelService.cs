using OtoYedekParca.Core.Utilities.Results;
using OtoYedekParca.Entity;
using System.Linq.Expressions;


namespace OtoYedekParca.Business.Abstracts
{
    public interface IModelService
    {
        public IDataResult<List<Model>> GetAll(Expression<Func<Model, bool>> expression = null);
        public IDataResult<Model> GetById(Expression<Func<Model, bool>> expression);
        public IResult Add(Model model);
        public IResult Delete(Model model);
        public IResult Update(Model model);
    }
}