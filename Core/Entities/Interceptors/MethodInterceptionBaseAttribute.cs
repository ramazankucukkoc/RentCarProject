using Castle.DynamicProxy;
using System;

namespace Core.Entities.Utilities.Interceptors
{
    //bu kodlar bize attributımızn methodda fieldda inherit edebilecegimizi söylüyor..
    //  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, kısmı metotlara ve class bu attiribute ekleyebilirsin demektir.
    //AllowMultiple = true, birden fazla yere ekleyebilirsin ,kullanabilirsin anlamında True
    //Inherited = true)
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

}
