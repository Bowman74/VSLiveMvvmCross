using System;
using System.Collections.ObjectModel;
using System.Linq;
using MvvmCross.Plugins.Json;
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
            var serializer = new MvxJsonConverter();
            return serializer.DeserializeObject<ObservableCollection<Customer>>(serializer.SerializeObject(GetCustomerStore()));
        }

        public Customer GetCustomerById(Guid customerId)
        {
            var storeCustomer = GetCustomerStore().SingleOrDefault(c => c.CustomerId == customerId);

            // for the fake service just make a quick and dirty copy of the customer.
            if (storeCustomer != null)
            {
                var serializer = new MvxJsonConverter();
                return serializer.DeserializeObject<Customer>(serializer.SerializeObject(storeCustomer));
            }
            return null;
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

        public Customer UpsertCustomer(Customer customer)
        {
            var storeCustomer = GetCustomerStore().SingleOrDefault(c => c.CustomerId == customer.CustomerId);

            if (storeCustomer != null)
            {
                storeCustomer.CustomerName = customer.CustomerName;
                storeCustomer.ContactName = customer.ContactName;
            }
            else
            {
                var serializer = new MvxJsonConverter();
                storeCustomer = serializer.DeserializeObject<Customer>(serializer.SerializeObject(customer));
                GetCustomerStore().Add(storeCustomer);
            }
            return customer;
        }

        public void DeleteCustomer(Customer customer)
        {
            GetCustomerStore().Remove(GetCustomerStore().Single(c => c.CustomerId == customer.CustomerId));
        }
    }
}