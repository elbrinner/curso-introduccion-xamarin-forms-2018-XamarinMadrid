using System;
using Autofac;
using XamarinMadrid2018.Services.Hitbtc;
using XamarinMadrid2018.Services.Navigation;
namespace XamarinMadrid2018.ViewModels.Base
{
    public class ViewModelLocator
    {
        readonly IContainer container;
        private static readonly ViewModelLocator instance = new ViewModelLocator();

        public static ViewModelLocator Instance
        {
            get
            {
                return instance;
            }
        }

        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<HitbtcWebService>().As<IHitbtcWebService>();

            builder.RegisterType<HomeViewModel>();
            builder.RegisterType<DetailViewModel>();
            if (container != null)
            {
                container.Dispose();
            }

            container = builder.Build();

        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return container.Resolve(type);
        }
    }
}
