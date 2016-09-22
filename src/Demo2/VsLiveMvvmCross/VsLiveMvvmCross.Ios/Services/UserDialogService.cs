using System;
using System.Threading.Tasks;
using UIKit;
using VsLiveMvvmCross.Core.Services;

namespace VsLiveMvvmCross.Services
{
    public class UserDialogService : IUserDialogService
    {
        public Task<bool> GetResponseAsync(string title, string prompt, string positivePrompt, string negativePrompt)
        {
            var tcs = new TaskCompletionSource<bool>();

            var alert = new UIAlertView(title, prompt, null, negativePrompt, positivePrompt);
            alert.Clicked += (sender, buttonArgs) => tcs.SetResult(buttonArgs.ButtonIndex != alert.CancelButtonIndex);
            alert.Show();

            return tcs.Task;
        }
    }
}