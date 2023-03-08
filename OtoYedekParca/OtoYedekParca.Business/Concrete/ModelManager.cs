using OtoYedekParca.Business.Abstracts;
using OtoYedekParca.Core.Utilities.Results;
using OtoYedekParca.Dataaccess.Abstracts;
using OtoYedekParca.Entity;
using System.Linq.Expressions;


namespace OtoYedekParca.Business.Concrete
{
    public class ModelManager : IModelService
    {
        private readonly IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }
        public IResult Add(Model model)
        {
            _modelDal.InsertAsync(model);
            return new SuccessResult();
        }

        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult();
        }

        public IDataResult<Model> GetById(Expression<Func<Model, bool>> expression)
        {
            return new SuccessDataResult<Model>(_modelDal.GetAll(expression).First());
        }

        public IDataResult<List<Model>> GetAll(Expression<Func<Model, bool>> expression = null)
        {
            if(expression == null)
            {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
            }
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(expression));
        }

        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult();
        }
    }
}