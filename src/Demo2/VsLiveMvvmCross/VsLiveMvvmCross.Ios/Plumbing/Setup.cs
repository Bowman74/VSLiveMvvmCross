using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views;
using UIKit;
using VsLiveMvvmCross.Core.Plumbing;

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
            return app;
        }

        protected override IMvxIosViewsContainer CreateIosViewsContainer()
        {
            return new ViewsContainer();
        }
    }
}

