// ViewModels/CustomerViewModel.cs
 
using Common.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace UI.ViewModels
{
    public class CustomerViewModel : BindableBase
    {
        private ObservableCollection<CustomerModel> _customers;
        private CustomerModel _selectedCustomer;

        public ObservableCollection<CustomerModel> Customers
        {
            get => _customers;
            set=> SetProperty(ref _customers, value);
        }

        public CustomerModel SelectedCustomer
        {
            get => _selectedCustomer;
            set=> SetProperty(ref _selectedCustomer, value);
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