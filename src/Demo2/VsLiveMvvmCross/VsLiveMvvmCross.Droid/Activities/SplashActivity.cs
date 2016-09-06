using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace VsLiveMvvmCross.Activities
{
    [Activity(
        Label = "Labyrinth"
        , MainLauncher = true
        , NoHistory = true
        , Icon = "@mipmap/icon"
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen() : base(Resource.Layout.splash_screen)
        {
        }
    }
}