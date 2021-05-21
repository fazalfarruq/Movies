using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Interfacess
{
    public interface IMovieService<T>
    {
        Task<T> Get(string requestUri);
    }
}
