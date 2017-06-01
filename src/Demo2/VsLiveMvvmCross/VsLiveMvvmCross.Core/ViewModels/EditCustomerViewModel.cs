using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using VsLiveMvvmCross.Core.Models;
using VsLiveMvvmCross.Core.Services;

namespace VsLiveMvvmCross.Core.ViewModels
{
    public class EditCustomerViewModel : MvxViewModel<MvxBundle, Customer>
    {
        private ICustomerService _customerService;
        private IUserDialogService _userDialogService;
        private Customer _customer;
        private bool _isNew;
        private Guid _instance = Guid.NewGuid();

        public EditCustomerViewModel(ICustomerService customerService, IUserDialogService userDialogService)
        {
            _customerService = customerService;
            _userDialogService = userDialogService;
            Customer = _customerService.CreateNewCustomer();
            IsNew = true;
            Debug.WriteLine($"EditCustomerViewModel: instance: {_instance.ToString()}: constructor");
        }

        public override Task Initialize(MvxBundle parameter)
        {
            Debug.WriteLine($"EditCustomerViewModel: instance: {_instance.ToString()}: initialize");
            if (parameter != null && 
                parameter.Data.TryGetValue("customerId", out string custId))
            {
                if (Guid.TryParse(custId, out Guid customerId))
                {
                    Customer = _customerService.GetCustomerById(customerId);
                    IsNew = false;
                }
            }
            return Task.FromResult(true);
        }

        public override void Appearing()
        {
            Debug.WriteLine($"EditCustomerViewModel: instance: {_instance.ToString()}: appearing");
            base.Appearing();
        }

        public override void Appeared()
        {
            Debug.WriteLine($"EditCustomerViewModel: instance: {_instance.ToString()}: appeared");
            base.Appeared();
        }

        public override void Disappearing()
        {
            Debug.WriteLine($"EditCustomerViewModel: instance: {_instance.ToString()}: disappearing");
            base.Disappearing();
        }

        public override void Disappeared()
        {
            Debug.WriteLine($"EditCustomerViewModel: instance: {_instance.ToString()}: disappeared");
            base.Disappeared();
        }

        public bool IsNew
        {
            get => _isNew; 
            set => SetProperty(ref _isNew, value);
        }

        public Customer Customer
        {
            get => _customer; 
            private set => SetProperty(ref _customer, value);
        }

        private ICommand _saveCustomerCommand;
        public ICommand SaveCustomerCommand
        {
            get
            {
                return _saveCustomerCommand ?? (_saveCustomerCommand =
                    new MvxCommand(SaveCustomer));

                void SaveCustomer()
                {
                    Customer = _customerService.UpsertCustomer(Customer);
                    IsNew = false;
                }
            }
        }

        private ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand =
                    new MvxCommand(async () => await CloseAsync()));

                async Task CloseAsync()
                {
                    await this.Close(_customerService.GetCustomerById(Customer.CustomerId));
                }
            }
        }

        private ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get 
            { 
                return _deleteCommand ?? (_deleteCommand = 
                                          new MvxCommand(async () => { await DeleteAsync(); } ));

                async Task DeleteAsync()
                {
                    var response = await _userDialogService.GetResponseAsync("Delete Customer", "Do you want to delete this customer?", "Yes", "No");
                    if (response)
                    {
                        _customerService.DeleteCustomer(Customer);
                        await Close(null);
                    }
                }
            }
        }
    }
}