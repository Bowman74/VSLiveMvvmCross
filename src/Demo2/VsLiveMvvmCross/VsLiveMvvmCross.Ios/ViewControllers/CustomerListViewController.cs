using Foundation;
using System;
using UIKit;
using VsLiveMvvmCross.Core.ViewModels;

namespace VsLiveMvvmCross.ViewControllers
{
    public partial class CustomerListViewController : BaseViewController<CustomerListViewModel>
    {
        public CustomerListViewController (IntPtr handle) : base (handle)
        {
        }
    }
}