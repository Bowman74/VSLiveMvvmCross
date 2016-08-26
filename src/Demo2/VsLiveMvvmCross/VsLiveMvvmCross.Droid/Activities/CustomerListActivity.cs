using System;
using Android.App;
using Android.OS;
using VsLiveMvvmCross.Core.ViewModels;

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

        }
    }
}