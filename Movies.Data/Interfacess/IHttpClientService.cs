using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Interfacess
{
    public interface IHttpClientService
    {
        Task<T> Get<T>(string requestUri);
    }
}
