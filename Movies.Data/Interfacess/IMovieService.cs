using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Interfacess
{
    public interface IMovieService<T>
    {
        Task<IEnumerable<T>> Get(string requestUri);
    }
}
