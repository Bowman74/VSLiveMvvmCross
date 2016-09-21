using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsLiveMvvmCross.Core.Services
{
    public interface IUserDialogService
    {
        Task<bool> GetResponseAsync(string title, string prompt, string positivePrompt, string negativePrompt);
    }
}
