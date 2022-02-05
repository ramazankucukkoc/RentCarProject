using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Entities.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DepencdencyResolvers.Autofac
{
  public  class AutofacBusinessModule:Module
    {//Module sınıfı autofac sagladı bır sınıf ver WebAPI deki startuptaki işlemleri yapmamızı saglıyor
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<CarImageManager>().As<ICarImagesService>().SingleInstance();
            builder.RegisterType<EfCarImagesDal>().As<ICarImagesDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
              .EnableInterfaceInterceptors(new ProxyGenerationOptions()
               {
                   Selector = new AspectInterceptorSelector()
               }).SingleInstance();
        }
    }
}
