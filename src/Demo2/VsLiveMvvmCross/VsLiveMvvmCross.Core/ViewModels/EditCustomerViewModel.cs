using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using VsLiveMvvmCross.Core.Models;
using VsLiveMvvmCross.Core.Services;

namespace VsLiveMvvmCross.Core.ViewModels
{
    public class EditCustomerViewModel : BaseViewModel
    {
        private ICustomerService _customerService;
        private IUserDialogService _userDialogService;
        private Guid _customerId;
        private Customer _customer;
        private bool _isNew;

        public EditCustomerViewModel(ICustomerService customerService, IUserDialogService userDialogService)
        {
            _customerService = customerService;
            _userDialogService = userDialogService;
        }

        public void Init(Guid customerId)
        {
            _customerId = customerId;
        }

        public bool IsNew
        {
            get { return _isNew; }
            set
            {
                _isNew = value;
                RaisePropertyChanged(() => IsNew);
            }
        }

        public override void Start()
        {
            base.Start();

            if (_customerId == Guid.Empty)
            {
                Customer = _customerService.CreateNewCustomer();
                IsNew = true;
            }
            else
            {
                Customer = _customerService.GetCustomerById(_customerId);
                IsNew = false;
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
            Customer = _customerService.UpsertCustomer(Customer);
            IsNew = false;
        }

        private ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand =
                    new MvxCommand(Close));
            }
        }

        public void Close()
        {
            Close(this);
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new MvxCommand(async () => { await DeleteAsync(); } ));
        }
        }

        public async Task DeleteAsync()
        {
            var response = await _userDialogService.GetResponseAsync("Delete Customer", "Do you want to delete this customer?", "Yes", "No");
            if (response)
            {
                _customerService.DeleteCustomer(Customer);
                Close(this);
            }
        }
    }
}