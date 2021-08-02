using NinjectCallerAssemblyContextualBinding;

namespace IoCResolvingTests.IoCTestFixture
{
    public abstract class AbstractSystemUnderTest : ISystemUnderTest
    {
        public abstract string[] DLLPlugins { get; }

        public virtual AbstractBinderBehavior BinderBehavior { get;}
    }
}