using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using VsLiveMvvmCross.Core.Models;
using VsLiveMvvmCross.Core.Services;

namespace VsLiveMvvmCross.Core.ViewModels
{
    public class EditCustomerViewModel : BaseViewModel
    {
        private ICustomerService _customerService;
        private Guid _customerId;
        private Customer _customer; 

        public EditCustomerViewModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void Init(Guid customerId)
        {
            _customerId = customerId;
        }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            string custId;
            parameters.Data.TryGetValue("customerId", out custId);
            _customerId = Guid.Parse(custId);
        }

        public override void Start()
        {
            base.Start();

            if (_customerId == Guid.Empty)
            {
                Customer = _customerService.CreateNewCustomer();
            }
            else
            {
                Customer = _customerService.GetCustomerById(_customerId);
            }
        }

        public Customer Customer
        {
            get { return _customer; }
            private set
            {
                _customer = value;
                RaisePropertyChanged(() => Customer);
            }
        }

        private ICommand _saveCustomerCommand;
        public ICommand SaveCustomerCommand
        {
            get
            {
                return _saveCustomerCommand ?? (_saveCustomerCommand =
                    new MvxCommand(SaveCustomer));
            }
        }

        public void SaveCustomer()
        {
            if (_customerId == Guid.Empty)
            {
                var customerList = _customerService.GetCustomerList();
                customerList.Add(Customer);
            }
            Close(this);
        }
    }
}