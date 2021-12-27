using XtraMileTask2.Controllers;
using Xunit;

namespace TestXtraMileTask2
{
    public class CrcControllerTest
    {
        
        [Fact]
        public void GetCountryPassingTest()
        {
            CrcController crc = new CrcController();
            var result = crc.GetCountry();
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(150)]
        [InlineData(230)]
        public void GetRegionPassingTest(int id)
        {
            CrcController crc = new CrcController();
            var result = crc.GetRegion(id);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(110)]
        [InlineData(225)]
        [InlineData(450)]
        [InlineData(950)]
        [InlineData(1900)]
        [InlineData(3888)]
        public void GetCityPassingTest(int id)
        {
            CrcController crc = new CrcController();
            var result = crc.GetCity(id);
            Assert.NotNull(result);
        }
    }
}
