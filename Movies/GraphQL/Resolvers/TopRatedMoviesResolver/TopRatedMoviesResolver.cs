using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.Extensions.Logging;
using Movies.Data.Interfacess;
using Movies.Data.Types;

namespace Movies.GraphQL.Resolvers.TopRatedMoviesResolver
{
    public class TopRatedMoviesResolver
    {
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<TopRated>> GetTopRatedMovies([Service] IMovieService<MovieWrapper<TopRated>> _service,
            [Service] IAppSettings _appSettings, [Service] ILogger<TopRatedMoviesResolver> _logger)
        {
            try
            {

                var result = await _service.Get(_appSettings.TopRatedMovies);
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
