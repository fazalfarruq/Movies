using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Movies.Data.Interfacess;
using Movies.Data.Types;
using Movies.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Server.Ui.Voyager;
using Movies.GraphQL.MovieDetailsType;
using Movies.GraphQL.PopularMoviesType;
using Movies.GraphQL.Query;

namespace Movies
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSingleton<IAppSettings, AppSettings>();
            services.AddScoped<IHttpClientService, HttpClientService>();
            services.AddScoped<IMovieService<MovieDetails>, MovieService<MovieDetails>>();
            services.AddScoped<IMovieService<MovieWrapper<TopRated>>, MovieService<MovieWrapper<TopRated>>>();
            services.AddScoped<IMovieService<MovieWrapper<Popular>>, MovieService<MovieWrapper<Popular>>>();
            services.AddScoped<IMovieService<MovieWrapper<UpComing>>, MovieService<MovieWrapper<UpComing>>>();
            services.AddScoped<IMovieService<MovieReview>, MovieService<MovieReview>>();

            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<MovieDetailsType>()
                .AddType<PopularMoviesType>()
                .AddType<TopRatedMoviesType>()
                .AddType<UpcomingMoviesType>()
                .AddFiltering()
                .AddSorting();
            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
             {
                 endpoints.MapGraphQL();
                 endpoints.MapGraphQLVoyager("/voyager");
             });

            app.UseGraphQLVoyager(new VoyagerOptions()
            {
                GraphQLEndPoint = "/graphql",
                
            });
        }
    }
}
