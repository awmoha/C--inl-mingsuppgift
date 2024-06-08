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
using Bank_Applikation.Models;
using Bank_Applikation.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409


namespace Bank_Applikation
{
    public sealed partial class MainPage : Page
    {
        private MainViewModel viewModel;

        public MainPage()
        {
            this.InitializeComponent();

            // Instansiera MainViewModel
            viewModel = new MainViewModel();

            // Lägg till några kunder för teständamål
         
            
            // Sätt DataContext till din MainViewModel
            DataContext = viewModel;
        }
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            // Hämta namn och personnummer från textfälten
            string name = NameTextBox.Text;
            long personalNumber = long.Parse(PersonalNumberTextBox.Text);

            // Anropa AddCustomer-metoden i MainViewModel
            viewModel.AddCustomer(name, personalNumber);
        }
    }
}

