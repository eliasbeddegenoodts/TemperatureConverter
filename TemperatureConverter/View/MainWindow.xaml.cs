using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.ComponentModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private double temperatureInKelvin;

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

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class TempConverter : IValueConverter
    {
        public ITemperatureScale TemperatureScale { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var kelvin = (double)value;

            return this.TemperatureScale.ConvertFromKelvin(kelvin).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var temperature = double.Parse((string)value);

            return this.TemperatureScale.ConvertToKelvin(temperature);
        }
    }
}
