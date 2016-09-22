using System;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace VsLiveMvvmCross.ViewControllers
{
    public class CustomerListViewSource : MvxSimpleTableViewSource
    {
        public CustomerListViewSource(UITableView tableView, Type cellType, string cellIdentifier = null) : base(tableView, cellType, cellIdentifier)
        { }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, Foundation.NSIndexPath indexPath, object item)
        {
            var customerCell = new CustomerListCell(UITableViewCellStyle.Subtitle, CustomerListCell.Key, UITableViewCellAccessory.DisclosureIndicator);
            customerCell.Initiliaze();
            return customerCell;
        }
    }
}
