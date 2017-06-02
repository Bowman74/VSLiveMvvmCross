using Windows.UI.Xaml.Controls;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using VsLiveMvvmCross.Core.Services;
using VsLiveMvvmCross.Uwp.Services;
using MvvmCross.Uwp.Platform;
using MvvmCross.Uwp.Views;

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

        //protected override IMvxWindowsViewPresenter CreateViewPresenter(IMvxWindowsFrame rootFrame)
        //{
        //    return new CustomViewPresenter(rootFrame);
        //}
    }
}