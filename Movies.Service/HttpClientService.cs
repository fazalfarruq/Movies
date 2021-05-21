using Movies.Data.Interfacess;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Service
{
    public class HttpClientService : IHttpClientService
    {
        public async Task<T> Get<T>(string requestUri)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    var result = await httpClient.GetAsync(requestUri);

                    if (result.IsSuccessStatusCode)
                    {
                        var responseFromServer = await result.Content.ReadAsStringAsync();
                        var response = JsonConvert.DeserializeObject<T>(responseFromServer);
                        return response;
                    }
                }

                return default;
            }
            catch (Exception e)
            {
                return default;
            }
        }
    }
}
