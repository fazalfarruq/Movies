using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.Extensions.Logging;
using Movies.Data.Interfacess;
using Movies.Data.Types;

namespace Movies.GraphQL.Resolvers.UpcomingMoviesResolver
{
    public class UpcomingMoviesResolver
    {
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<UpComing>> GetUpComingMovies([Service] IMovieService<MovieWrapper<UpComing>> _service,
            [Service] IAppSettings _appSettings, [Service] ILogger<UpcomingMoviesResolver> _logger)
        {
            try
            {

                var result = await _service.Get(_appSettings.UpcomingMovies);
                return result.results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return default;
            }

        }
    }
}
