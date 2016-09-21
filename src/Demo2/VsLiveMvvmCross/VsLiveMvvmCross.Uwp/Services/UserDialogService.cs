using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using VsLiveMvvmCross.Core.Services;

namespace VsLiveMvvmCross.Uwp.Services
{
    public class UserDialogService : IUserDialogService
    {
        private const int PositiveControl = 0;
        private const int NegativeControl = 1;

        public async Task<bool> GetResponseAsync(string title, string prompt, string positivePrompt, string negativePrompt)
        {
            var dialog = new MessageDialog(prompt, title);
            dialog.Commands.Add(new UICommand { Label = positivePrompt, Id = PositiveControl });
            dialog.Commands.Add(new UICommand { Label = negativePrompt, Id = NegativeControl });
            var res = await dialog.ShowAsync();

            return (int)res.Id == PositiveControl;
        }
    }
}
