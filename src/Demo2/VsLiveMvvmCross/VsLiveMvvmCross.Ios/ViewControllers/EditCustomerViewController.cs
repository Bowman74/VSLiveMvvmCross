using Foundation;
using System;
using VsLiveMvvmCross.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using VsLiveMvvmCross.Core.Converters;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;

namespace VsLiveMvvmCross.ViewControllers
{
    [MvxFromStoryboard("EditCustomer")]
    [MvxModalPresentation]
    public partial class EditCustomerViewController : MvxViewController<EditCustomerViewModel>
    {
        public EditCustomerViewController (IntPtr handle) : base (handle)
        {
            InitializeBindings();
        }

        private void InitializeBindings()
        {
            this.DelayBind(() =>
            {
                this.CreateBinding(customerName).For(c => c.Text).To<EditCustomerViewModel>(vm => vm.Customer.CustomerName).Apply();
                this.CreateBinding(contactName).For(c => c.Text).To<EditCustomerViewModel>(vm => vm.Customer.ContactName).Apply();
                this.CreateBinding(saveCustomer).To<EditCustomerViewModel>(vm => vm.SaveCustomerCommand).Apply();
                this.CreateBinding(deleteCustomer).To<EditCustomerViewModel>(vm => vm.DeleteCommand).Apply();
                this.CreateBinding(deleteCustomer).For(c => c.Enabled).To<EditCustomerViewModel>(vm => vm.IsNew).WithConversion(new InvertedBoolValueConverter(), null).Apply();
                this.CreateBinding(closeForm).To<EditCustomerViewModel>(ViewModel => ViewModel.CloseCommand).Apply();
            });
        }
    }
}