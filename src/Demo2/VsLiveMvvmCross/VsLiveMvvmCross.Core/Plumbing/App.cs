using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using VsLiveMvvmCross.Core.Services;
using VsLiveMvvmCross.Core.ViewModels;

namespace VsLiveMvvmCross.Core.Plumbing
{
    public class App : MvxApplication
    {
        public App()
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            Mvx.RegisterType<ICustomerService, CustomerService>();

            RegisterAppStart<CustomerListViewModel>();
        }
    }
}