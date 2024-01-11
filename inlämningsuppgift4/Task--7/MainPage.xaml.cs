using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Task__7
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
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
    }
}