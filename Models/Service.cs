using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XtraMileTask2.Models
{
    public class Service
    {
        public string ToCelcius(double fahrenheit)
        {
            var result = (fahrenheit - 32) * 5 / 9;
            var celcius = String.Format("{0:0.00}", result);
            return celcius;
        }

        public string DewPoint(double temperature, int humidity)
        {
            double temp;
            double humi = humidity / 100;
            temp = (temperature - 32) / 1.8;

            double ans = (temp - (14.55 + 0.114 * temp) * (1 - (0.01 * humi)) - Math.Pow(((2.5 + 0.007 * temp) * (1 - (0.01 * humi))), 3) - (15.9 + 0.117 * temp) * Math.Pow((1 - (0.01 * humi)), 14));

            double value = ans * (9.0 / 5.0);
            var result = value + 32.0;
            var resf = String.Format("{0:0.00}", result);
            return resf;
        }
    }
}
