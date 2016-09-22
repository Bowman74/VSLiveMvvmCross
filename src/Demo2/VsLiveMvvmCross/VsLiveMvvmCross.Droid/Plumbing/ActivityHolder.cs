using System;
using Android.App;

namespace VsLiveMvvmCross.Plumbing
{
    public static class ActivityHolder
    {
        private static WeakReference<Activity> _currentActivity;

        public static Activity CurrentActivity
        {
            get
            {
                Activity currentActivity;
                return _currentActivity.TryGetTarget(out currentActivity) ? currentActivity : null;
            }
            set
            {
                _currentActivity = new WeakReference<Activity>(value);
            }
        }
    }
}