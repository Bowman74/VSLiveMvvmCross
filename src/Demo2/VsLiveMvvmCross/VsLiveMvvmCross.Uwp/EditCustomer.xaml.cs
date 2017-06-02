using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MvvmCross.Core.ViewModels;
using VsLiveMvvmCross.Core.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace VsLiveMvvmCross.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [MvxViewFor(typeof(EditCustomerViewModel))]
    public sealed partial class EditCustomer
    {
        public EditCustomer()
        {
            this.InitializeComponent();
            this.DataContextChanged += EditCustomer_DataContextChanged;
        }

        private void EditCustomer_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var a = 1;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += EditCustomer_BackRequested;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= EditCustomer_BackRequested;
        }

        private void EditCustomer_BackRequested(object sender, BackRequestedEventArgs e)
        {
            ((EditCustomerViewModel)ViewModel).CloseCommand.Execute(null);
        }

        public EditCustomerViewModel CustomerViewModel
        {
            get
            {
                return ViewModel as EditCustomerViewModel;
            }
            set
            {
                ViewModel = value;
            }
        }
    }
}
