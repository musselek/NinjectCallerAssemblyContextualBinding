using Ninject;
using Ninject.Modules;
using System;

namespace NinjectCallerAssemblyContextualBinding
{
    public abstract class AbstractModule : NinjectModule
    {
        private readonly Lazy<AbstractBinderBehavior> _binderBehavior;

        public AbstractModule()
            => _binderBehavior = new(Kernel.Get<AbstractBinderBehavior>());

        public abstract void Binder();

        public sealed override void Load()
          => Binder();

        public new void Bind<T>() where T : class
          => _binderBehavior.Value.Bind<T>(Kernel);

        public void Bind<T>(Scope scope) where T : class
            => _binderBehavior.Value.Bind<T>(scope, Kernel);

        public new void Bind(params Type[] services)
            => _binderBehavior.Value.Bind(Kernel, services);

        public new void Bind<T, K>() where K : class, T
            => _binderBehavior.Value.Bind<T, K>(Kernel);
    }
}