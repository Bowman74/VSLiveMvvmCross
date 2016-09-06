using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VsLiveMvvmCross.Core.Models;

namespace VsLiveMvvmCross.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private string _firstCustomerGuid = "a27b5bfb-535a-42bd-b1a6-afbec79c8fef";
        private string _secondCustomerGuid = "cf9d052f-7619-4b20-b38b-62c7a71e0d18";
        private ObservableCollection<Customer> _customerStore;

        public ObservableCollection<Customer> GetCustomerList()
        {
            return GetCustomerStore();
        }

        public Customer GetCustomerById(Guid customerId)
        {
            //todo: Add code to return a customer
            return GetCustomerStore().SingleOrDefault(c => c.CustomerId == customerId);
        }

        private ObservableCollection<Customer> GetCustomerStore()
        {
            if (_customerStore == null)
            {
                _customerStore = new ObservableCollection<Customer>
                {
                    new Customer
                    {
                        CustomerId = Guid.Parse(_firstCustomerGuid),
                        CustomerName = "Acme Toy Company",
                        ContactName = "Drop Dead Fred"
                    },
                    new Customer
                    {
                        CustomerId = Guid.Parse(_secondCustomerGuid),
                        CustomerName = "Wile E's Rube Goldberg Machines",
                        ContactName = "Wile E. Coyote"
                    }
                };
            }
            return _customerStore;
        }

        public Customer CreateNewCustomer()
        {
            return new Customer
            {
                CustomerId = Guid.NewGuid()
            };
        }
    }
}