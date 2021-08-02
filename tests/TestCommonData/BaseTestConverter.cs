using System;

namespace TestCommonData
{
    public abstract class BaseTestConverter : IConvertor
    {
        public string Tool { get; private set; }

        public BaseTestConverter(string converterIdentifier)
            => Tool = converterIdentifier;
    }
}