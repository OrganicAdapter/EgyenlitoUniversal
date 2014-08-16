using EgyenlitoLIB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;

namespace EgyenlitoLIB.Models.Implementations
{
    public class DownloadService : IDownloadService
    {
        public async Task DownloadFile(string uri)
        {
            var path = new Uri(uri);
            var downloader = new BackgroundDownloader();
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("article.pdf", CreationCollisionOption.ReplaceExisting);
            var download = downloader.CreateDownload(path, file);
            await StartDownloadAsync(download);
        }

        private async Task StartDownloadAsync(DownloadOperation download)
        {
            var progress = new Progress<DownloadOperation>();
            await download.StartAsync().AsTask(progress);
        }
    }
}
