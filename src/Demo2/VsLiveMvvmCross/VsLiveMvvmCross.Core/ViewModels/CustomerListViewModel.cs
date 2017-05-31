using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using VsLiveMvvmCross.Core.Models;
using VsLiveMvvmCross.Core.Services;

namespace VsLiveMvvmCross.Core.ViewModels
{
    public class CustomerListViewModel : MvxViewModel
    {
        private ICustomerService _customerService;
        private IMvxNavigationService _navigationService;
        private Guid _instance = Guid.NewGuid();

        public CustomerListViewModel(ICustomerService customerService, IMvxNavigationService navigationService)
        {
            _customerService = customerService;
            _navigationService = navigationService;
            Debug.WriteLine($"CustomerListViewModel: instance: {_instance.ToString()}: constructor");
        }

        public override void Start()
        {
            base.Start();
            Customers = _customerService.GetCustomerList();
            Debug.WriteLine($"CustomerListViewModel: instance: {_instance.ToString()}: start");
        }

        public override Task Initialize()
        {
            Debug.WriteLine($"CustomerListViewModel: instance: {_instance.ToString()}: initialize");
            return base.Initialize();
        }

        public override void Appearing()
        {
            Debug.WriteLine($"CustomerListViewModel: instance: {_instance.ToString()}: appearing");
            base.Appearing();
        }

        public override void Appeared()
        {
            Debug.WriteLine($"CustomerListViewModel: instance: {_instance.ToString()}: appeared");
            base.Appeared();
        }

        public override void Disappearing()
        {
            Debug.WriteLine($"CustomerListViewModel: instance: {_instance.ToString()}: disappearing");
            base.Disappearing();
        }

        public override void Disappeared()
        {
            Debug.WriteLine($"CustomerListViewModel: instance: {_instance.ToString()}: disappeared");
            base.Disappeared();
        }

        private ObservableCollection<Customer> _customerList;
        public ObservableCollection<Customer> Customers
        {
            get => _customerList; 
            set => SetProperty(ref _customerList, value);
        }

        private ICommand _customerSelectedCommand;
        public ICommand CustomerSelectedCommand
        {
            get
            {
                return _customerSelectedCommand ?? (_customerSelectedCommand =
                    new MvxCommand<Customer>(async (c) => await CustomerSelected(c)));

                async Task CustomerSelected(Customer customer)
                {
                    var bundle = new MvxBundle();
                    bundle.Write(new Dictionary<string, string>() { { "customerId", customer.CustomerId.ToString() } });

                    var result = await _navigationService.Navigate<EditCustomerViewModel, MvxBundle, Customer>(bundle);
                    if (result == null)
                    {
                        if (Customers.Any(c => c.CustomerId == customer.CustomerId))
                        {
                            Customers.Remove(customer);
                        }
                    }
                    else
                    {
                        customer.CustomerName = result.CustomerName;
                        customer.ContactName = result.ContactName;
                    }
                }
            }
        }

        private ICommand _addCustomerCommand;
        public ICommand AddCustomerCommand
        {
            get
            {
                return _addCustomerCommand ?? (_addCustomerCommand =
                    new MvxCommand(async () => await AddCustomerAsync()));

                async Task AddCustomerAsync()
                {
                    var result = await _navigationService.Navigate<EditCustomerViewModel, MvxBundle, Customer>(null);
                    if (result != null)
                    {
                        Customers.Add(result);
                    }
                }
            }
        }
    }
}