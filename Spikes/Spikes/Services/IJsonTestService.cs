using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;

namespace Spikes.Services {

    public interface IJsonTestService {
        Task<string> GetDateTimeAsync();
    }

    public class JsonTestService : IJsonTestService {

        private HttpClient client;

        public async Task<string> GetDateTimeAsync() {
            client = new HttpClient(new NativeMessageHandler());
            var response = await client.GetStringAsync("http://date.jsontest.com");
			var dateTime = JsonConvert.DeserializeObject<JsonDateTime>(response);
			return dateTime.Time;
        }

    }

	public class JsonDateTime {
		public string Date { get; set; }
		public string Time { get; set; }
	}

}