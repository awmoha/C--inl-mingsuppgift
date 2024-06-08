using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace inlämningsuppgift4_Task_7_8
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            txtFahrenheit.KeyDown += TxtFahrenheit_KeyDown;
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtFahrenheit.Text, out double fahrenheit))
            {
                double celsius = (5.0 / 9.0) * (fahrenheit - 32);
                txtResult.Text = $"Converted Temperature: {celsius:F2} °C";
            }
            else
            {
                txtResult.Text = "Invalid input. Please enter a valid Fahrenheit temperature.";
            }
        }

        private void TxtFahrenheit_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // Kontrollera om tangenten är en siffra eller Backspace
            if (!(char.IsDigit((char)e.Key) || (e.Key == Windows.System.VirtualKey.Back)))
            {
                e.Handled = true; // Ignorera tangenttrycket om det inte är en siffra eller Backspace
            }
        }
    }
}
