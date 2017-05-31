using System;
using MvvmCross.Core.ViewModels;

namespace VsLiveMvvmCross.Core.ViewModels
{
    public class BaseViewModel<T> : MvxViewModel<T> where T : class
    {
        public BaseViewModel()
        {
        }
    }
}

