using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using UIKit;
using VsLiveMvvmCross.Core.Plumbing;
using VsLiveMvvmCross.Core.Services;
using VsLiveMvvmCross.Services;

namespace VsLiveMvvmCross.Plumbing
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {}

        protected override IMvxApplication CreateApp()
        {
            var app = new App();
            Mvx.RegisterType<IUserDialogService, UserDialogService>();
            return app;
        }
    }
}