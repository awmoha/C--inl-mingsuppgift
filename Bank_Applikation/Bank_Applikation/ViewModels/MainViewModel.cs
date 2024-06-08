using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Generic;
using Bank_Applikation.Models;

namespace Bank_Applikation.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Customer> Customers { get; private set; } = new ObservableCollection<Customer>();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Här kan du lägga till metoder för att hantera affärslogik
        // MainViewModel
        public void AddCustomer(string name, long personalNumber)
        {
            var newCustomer = new Customer(name, personalNumber);
            Customers.Add(newCustomer);
            OnPropertyChanged(nameof(Customers));
        }

    }
}
