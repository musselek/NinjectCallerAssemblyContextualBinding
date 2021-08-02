using FluentAssertions;
using IoCResolvingTests.IoCTestFixture;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using TestCommonData;
using TestModuleA;
using TestModuleB;
using TestModuleC;
using Xunit;

namespace IoCResolvingTests
{
    public class IoCResolvingTests : IClassFixture<IoCTestFixture<SUTResolving>>
    {
        private readonly IList<IConvertor> _convertes = AbstractIoCTestFixture.Kernel.GetAll<IConvertor>().ToList();

        [Fact]
        public void TestContractAConverterResolvesItsOwnImplementationOfInterface()
        {
            //Arrange
            const string ConverterName = "Test Contract AConverter";
            var converter = GetConverterByName(ConverterName);
            //act
            //assert
            (converter as TestContractAConverter).GetValue().Should().Be(110);
        }

        [Fact]
        public void TestContractBConverterResolvesItsOwnImplementationOfInterface()
        {
            //Arrange
            const string ConverterName = "Test Contract BConverter";
            var converter = GetConverterByName(ConverterName);
            //act
            //assert
            (converter as TestContractBConverter).GetValue().Should().Be(210);
        }

        [Fact]
        public void TestContractCConverterResolvesCommonImplementationOfInterface()
        {
            //Arrange
            const string ConverterName = "Test Contract CConverter";
            var converter = GetConverterByName(ConverterName);
            //act
            //assert
            (converter as TestContractCConverter).GetValue().Should().Be(10);
        }

        private IConvertor GetConverterByName(string converterName)
            => _convertes.First(x => x.Tool == converterName);
    }
}
