using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.Extensions.Logging;
using Movies.Data.Interfacess;
using Movies.Data.Types;
using Movies.GraphQL.PopularMoviesType;
using Movies.GraphQL.Resolvers.MovieDetailsResolver;
using Movies.GraphQL.Resolvers.PopularMoviesResolver;
using Movies.GraphQL.Resolvers.TopRatedMoviesResolver;
using Movies.GraphQL.Resolvers.UpcomingMoviesResolver;
using Movies.GraphQL.Types;

namespace Movies.GraphQL.Query
{
    public class QueryType : ObjectTypeExtension
    {

        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Query").Description("Base Query");

            descriptor.Field("GetMovieDetails")
                .ResolveWith<MovieDetailsResolver>(q => q.GetMovieDetails(default, default, default, default))
                .Argument("movieId", _ => _.Type<IntType>())
                .Type<MovieDetailsType>()
                .Name("MovieDetails");

            descriptor.Field("GetTopRatedMovies")
                .ResolveWith<TopRatedMoviesResolver>(q => q.GetTopRatedMovies(default, default, default))
                .Type<ListType<TopRatedMoviesType>>()
                .Name("AllTopRatedMovies");

            descriptor.Field("GetPopularMovies")
                .ResolveWith<PopularMoviesResolver>(q => q.GetPopularMovies(default, default, default))
                .Type<ListType<PopularMoviesType.PopularMoviesType>>()
                .Name("AllPopularMovies");

            descriptor.Field("GetUpComingMovies")
                .ResolveWith<UpcomingMoviesResolver>(q => q.GetUpComingMovies(default, default, default))
                .Type<ListType<UpcomingMoviesType>>()
                .Name("AllUpcomingMovies");
        }
    }
}
