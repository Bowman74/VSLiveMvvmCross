// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace VsLiveMvvmCross.ViewControllers
{
    [Register ("EditCustomerViewController")]
    partial class EditCustomerViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton closeForm { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField contactName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField customerName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton deleteCustomer { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton saveCustomer { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (closeForm != null) {
                closeForm.Dispose ();
                closeForm = null;
            }

            if (contactName != null) {
                contactName.Dispose ();
                contactName = null;
            }

            if (customerName != null) {
                customerName.Dispose ();
                customerName = null;
            }

            if (deleteCustomer != null) {
                deleteCustomer.Dispose ();
                deleteCustomer = null;
            }

            if (saveCustomer != null) {
                saveCustomer.Dispose ();
                saveCustomer = null;
            }
        }
    }
}