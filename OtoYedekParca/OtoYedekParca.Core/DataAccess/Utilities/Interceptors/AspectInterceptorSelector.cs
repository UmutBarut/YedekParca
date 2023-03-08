using OtoYedekParca.Core.Utilities.Interceptors;
using System.Reflection;
using Castle.DynamicProxy;

namespace OtoYedekParca.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] ınterceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new PerformanceAspect(5));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
