using Ninject;
using Ninject.Activation;
using System;
using System.Linq;

namespace NinjectCallerAssemblyContextualBinding
{
    public abstract class AbstractBinderBehavior
    {
        protected readonly Type _notContextualInterface;

        public AbstractBinderBehavior(Type notContextualInterface)
            => _notContextualInterface = notContextualInterface;

        protected virtual bool TryGetConverterName(Type from, Type to, out string converterName)
        {
            converterName = string.Empty;

            if (from.IsNotContextualInterface(_notContextualInterface) || to.IsNotContextualInterface(_notContextualInterface))
            {
                return false;
            }

            var converterTypes = to.Assembly.GetTypes()
                                   .Where(t => _notContextualInterface.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                                   .Distinct();

            converterName = converterTypes.HasData() && converterTypes.Count() == 1
                ? converterTypes.First().Name
                : string.Empty;

            return converterName.HasValue();
        }

        protected virtual bool IsProperConverterName(IRequest request, string converterName)
        {
            var currentReqest = request;
            bool isProperConverterName;
            do
            {
                isProperConverterName = currentReqest?.Target?.Member?.DeclaringType?.Name == converterName;
                currentReqest = currentReqest?.ParentRequest;
            } while (isProperConverterName == false && currentReqest is not null);

            return isProperConverterName;
        }

        public abstract void Bind<T>(IKernel standardKernel) where T : class;

        public abstract void Bind<T>(Scope scope, IKernel standardKernel) where T : class;

        public abstract void Bind(IKernel standardKernel, params Type[] services);

        public abstract void Bind<T, K>(IKernel standardKernel) where K : class, T;
    }
}