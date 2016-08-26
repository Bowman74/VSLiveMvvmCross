// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace VsLiveMvvmCross.ViewControllers
{
    [Register ("CustomerListViewController")]
    partial class CustomerListViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tblCustomers { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (tblCustomers != null) {
                tblCustomers.Dispose ();
                tblCustomers = null;
            }
        }
    }
}