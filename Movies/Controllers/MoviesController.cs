using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movies.Data.Interfacess;
using Movies.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {


        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieService<MovieDetails> _service;
        private readonly IMovieService<MovieWrapper<TopRated>> _topRatedService;
        private readonly IMovieService<MovieWrapper<Popular>> _popularService;
        private readonly IMovieService<MovieWrapper<UpComing>> _upcomingService;
        private readonly IMovieService<MovieReview> _movieReviewService;



        private readonly IAppSettings _appSettings;



        public MoviesController(ILogger<MoviesController> logger,
            IMovieService<MovieDetails> service,
            IAppSettings appSettings,
            IMovieService<MovieWrapper<TopRated>> topRatedService,
            IMovieService<MovieWrapper<Popular>> popularService,
            IMovieService<MovieWrapper<UpComing>> upcomingService,
            IMovieService<MovieReview> movieReviewService)
        {
            _logger = logger;
            _service = service;
            _appSettings = appSettings;
            _topRatedService = topRatedService;
            _popularService = popularService;
            _upcomingService = upcomingService;
            _movieReviewService = movieReviewService;
        }

        [HttpGet, Route("Details")]
        public async Task<MovieDetails> Details()
        {
            try
            {
                var query = string.Format(_appSettings.MovieDetails, "550");
                var result = await _service.Get(query);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return default;
            }
        }

        [HttpGet, Route("Top")]
        public async Task<IEnumerable<TopRated>> Top()
        {
            try
            {

                var result = await _topRatedService.Get(_appSettings.TopRatedMovies);
                return result.results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return default;
            }
        }

        [HttpGet, Route("Popular")]
        public async Task<IEnumerable<Popular>> Popular()
        {
            try
            {

                var result = await _popularService.Get(_appSettings.PopularMovies);
                return result.results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return default;
            }
        }

        [HttpGet, Route("Upcoming")]
        public async Task<IEnumerable<UpComing>> Upcoming()
        {
            try
            {

                var result = await _upcomingService.Get(_appSettings.UpcomingMovies);
                return result.results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return default;
            }
        }

        [HttpGet, Route("Review/{movieId}")]
        public async Task<MovieReview> Review(int movieId)
        {
            try
            {
                var reviewUrl = string.Format(_appSettings.MovieReview, movieId);
                var result = await _movieReviewService.Get(reviewUrl);
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
