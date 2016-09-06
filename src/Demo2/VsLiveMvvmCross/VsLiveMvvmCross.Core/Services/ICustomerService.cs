using System;
using System.Collections.ObjectModel;
using VsLiveMvvmCross.Core.Models;

namespace VsLiveMvvmCross.Core.Services
{
    public interface ICustomerService
    {
        ObservableCollection<Customer> GetCustomerList();
        Customer GetCustomerById(Guid customerId);
        Customer CreateNewCustomer();
    }
}