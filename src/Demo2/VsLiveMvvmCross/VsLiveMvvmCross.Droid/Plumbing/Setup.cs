using System;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using VsLiveMvvmCross.Core.Plumbing;

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
            return app;
        }
    }
}