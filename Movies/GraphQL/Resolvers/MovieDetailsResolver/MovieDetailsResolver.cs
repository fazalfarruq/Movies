using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.Extensions.Logging;
using Movies.Data.Interfacess;
using Movies.Data.Types;

namespace Movies.GraphQL.Resolvers.MovieDetailsResolver
{
    public class MovieDetailsResolver
    {
        [UseFiltering]
        [UseSorting]
        public async Task<MovieDetails> GetMovieDetails(string movieId,
            [Service] IMovieService<MovieDetails> _service,
            [Service] IAppSettings _appSettings,
            [Service] ILogger<MovieDetailsResolver> _logger)
        {
            try
            {
                string query = string.Format(_appSettings.MovieDetails, "550");
                if (!string.IsNullOrEmpty(movieId))
                    query = string.Format(_appSettings.MovieDetails, movieId);
                var result = await _service.Get(query);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return default;
            }

        }
    }
}
