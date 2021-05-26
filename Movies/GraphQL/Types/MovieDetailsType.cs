using HotChocolate.Types;
using Movies.Data.Types;

namespace Movies.GraphQL.Types
{
    public class MovieDetailsType : ObjectType<MovieDetails>
    {
        protected override void Configure(IObjectTypeDescriptor<MovieDetails> descriptor)
        {
            descriptor.Description("All the information about a movie from TMDB.");
            descriptor.Field(f => f.imdb_id).Ignore();
            descriptor.Field(f => f.isAdult).Type<BooleanType>().Name("Adult");

        }
    }
}
