using Foundation;
using System;
using UIKit;
using VsLiveMvvmCross.Core.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace VsLiveMvvmCross.ViewControllers
{
    public partial class CustomerListViewController : BaseViewController<CustomerListViewModel>
    {
        public CustomerListViewController (IntPtr handle) : base (handle)
        {
            
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (tblCustomers.Source == null)
            {
                var source = new CustomerListViewSource(tblCustomers, typeof(CustomerListCell), CustomerListCell.Key);

                this.CreateBinding(source).To<CustomerListViewModel>(ViewModel => ViewModel.Customers).Apply();
                this.CreateBinding(source).For(s => s.SelectionChangedCommand).To<CustomerListViewModel>(vm => vm.CustomerSelectedCommand).Apply();

                tblCustomers.Source = source;
                tblCustomers.ReloadData();

                this.CreateBinding(addButton).To<CustomerListViewModel>(vm => vm.AddCustomerCommand).Apply();
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