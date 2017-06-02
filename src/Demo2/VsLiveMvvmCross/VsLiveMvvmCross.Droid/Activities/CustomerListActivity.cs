using System;
using Android.App;
using Android.OS;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Binding.BindingContext;
using VsLiveMvvmCross.Core.ViewModels;
using Android.Widget;

namespace VsLiveMvvmCross.Activities
{
    [Activity(Label = "VsLiveMvvmCross", 
              MainLauncher = false, Icon = "@mipmap/icon", Theme="@style/Theme.MyTheme")]
    public class CustomerListActivity : BaseActivity<CustomerListViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            SetContentView(Resource.Layout.customer_list);
            base.OnCreate(bundle);

            var customerList = FindViewById<MvxListView>(Resource.Id.customerListView);
            var addCustomer = FindViewById<Button>(Resource.Id.addCustomer);

            var bindingSet = this.CreateBindingSet<CustomerListActivity, CustomerListViewModel>();
            bindingSet.Bind(customerList).For(c => c.ItemsSource).To(vm => vm.Customers);
            bindingSet.Bind(customerList).For(c => c.ItemClick).To(vm => vm.CustomerSelectedCommand);
            bindingSet.Bind(addCustomer).For("Click").To(vm => vm.AddCustomerCommand);
            bindingSet.Apply();

            //this.CreateBinding(customerList).For(c => c.ItemsSource).To<CustomerListViewModel>(vm => vm.Customers).Apply();
            //this.CreateBinding(customerList).For(c => c.ItemClick).To<CustomerListViewModel>(vm => vm.CustomerSelectedCommand).Apply();

            
            //this.CreateBinding(addCustomer).For("Click").To<CustomerListViewModel>(vm => vm.AddCustomerCommand).Apply();
        }
    }
}