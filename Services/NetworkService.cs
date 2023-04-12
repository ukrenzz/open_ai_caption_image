using AC_Image.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AC_Image.Services
{
    internal class NetworkService
    {
        public async Task<List<System.Drawing.Image>> DownloadParallelImage(List<string> urls, IProgress<ImageDownloadProgressReport> progress = null)
        {
            // Task list to do
            List<Task<System.Drawing.Image>> tasks = new List<Task<System.Drawing.Image>>();

            // Add task want to do
            foreach (var url in urls)
            {
                tasks.Add(DownloadImage(url, progress));
            }

            // Running parallel task
            var result = await Task.WhenAll(tasks);

            // Action after all task complete
            //foreach(var item in result) {
            //    MessageBox.Show(item.ToString());
            //}

            return result.ToList<System.Drawing.Image>();
        }
        public async Task<System.Drawing.Image> DownloadImage(string url, IProgress<ImageDownloadProgressReport>? progress = null, int? targetSize = null)
        {
            string filename = url.Substring(url.LastIndexOf('/') + 1);
            string cacheDir = AppService.GetImageCacheDirectory();

            string path = cacheDir + '/' + filename;

            // Check file exist and size same with to get cache image
            if (File.Exists(path))
            {
                return System.Drawing.Image.FromFile(path);
            }

            WebClient webClient = new WebClient();
            if(progress != null)
            {
                webClient.DownloadProgressChanged += (sender, e) => webClient_DownloadProgressChanged(sender, e, progress);
            }

            //byte[] bytes = await webClient.DownloadDataTaskAsync(url);

            await webClient.DownloadFileTaskAsync(url, path);

            //MemoryStream stream = new MemoryStream(bytes);
            //stream.Seek(0, SeekOrigin.Begin);

            //System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

            //stream.Close();

            // Save image to cache
            //image.Save(path);

            return System.Drawing.Image.FromFile(path);
        }

        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e, IProgress<ImageDownloadProgressReport> progress)
        {


            ImageDownloadProgressReport progressReport = new ImageDownloadProgressReport();

            progressReport.downloadedByte = e.BytesReceived;
            progressReport.size = e.TotalBytesToReceive;
            progressReport.percentageComplete = e.ProgressPercentage;

            progress.Report(progressReport);
        }
    }
}
