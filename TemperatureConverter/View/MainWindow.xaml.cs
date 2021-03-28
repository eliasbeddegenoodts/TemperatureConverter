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

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var kelvin = slider.Value;
            var celsius = kelvin - 273.15;
            var fahrenheit = celsius * 1.8 + 32;

            var kelvinString = kelvin.ToString();
            var fahrenheitString = fahrenheit.ToString();

            fahrenheitTextBox.Text = fahrenheitString;
        }
    }

    public class CelsiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Convert will be called to convert the slider value (Kelvin) into a text box value (Celsius).
            //Mind the types: the slider's value is a double, whereas the text box expects a string.
            var kelvin = (double)value;
            var celsius = kelvin - 273.15;

            return celsius.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // ConvertBack is expected to convert the text box value (a string denoting a Celsius 
            // temperature) into a slider value (a double representing the same temperature expressed in Kelvin).
            var celsius = double.Parse((string)value);
            var kelvin = celsius + 273.15;

            return kelvin;
        }
    }
}
