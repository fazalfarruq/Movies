using Microsoft.Extensions.Configuration;
using Movies.Data.Interfacess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Types
{
    public class AppSettings : IAppSettings
    {
        private readonly IConfiguration _configuration;

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string MovieDetails => _configuration["Config:MovieDetails"];

        public string MovieReview => _configuration["Config:MovieReview"];

        public string UpcomingMovies => _configuration["Config:UpcomingMovies"];


    }
}
