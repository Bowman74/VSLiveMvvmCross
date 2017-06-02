using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsLiveMvvmCross.Uwp.Plumbing
{

    using System;

    using MvvmCross.Core.ViewModels;
    using MvvmCross.Core.Views;
    using MvvmCross.Platform;
    using MvvmCross.Platform.Exceptions;
    using MvvmCross.Platform.Platform;
    using MvvmCross.Uwp.Views;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class CustomViewPresenter
         : MvxViewPresenter, IMvxWindowsViewPresenter
    {
        private readonly IMvxWindowsFrame _rootFrame;

        public CustomViewPresenter(IMvxWindowsFrame rootFrame)
        {
            this._rootFrame = rootFrame;
        }

        public override void Show(MvxViewModelRequest request)
        {
            try
            {
                var requestTranslator = Mvx.Resolve<IMvxViewsContainer>();
                var viewType = requestTranslator.GetViewType(request.ViewModelType);

                var converter = Mvx.Resolve<IMvxNavigationSerializer>();
                var requestText = converter.Serializer.SerializeObject(request);

                this._rootFrame.Navigate(viewType, requestText); //Frame won't allow serialization of it's nav-state if it gets a non-simple type as a nav param
                if (((Frame)Window.Current.Content).Content  is MvxWindowsPage && request is MvxViewModelInstanceRequest)
                {
                    var curPage = (MvxWindowsPage)((Frame)Window.Current.Content).Content;
                    curPage.ViewModel = ((MvxViewModelInstanceRequest)request).ViewModelInstance;
                }
            }
            catch (Exception exception)
            {
                MvxTrace.Trace("Error seen during navigation request to {0} - error {1}", request.ViewModelType.Name,
                               exception.ToLongString());
            }
        }

        public override void ChangePresentation(MvxPresentationHint hint)
        {
            if (base.HandlePresentationChange(hint)) return;

            if (hint is MvxClosePresentationHint)
            {
                this.Close((hint as MvxClosePresentationHint).ViewModelToClose);
                return;
            }

            MvxTrace.Warning("Hint ignored {0}", hint.GetType().Name);
        }

        public override void Close(IMvxViewModel viewModel)
        {
            var currentView = this._rootFrame.Content as IMvxView;
            if (currentView == null)
            {
                Mvx.Warning("Ignoring close for viewmodel - rootframe has no current page");
                return;
            }

            if (currentView.ViewModel != viewModel)
            {
                Mvx.Warning("Ignoring close for viewmodel - rootframe's current page is not the view for the requested viewmodel");
                return;
            }

            if (!this._rootFrame.CanGoBack)
            {
                Mvx.Warning("Ignoring close for viewmodel - rootframe refuses to go back");
                return;
            }

            this._rootFrame.GoBack();
        }
    }
}
