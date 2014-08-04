using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using Windows.System;
using Windows.UI.Xaml;

namespace Egyenlito.Implementations
{
    public class TaskService : ITaskService
    {
        public async void SendEmail()
        {
            var rec = new EmailRecipient("ujegyenlito2013@gmail.com", "Új Egyenlítő");
            var msg = new EmailMessage();

            msg.Subject = "Észrevétel";
            msg.To.Add(rec);

            await EmailManager.ShowComposeNewEmailAsync(msg);
        }

        public async void OpenWebpage()
        {
            await Launcher.LaunchUriAsync(new Uri("http://ujegyenlito.hu", UriKind.Absolute));
        }

        public async void OpenFacebook()
        {
            await Launcher.LaunchUriAsync(new Uri("http://facebook.com/ujegyenlitofolyoirat", UriKind.Absolute));
        }
    }
}
