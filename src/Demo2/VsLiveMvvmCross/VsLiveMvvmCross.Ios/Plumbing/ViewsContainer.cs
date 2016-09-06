using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Platform.Platform;
using UIKit;
using VsLiveMvvmCross.ViewControllers;

namespace VsLiveMvvmCross.Plumbing
{
    public class ViewsContainer : MvxIosViewsContainer
    {
        protected override IMvxIosView CreateViewOfType(Type viewType, MvxViewModelRequest request)
        {
            MvxTrace.Trace(MvxTraceLevel.Diagnostic, "Create iOS View:" + viewType.Name);
            var storyboardName = GetStoryboardNameFromControllerType(viewType);
            var storyboard = UIStoryboard.FromName(storyboardName, null);
            var returnValue = storyboard.InstantiateViewController(viewType.Name);

            return (IMvxIosView)returnValue;
        }

        public string GetStoryboardNameFromControllerType(Type viewType)
        {
            if (viewType == typeof(CustomerListViewController))
            {
                return CustomersStoryboard;
            }
            else if (viewType == typeof(EditCustomerViewController))
            {
                return EditCustomerStoryboard;
            }
            else
            {
                throw new ArgumentException($"The type {viewType.Name} does not have a Storyboard mapped.");
            }

        }

        private const string CustomersStoryboard = "Customers";
        private const string EditCustomerStoryboard = "EditCustomer";

    }
}

