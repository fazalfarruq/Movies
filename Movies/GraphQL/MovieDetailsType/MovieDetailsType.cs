using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using Movies.Data.Types;

namespace Movies.GraphQL.MovieDetailsType
{
    public class MovieDetailsType : ObjectType<MovieDetails>
    {
        protected override void Configure(IObjectTypeDescriptor<MovieDetails> descriptor)
        {
            descriptor.Description("All the information about a movie from TMDB.");
            descriptor.Field(f => f.imdb_id).Ignore();
        }
    }
}
