using NinjectCallerAssemblyContextualBinding;

namespace IoCResolvingTests.IoCTestFixture
{
    public interface ISystemUnderTest
    {
        string[] DLLPlugins { get; }
        AbstractBinderBehavior BinderBehavior { get; }
    }
}