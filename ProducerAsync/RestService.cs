using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerAsync
{
    internal class RestService
    {
        private static HttpClient httpClient;
        private const string baseAddress = "https://www.google.com/";
        private const string postReqUrl = "favicon.ico";

        static RestService()
        {
            httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0,0,0,0,1000);
            httpClient.BaseAddress = new Uri(baseAddress);
        }


        public static async Task<HttpResponseMessage> TestAsync()
        {
             return await httpClient.GetAsync(postReqUrl);
        }
    }
}
