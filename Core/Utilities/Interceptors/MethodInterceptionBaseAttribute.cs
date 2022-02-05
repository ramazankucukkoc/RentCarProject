
using Castle.DynamicProxy;
using System;

namespace Core.Entities.Utilities.Interceptors
{
    //bu kodlar bize attributımızn methodda fieldda inherit edebilecegimizi söylüyor..
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

}
