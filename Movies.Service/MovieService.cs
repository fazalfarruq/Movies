using Movies.Data.Interfacess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Service
{
    public class MovieService<T> : IMovieService<T>
    {
        private readonly IHttpClientService _httpClientService;

        public MovieService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<T> Get(string requestUri)
        {
            var result = await _httpClientService
                .Get<T>(requestUri);
            return result;
        }
    }
}
