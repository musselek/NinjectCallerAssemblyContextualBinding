using Ninject;
using Ninject.Extensions.NamedScope;
using System;

namespace NinjectCallerAssemblyContextualBinding
{
    public class StandardBinderBehavior : AbstractBinderBehavior
    {
        public StandardBinderBehavior(Type typeInterface) : base(typeInterface)
        {
        }

        public override void Bind<T>(IKernel Kernel)
          => Bind<T>(Scope.Transient, Kernel);

        public override void Bind<T>(Scope scope, IKernel Kernel)
        {
            switch (scope)
            {
                default:
                case Scope.Transient:
                    Kernel.Bind(typeof(T)).ToSelf();
                    break;

                case Scope.Singleton:
                    Kernel.Bind(typeof(T)).ToSelf().InSingletonScope();
                    break;

                case Scope.CallScope:
                    Kernel.Bind(typeof(T)).ToSelf().InCallScope();
                    break;
            }
        }

        public override void Bind(IKernel Kernel, params Type[] services)
        {
            foreach (var service in services)
            {
                Kernel.Bind(service).ToSelf();
            }
        }

        public override void Bind<T, K>(IKernel Kernel)
        {
            if (TryGetConverterName(typeof(T), typeof(K), out var converterName))
            {
                Kernel.Bind(typeof(T)).To(typeof(K)).When(request => IsProperConverterName(request, converterName));
            }
            else
            {
                Kernel.Bind(typeof(T)).To(typeof(K));
            }
        }
    }
}