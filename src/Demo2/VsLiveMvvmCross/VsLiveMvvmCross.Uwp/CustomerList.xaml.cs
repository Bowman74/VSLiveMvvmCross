﻿using System;
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
using MvvmCross.Platform;
using MvvmCross.Core.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VsLiveMvvmCross.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    [MvxViewFor(typeof(CustomerListViewModel))]
    public sealed partial class CustomerList
    {
        public CustomerList()
        {
            this.InitializeComponent();

            lstCustomers.SelectionChanged += LstCustomersOnSelectionChanged;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
        }

        private void LstCustomersOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                ListViewModel.CustomerSelectedCommand.Execute(e.AddedItems[0]);
            }
        }

        public CustomerListViewModel ListViewModel
        {
            get
            {
                return base.ViewModel as CustomerListViewModel;
            }
            set
            {
                base.ViewModel = value;
            }
        }
    }
}
