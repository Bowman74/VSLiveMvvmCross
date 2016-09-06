using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using VsLiveMvvmCross.Core.Models;
using VsLiveMvvmCross.Core.Services;

namespace VsLiveMvvmCross.Core.ViewModels
{
    public class CustomerListViewModel : BaseViewModel
    {
        private ICustomerService _customerService;

        public CustomerListViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public override void Start()
        {
            base.Start();
            Customers = _customerService.GetCustomerList();
            AddCustomer();
        }

        private ObservableCollection<Customer> _customerList;
        public ObservableCollection<Customer> Customers
        {
            get { return _customerList; }
            set
            {
                _customerList = value;
                RaisePropertyChanged(() => Customers);
            }
        }

        private ICommand _customerSelectedCommand;
        public ICommand CustomerSelectedCommand
        {
            get
            {
                return _customerSelectedCommand ?? (_customerSelectedCommand =
                    new MvxCommand<Customer>((customer) => { CustomerSelected(customer); }));
            }
        }

        public void CustomerSelected(Customer customer)
        {
            ShowViewModel<EditCustomerViewModel>(new { customerId = customer.CustomerId });
        }

        private ICommand _addCustomerCommand;
        public ICommand AddCustomerCommand
        {
            get
            {
                return _addCustomerCommand ?? (_addCustomerCommand =
                    new MvxCommand(AddCustomer));
            }
        }

        public void AddCustomer()
        {
            var bundle = new MvxBundle();
            bundle.Write(new System.Collections.Generic.Dictionary<string, string>() { { "customerId", "1234" }});
            ShowViewModel<EditCustomerViewModel>(bundle);
        }
    }
}