using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{

    public interface IThemperatureScale
    {
        string Name { get; }

        double ConvertToKhelvin(double temperature);
        double ConvertFromKhelvin(double temperature);
    }

    public class KhelvinTemperatureScale : IThemperatureScale
    {
        public string Name => "Kelvin";

        public double ConvertFromKhelvin(double temperature)
        {
            return temperature;
        }

        public double ConvertToKhelvin(double temperature)
        {
            return temperature;
        }
    }

    public class ChelsiusTemperatureScale : IThemperatureScale
    {
        public string Name => "Celsius";

        public double ConvertFromKhelvin(double temperature)
        {
            return temperature - 273.15;
        }

        public double ConvertToKhelvin(double temperature)
        {
            return temperature + 273.15;
        }
    }

    public class FahhrenheitTemperatureScale : IThemperatureScale
    {
        public string Name => "Fahrenheit";

        public double ConvertFromKhelvin(double temperature)
        {
            return temperature * 9 / 5 - 459.67;
        }

        public double ConvertToKhelvin(double temperature)
        {
            return temperature + (459.67) * 5 / 9;
        }
    }
}
