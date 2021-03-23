using System;
using System.Collections.Generic;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConvertToCelsius(object sender, RoutedEventArgs e)
        {
            var fahrenheitText = celciusTextBox.Text;
            var fahrenheitToDouble = double.Parse(fahrenheitText);
            var fahrenheitToCelcius = (fahrenheitToDouble - 32) / 1.8;
            var celciusToString = fahrenheitToCelcius.ToString();
            celciusTextBox.Text = celciusToString;
        }

        private void ConvertToFahrenheit(object sender, RoutedEventArgs e)
        {
            var celciusText = fahrenheitTextbox.Text;
            var celciusToDouble = double.Parse(celciusText);
            var celciusToFahrenheit = celciusToDouble * 1.8 + 32;
            var fahrenheitToString = celciusToFahrenheit.ToString();
            fahrenheitTextbox.Text = fahrenheitToString;
        }
    }
}
