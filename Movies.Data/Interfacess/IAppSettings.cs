using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Interfacess
{
    public interface IAppSettings
    {
        string MovieDetails { get; }
        string MovieReview { get; }
        string UpcomingMovies { get; }
    }
}
