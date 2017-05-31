using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using VsLiveMvvmCross.Core.ViewModels;

namespace VsLiveMvvmCross.ViewControllers
{
    public class BaseViewController<T> : MvxViewController<T> where T : MvxViewModel
    {
        public BaseViewController(IntPtr handle) : base (handle)
        {
        }
    }
}