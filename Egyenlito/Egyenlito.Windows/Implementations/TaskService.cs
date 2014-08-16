using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace Egyenlito.Implementations
{
    public class TaskService : ITaskService
    {
        public async void SendEmail()
        {
            await Launcher.LaunchUriAsync(new Uri("mailto:?to=ujegyenlito2013@gmail.com&subject=Észrevétel"));
        }

        public async void OpenWebpage()
        {
            await Launcher.LaunchUriAsync(new Uri("http://ujegyenlito.hu"));
        }

        public async void OpenFacebook()
        {
            await Launcher.LaunchUriAsync(new Uri("http://facebook.com/ujegyenlitofolyoirat"));
        }
    }
}
