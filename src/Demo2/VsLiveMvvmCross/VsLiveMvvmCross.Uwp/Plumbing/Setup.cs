using Windows.UI.Xaml.Controls;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.WindowsUWP.Platform;
using VsLiveMvvmCross.Core.Services;
using VsLiveMvvmCross.Uwp.Services;

namespace VsLiveMvvmCross.Uwp.Plumbing
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            var app = new Core.Plumbing.App();
            Mvx.RegisterType<IUserDialogService, UserDialogService>();
            return app;
        }
    }
}