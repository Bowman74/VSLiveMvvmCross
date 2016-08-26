using Foundation;
using System;
using UIKit;
using VsLiveMvvmCross.Core.ViewModels;

namespace VsLiveMvvmCross.ViewControllers
{
    public partial class EditCustomerViewController : BaseViewController<EditCustomerViewModel>
    {
        public EditCustomerViewController (IntPtr handle) : base (handle)
        {
        }
    }
}