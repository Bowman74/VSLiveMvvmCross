using System;
using System.Linq;
using Foundation;
using MvvmCross.Binding.Binders;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Platform;
using UIKit;
using VsLiveMvvmCross.Core.Models;

namespace VsLiveMvvmCross.ViewControllers
{
    public class CustomerListCell: MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("customerCell");

        public CustomerListCell(UITableViewCellStyle cellStyle, NSString cellIdentifier, UITableViewCellAccessory tableViewCellAccessory = UITableViewCellAccessory.None)
            : base(string.Empty, cellStyle, cellIdentifier, tableViewCellAccessory)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Default;
        }

        public CustomerListCell(IntPtr handle) : base(string.Empty, handle)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Default;

        }

        public void Initiliaze()
        {
            var context = BindingContext;
            context.DelayBind(() =>
            {
                var binder = Mvx.Resolve<IMvxBinder>();
                string vmProperty = string.Empty;
                var typedContext = (Customer)DataContext;

                var bindings = binder.Bind(DataContext, TextLabel, $"Text CustomerName").ToList();
                context.RegisterBinding(TextLabel, bindings[0]);
                bindings = binder.Bind(DataContext, DetailTextLabel, "Text ContactName").ToList();
                context.RegisterBinding(DetailTextLabel, bindings[0]);
            });
        }
    }
}