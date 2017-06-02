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
                var bindingSet = this.CreateBindingSet<EditCustomerViewController, EditCustomerViewModel>();
                bindingSet.Bind(customerName).For(c => c.Text).To(vm => vm.Customer.CustomerName);
                bindingSet.Bind(contactName).For(c => c.Text).To(vm => vm.Customer.ContactName);
                bindingSet.Bind(saveCustomer).To(vm => vm.SaveCustomerCommand);
                bindingSet.Bind(deleteCustomer).To(vm => vm.DeleteCommand);
                bindingSet.Bind(deleteCustomer).For(c => c.Enabled).To(vm => vm.IsNew).WithConversion<InvertedBoolValueConverter>();
                bindingSet.Bind(closeForm).To(ViewModel => ViewModel.CloseCommand);
                bindingSet.Apply();
            });
        }
    }
}