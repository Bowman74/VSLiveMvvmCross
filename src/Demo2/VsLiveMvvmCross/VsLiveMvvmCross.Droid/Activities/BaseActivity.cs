using System;
using Android.OS;
using Android.Support.V7.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using VsLiveMvvmCross.Core.ViewModels;
using VsLiveMvvmCross.Plumbing;

namespace VsLiveMvvmCross.Activities
{
    public class BaseActivity<T> : MvxAppCompatActivity<T> where T : MvxViewModel
    {
        protected Toolbar _toolbar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _toolbar = FindViewById<Toolbar>(Resource.Id.commonToolbar);
            if (_toolbar != null)
            {
                SetSupportActionBar(_toolbar);

                SupportActionBar.Subtitle = string.Empty;
            }
        }
    }
}