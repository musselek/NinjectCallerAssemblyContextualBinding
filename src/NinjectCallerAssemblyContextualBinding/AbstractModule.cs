using Ninject;
using Ninject.Modules;
using System;

namespace NinjectCallerAssemblyContextualBinding
{
    public abstract class AbstractModule : NinjectModule
    {
        private AbstractBinderBehavior BinderBehavior()
            => Kernel.Get<AbstractBinderBehavior>();

        public abstract void Binder();

        public sealed override void Load()
          => Binder();

        public new void Bind<T>() where T : class
          => BinderBehavior().Bind<T>(Kernel);

        public void Bind<T>(Scope scope) where T : class
            => BinderBehavior().Bind<T>(scope, Kernel);

        public new void Bind(params Type[] services)
            => BinderBehavior().Bind(Kernel, services);

        public new void Bind<T, K>() where K : class, T
            => BinderBehavior().Bind<T, K>(Kernel);
    }
}