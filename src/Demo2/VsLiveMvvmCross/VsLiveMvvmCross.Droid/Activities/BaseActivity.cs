using System;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Droid.Support.V7.AppCompat;
using VsLiveMvvmCross.Core.ViewModels;
using VsLiveMvvmCross.Plumbing;

namespace VsLiveMvvmCross.Activities
{
    public class BaseActivity<T> : MvxAppCompatActivity<T> where T : BaseViewModel
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var toolbar = FindViewById<Toolbar>(Resource.Id.commonToolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);

                SupportActionBar.Subtitle = string.Empty;
                toolbar.NavigationClick += GoBack;
            }

        }

        protected override void OnResume()
        {
            base.OnResume();
            ActivityHolder.CurrentActivity = this;
        }

        private void GoBack(object sender, Toolbar.NavigationClickEventArgs e)
        {
            Finish();
        }
    }
}