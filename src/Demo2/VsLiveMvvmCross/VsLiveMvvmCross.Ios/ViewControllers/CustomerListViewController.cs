using Foundation;
using System;
using UIKit;
using VsLiveMvvmCross.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.iOS.Views;

namespace VsLiveMvvmCross.ViewControllers
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    [MvxFromStoryboard("Customers")]
    public partial class CustomerListViewController : BaseViewController<CustomerListViewModel>
    {
        public CustomerListViewController (IntPtr handle) : base (handle)
        {
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            if (tblCustomers.Source == null)
            {
                var source = new CustomerListViewSource(tblCustomers, typeof(CustomerListCell), CustomerListCell.Key);
                var bindingSet = this.CreateBindingSet<CustomerListViewController, CustomerListViewModel>();
                bindingSet.Bind(source).To(ViewModel => ViewModel.Customers);
                bindingSet.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.CustomerSelectedCommand);
                bindingSet.Bind(addButton).To(vm => vm.AddCustomerCommand);
                bindingSet.Apply();

                tblCustomers.Source = source;
                tblCustomers.ReloadData();
            }
        }

        public override void ViewWillLayoutSubviews()
        {
            HideTableTopSpacing(tblCustomers);

            base.ViewWillLayoutSubviews();
        }

        protected void HideTableTopSpacing(UITableView table)
        {
            if (table.ContentInset.Top != 0.0f)
                table.ContentInset = UIEdgeInsets.Zero;
            if (table.ScrollIndicatorInsets.Top != 0.0f)
                table.ScrollIndicatorInsets = UIEdgeInsets.Zero;
        }
    }
}