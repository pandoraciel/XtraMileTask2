using System;
using XtraMileTask2.Models;
using Xunit;

namespace TestXtraMileTask2
{
    public class ServiceTest
    {
        [Theory]
        [InlineData(33.32)]
        [InlineData(55.42)]
        [InlineData(62.30)]
        [InlineData(33.3)]
        [InlineData(55)]
        [InlineData(6)]
        [InlineData(6/4)]
        [InlineData(0)]
        public void ToCelciusPassingTest(double id)
        {
            Service service = new Service();
            var result = service.ToCelcius(id);
            Assert.Equal(String.Format("{0:0.00}", result), result);
        }

        [Theory]
        [InlineData(33.32, 20)]
        [InlineData(55.42, 30)]
        [InlineData(62.30, 50)]
        [InlineData(33.3, 10)]
        [InlineData(55, 40)]
        [InlineData(6, 5)]
        [InlineData(5, 50)]
        [InlineData(0, 1)]
        public void DewPassingTest(double temperature, int humidity)
        {

            Service service = new Service();
            var result = service.DewPoint(temperature, humidity);
            Assert.Equal(String.Format("{0:0.00}", result), result);
        }
    }
}
