using System;
using MvvmCross.Droid.Support.V7.AppCompat;
using VsLiveMvvmCross.Core.ViewModels;

namespace VsLiveMvvmCross.Activities
{
    public class BaseActivity<T> : MvxAppCompatActivity<T> where T : BaseViewModel
    {
    }
}

