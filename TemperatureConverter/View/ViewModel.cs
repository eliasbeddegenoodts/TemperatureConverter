using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public class ConverterViewModel : INotifyPropertyChanged
    {
        private double temperatureInKelvin;

        public event PropertyChangedEventHandler PropertyChanged;

        public double TemperatureInKelvin
        {
            get
            {
                return temperatureInKelvin;
            }
            set
            {
                temperatureInKelvin = value;

                //if (PropertyChanged != null)
                //{
                //    PropertyChanged(this, new PropertyChangedEventArgs(nameof(TemperatureInKelvin)));
                //    // this = indicates whose property has been changed
                //    // PropertyChangedEventArgs = takes name of property that got changed
                //    // This is a string, and we could have simply put "TemperatureInKelvin".
                //    // However, using nameof(TemperatureInKelvin) is much more robust: if we were to refactor 
                //    // - rename TemperatureInKelvin, the IDE understands this argument has to change too.
                //    // If it had been a simple string, the IDE would simply ignore it during refactoring.
                //}
                // vervangen door

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TemperatureInKelvin)));
            }
        }
    }
}
