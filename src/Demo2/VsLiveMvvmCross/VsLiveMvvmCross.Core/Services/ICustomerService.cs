using System;
using System.Collections.Generic;
using VsLiveMvvmCross.Core.Models;

namespace VsLiveMvvmCross.Core.Services
{
    public interface ICustomerService
    {
        IList<Customer> GetCustomerList();
        Customer GetCustomerById(Guid customerId);
    }
}