using Newtonsoft.Json;
using System.Text;

namespace SandboxApp.Data
{
    public class RestService
    {
        private readonly Uri BaseUrl = new Uri("https://jsonplaceholder.typicode.com/");

        private readonly HttpClient client;

        public RestService()
        {
            client = new HttpClient() { BaseAddress = BaseUrl };
        }

        public async Task<string> GetAsync(string route)
        {
            if (IsConnected())
            {
                HttpResponseMessage response = await client.GetAsync(route);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return "";
        }

        public async Task<T> GetAsync<T>(string route)
        {
            return JsonConvert.DeserializeObject<T>(await GetAsync(route));
        }

        public async Task<string> PostAsync(string route, object body)
        {
            if (IsConnected())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(route, stringContent);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return "";
        }

        public async Task<string> PatchAsync(string route, object body)
        {
            if (IsConnected())
            {
                var method = new HttpMethod("PATCH");

                var stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(method, route)
                {
                    Content = stringContent
                };

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return "";
        }

        public async Task<string> DeleteAsync(string route)
        {
            if (IsConnected())
            {
                HttpResponseMessage response = await client.DeleteAsync(route);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }

            return "";
        }

        private bool IsConnected()
        {
            return Connectivity.Current.NetworkAccess == NetworkAccess.Internet;
        }
    }
}
