using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Spikes.Interfaces;
using Spikes.Shared;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Xamarin.Forms.Dependency (typeof (DownloadService))]

namespace Spikes.Shared {

    public class DownloadService : IDownloadService {

        public Task<DownloadResult> Download(string url, string localFilename, ProgressBar progressBar) {

            //Console.WriteLine("MyDocuments: {0}",);
            var progressReporter = new Progress<DownloadBytesProgress>();
            progressReporter.ProgressChanged += (sender, progress) => progressBar.Progress = progress.PercentComplete;
            return DownloadHelper.CreateDownloadTask(url, localFilename, progressReporter);
        }

    }

    public static class DownloadHelper {

        public static async Task<DownloadResult> CreateDownloadTask(string urlToDownload, string localFilename, IProgress<DownloadBytesProgress> progessReporter) {
            var receivedBytes = 0;
            var totalBytes = 0L;
            var webClient = new WebClient();

            var destinationFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), localFilename);

            webClient.DownloadProgressChanged += (sender, args) => {
                totalBytes = args.TotalBytesToReceive;
                var progress = new DownloadBytesProgress(urlToDownload, args.BytesReceived, args.TotalBytesToReceive);
                progessReporter.Report(progress);
            };

            await webClient.DownloadFileTaskAsync(urlToDownload, destinationFilePath);

            Console.WriteLine(destinationFilePath);
            var result = new DownloadResult() {
                Bytes = totalBytes,
                Path = destinationFilePath
            };
            return result;
        }
//        public static async Task<int> CreateDownloadTask(string urlToDownload, string localFilename, IProgress<DownloadBytesProgress> progessReporter) {
//            int receivedBytes = 0;
//            int totalBytes = 0;
//            WebClient client = new WebClient();
//
//            var destinationFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.GetTempFileName());
//            var file = File.OpenWrite(destinationFilePath);
//            var writer = new BinaryWriter(file);
//
//            using (var stream = await client.OpenReadTaskAsync(urlToDownload)) {
//                byte[] buffer = new byte[4096];
//                totalBytes = Int32.Parse(client.ResponseHeaders[HttpResponseHeader.ContentLength]);
//
//                for (;;) {
//                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
//                    writer.Write(buffer);
//                    writer.Flush();
//                    if (bytesRead == 0) {
//                        writer.Close();
//                        file.Close();
//                        await Task.Yield();
//                        break;
//                    }
//
//                    receivedBytes += bytesRead;
//                    if (progessReporter != null) {
//                        DownloadBytesProgress args = new DownloadBytesProgress(urlToDownload, receivedBytes, totalBytes);
//                        progessReporter.Report(args);
//                    }
//                }
//            }
//            Console.WriteLine(destinationFilePath);
//            return receivedBytes;
//        }

    }

    public class DownloadBytesProgress {

        public DownloadBytesProgress(string fileName, long bytesReceived, long totalBytes) {
            Filename = fileName;
            BytesReceived = bytesReceived;
            TotalBytes = totalBytes;
        }

        public long TotalBytes { get; private set; }

        public long BytesReceived { get; private set; }

        public float PercentComplete {
            get { return (float) BytesReceived/TotalBytes; }
        }

        public string Filename { get; private set; }

        public bool IsFinished {
            get { return BytesReceived == TotalBytes; }
        }

    }

}