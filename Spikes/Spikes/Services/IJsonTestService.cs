using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;

namespace Spikes.Services {

    public interface IJsonTestService {
        Task<string> GetDateTimeAsync();
    }

    public class JsonTestService : IJsonTestService {

        private HttpClient client;

        public async Task<string> GetDateTimeAsync() {
            client = new HttpClient(new NativeMessageHandler());
            var response = await client.GetStringAsync("http://date.jsontest.com");
            return response;
        }

    }

}