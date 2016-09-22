using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using VsLiveMvvmCross.Core.Converters;
using VsLiveMvvmCross.Core.ViewModels;

namespace VsLiveMvvmCross.Activities
{
    [Activity(Theme = "@style/Theme.MyTheme")]
    public class EditCustomerActivity: BaseActivity<EditCustomerViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            SetContentView(Resource.Layout.edit_customer);
            base.OnCreate(bundle);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            var customerName = FindViewById<EditText>(Resource.Id.customerName);
            this.CreateBinding(customerName).For(c => c.Text).To<EditCustomerViewModel>(vm => vm.Customer.CustomerName).Apply();
            var contactName = FindViewById<EditText>(Resource.Id.contactName);
            this.CreateBinding(contactName).For(c => c.Text).To<EditCustomerViewModel>(vm => vm.Customer.ContactName).Apply();

            var saveCustomer = FindViewById<Button>(Resource.Id.saveCustomer);
            this.CreateBinding(saveCustomer).For("Click").To<EditCustomerViewModel>(vm => vm.SaveCustomerCommand).Apply();
            var deleteCustomer = FindViewById<Button>(Resource.Id.deleteCustomer);
            this.CreateBinding(deleteCustomer).For("Click").To<EditCustomerViewModel>(vm => vm.DeleteCommand).Apply();
            this.CreateBinding(deleteCustomer).For(b => b.Enabled).To<EditCustomerViewModel>(vm => vm.IsNew).WithConversion(new  InvertedBoolValueConverter(), null).Apply();

        }
    }
}