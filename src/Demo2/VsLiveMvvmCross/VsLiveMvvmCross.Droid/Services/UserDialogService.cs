using System;
using System.Threading.Tasks;
using Android.App;
using VsLiveMvvmCross.Core.Services;
using VsLiveMvvmCross.Plumbing;

namespace VsLiveMvvmCross.Services
{
    public class UserDialogService : IUserDialogService
    {
        public Task<bool> GetResponseAsync(string title, string prompt, string positivePrompt, string negativePrompt)
        {
            var tcs = new TaskCompletionSource<bool>();

            var alert = new AlertDialog.Builder(ActivityHolder.CurrentActivity);
            alert.SetTitle(title);
            alert.SetMessage(prompt);
            alert.SetPositiveButton(positivePrompt, (object sender, Android.Content.DialogClickEventArgs e) =>
            {
                tcs.SetResult(true);
            });
            alert.SetNegativeButton(negativePrompt, (object sender, Android.Content.DialogClickEventArgs e) =>
            {
                tcs.SetResult(false);
            });

            alert.Show();

            return tcs.Task;
        }
    }
}