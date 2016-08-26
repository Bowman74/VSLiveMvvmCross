using System;
using System.Collections.Generic;
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
        }

        private IList<Customer> _customerList;
        public IList<Customer> Customers
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
    }
}