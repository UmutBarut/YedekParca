using Autofac;
using Autofac.Extras.DynamicProxy;
using OtoYedekParca.Core.Utilities.Interceptors;
using OtoYedekParca.Dataaccess.Abstracts;
using OtoYedekParca.Dataaccess.Concrete;
using Castle.DynamicProxy;
using OtoYedekParca.Business.Concrete;
using OtoYedekParca.Business.Abstracts;
using OtoYedekParca.Core.Utilities.Helpers.File;

namespace OtoYedekParca.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
         
            builder.RegisterType<MarkaManager>().As<IMarkaService>().SingleInstance();
            builder.RegisterType<MarkaDal>().As<IMarkaDal>().SingleInstance();

            builder.RegisterType<ModelManager>().As<IModelService>().SingleInstance();
            builder.RegisterType<ModelDal>().As<IModelDal>().SingleInstance();

            builder.RegisterType<TipManager>().As<ITipService>().SingleInstance();
            builder.RegisterType<TipDal>().As<ITipDal>().SingleInstance();

            builder.RegisterType<FileManager>().As<IFileService>().SingleInstance();
            builder.RegisterType<FileHelper>().As<IFileHelper>().SingleInstance();
            
            builder.RegisterType<UrunGrupManager>().As<IUrunGrupService>().SingleInstance();
            builder.RegisterType<UrunGrupDal>().As<IUrunGrupDal>().SingleInstance();

            builder.RegisterType<UrunManager>().As<IUrunService>().SingleInstance();
            builder.RegisterType<UrunDal>().As<IUrunDal>().SingleInstance();


            builder.RegisterType<MotorManager>().As<IMotorService>().SingleInstance();
            builder.RegisterType<MotorDal>().As<IMotorDal>().SingleInstance();

            builder.RegisterType<Tip_MotorManager>().As<ITip_MotorService>().SingleInstance();
            builder.RegisterType<Tip_MotorDal>().As<ITip_MotorDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            });
        }
    }
}