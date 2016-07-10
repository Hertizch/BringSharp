using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BringSharp
{
    internal static class JsonQueryClient
    {
        internal static async Task<string> GetResponse(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(new Uri(url));
            }
        }

        internal static async Task<HttpStatusCode> GetResponseStatusCode(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(new Uri(url));

                return response.StatusCode;
            }
        }
    }
}
