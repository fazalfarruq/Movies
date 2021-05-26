using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.Extensions.Logging;
using Movies.Data.Interfacess;
using Movies.Data.Types;

namespace Movies.GraphQL.Resolvers.PopularMoviesResolver
{
    public class PopularMoviesResolver
    {
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<Popular>> GetPopularMovies([Service] IMovieService<MovieWrapper<Popular>> _service,
            [Service] IAppSettings _appSettings, [Service] ILogger<PopularMoviesResolver> _logger)
        {
            try
            {

                var result = await _service.Get(_appSettings.PopularMovies);
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
