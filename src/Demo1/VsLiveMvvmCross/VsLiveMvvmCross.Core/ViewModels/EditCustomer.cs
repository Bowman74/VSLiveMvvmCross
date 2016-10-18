using System;
using VsLiveMvvmCross.Core.Models;
using VsLiveMvvmCross.Core.Services;

namespace VsLiveMvvmCross.Core.ViewModels
{
    public class EditCustomer : BaseViewModel
    {
        private ICustomerService _customerService;
        private Guid _customerId;
        private Customer _customer; 

        public EditCustomer(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void Init(Guid customerId)
        {
            _customerId = customerId;
        }

        public override void Start()
        {
            base.Start();
            // Do something to load the customer based on the customer id.
            Customer = _customerService.GetCustomerById(_customerId);
        }

        public Customer Customer
        {
            get { return _customer; }
            private set
            {
                SetProperty(ref _customer, value);
            }
        }
    }
}