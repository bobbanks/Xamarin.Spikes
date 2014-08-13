using System.Threading.Tasks;
using Xamarin.Forms;

namespace Spikes.Interfaces {

    public interface IDownloadService {
        Task<DownloadResult> Download(string url, string localFilename, ProgressBar progressBar);
    }

    public class DownloadResult {
        public string Path { get; set; }
        public long Bytes { get; set; }
    }
}