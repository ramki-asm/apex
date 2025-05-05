// ViewModels/CustomerViewModel.cs
using APEX.Common.Helpers;
using Common.Models;
using Common.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace HG_Laser.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private ObservableCollection<CustomerModel> _customers;
        private CustomerModel _selectedCustomer;

        public ObservableCollection<CustomerModel> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public CustomerModel SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        public CustomerViewModel()
        {
           
            SelectedCustomer = Customers.FirstOrDefault();
        }

        public void AddCustomer(CustomerModel customer)
        {
            Customers.Add(customer);
        }

        public void RemoveCustomer(int id)
        {
            var customerToRemove = Customers.FirstOrDefault(c => c.Id == id);
            if (customerToRemove != null)
            {
                Customers.Remove(customerToRemove);
            }
        }
    }
}