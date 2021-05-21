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
        private readonly IAppSettings _appSettings;



        public MoviesController(ILogger<MoviesController> logger,
            IMovieService<MovieDetails> service,
            IAppSettings appSettings)
        {
            _logger = logger;
            _service = service;
            _appSettings = appSettings;
        }

        [HttpGet]
        public async Task<MovieDetails> Get()
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
    }
}
