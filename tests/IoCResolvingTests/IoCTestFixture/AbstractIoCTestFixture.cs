using Ninject;
using NinjectCallerAssemblyContextualBinding;
using System;
using System.IO;
using System.Linq;

namespace IoCResolvingTests.IoCTestFixture
{
    public abstract class AbstractIoCTestFixture : IDisposable
    {
        public static StandardKernel Kernel { get; } = new StandardKernel(new NinjectSettings() { LoadExtensions = false });
        private bool isDisposed;

        public AbstractIoCTestFixture(AbstractBinderBehavior binderBehavior, string[] dllPlugins)
        {
            var pluginMissed = dllPlugins.Where(x => !File.Exists(x)).Select(x => x);
            if ( pluginMissed.Any())
            {
                var files = string.Join(',', pluginMissed.ToList());

                throw new FileNotFoundException(files);
            }

            Kernel.Bind<AbstractBinderBehavior>().ToConstant(binderBehavior).InSingletonScope();
            Kernel.Load(dllPlugins);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing)
            {
                Kernel.Dispose();
            }
            isDisposed = true;
        }

        ~AbstractIoCTestFixture()
            => Dispose(false);
    }
}