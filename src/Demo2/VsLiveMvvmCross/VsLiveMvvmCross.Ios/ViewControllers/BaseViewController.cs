﻿using System;
using MvvmCross.iOS.Views;
using VsLiveMvvmCross.Core.ViewModels;

namespace VsLiveMvvmCross.ViewControllers
{
    public class BaseViewController<T> : MvxViewController<T> where T : BaseViewModel
    {
        public BaseViewController(IntPtr handle) : base (handle)
        {
        }
    }
}