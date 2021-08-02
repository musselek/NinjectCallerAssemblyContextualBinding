namespace IoCResolvingTests.IoCTestFixture
{
    public sealed class IoCTestFixture<T> : AbstractIoCTestFixture
        where T : class, ISystemUnderTest, new()
    {
        private static readonly T _sut = new();

        public IoCTestFixture() : base(_sut.BinderBehavior, _sut.DLLPlugins)
        { }
    }
}