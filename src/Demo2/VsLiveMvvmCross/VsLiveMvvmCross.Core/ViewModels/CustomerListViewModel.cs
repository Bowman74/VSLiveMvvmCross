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

        public CustomerListViewModel(ICustomerService customerService, IMvxNavigationService navigationService)
        {
            _customerService = customerService;
            _navigationService = navigationService;
        }

        public override void Start()
        {
            base.Start();
            Customers = _customerService.GetCustomerList();
        }

        public override Task Initialize()
        {
            return base.Initialize();
        }

        public override void Appearing()
        {
            base.Appearing();
        }

        public override void Appeared()
        {
            base.Appeared();
        }

        public override void Disappearing()
        {
            base.Disappearing();
        }

        public override void Disappeared()
        {
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