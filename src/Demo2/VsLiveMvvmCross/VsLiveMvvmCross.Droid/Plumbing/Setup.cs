using System;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using VsLiveMvvmCross.Core.Plumbing;
using VsLiveMvvmCross.Core.Services;
using VsLiveMvvmCross.Services;

//This hhas to match default namespace.
namespace VsLiveMvvmCross
{
    public sealed class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            var app = new App();
            Mvx.RegisterType<IUserDialogService, UserDialogService>();
            return app;
        }
    }
}