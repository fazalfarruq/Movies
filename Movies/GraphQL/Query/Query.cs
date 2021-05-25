using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.Extensions.Logging;
using Movies.Data.Interfacess;
using Movies.Data.Types;
using WebApplication2.Controllers;

namespace Movies.GraphQL.Query
{
    [GraphQLDescription("Root Query")]
    public class Query
    {
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<TopRated>> GeTopRatedMovies([Service] IMovieService<MovieWrapper<TopRated>> _service,
            [Service] IAppSettings _appSettings, [Service] ILogger<Query> _logger)
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
        
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<Popular>> GePopularMovies([Service] IMovieService<MovieWrapper<Popular>> _service,
            [Service] IAppSettings _appSettings, [Service] ILogger<Query> _logger)
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

        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<UpComing>> GeUpComingMovies([Service] IMovieService<MovieWrapper<UpComing>> _service,
            [Service] IAppSettings _appSettings, [Service] ILogger<Query> _logger)
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

        [UseFiltering]
        [UseSorting]
        public async Task<MovieDetails> GetMovieDetails([Service] IMovieService<MovieDetails> _service,
            [Service] IAppSettings _appSettings,
            [Service] ILogger<Query> _logger,
            string movieId = "")
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
