using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using Movies.Data.Types;

namespace Movies.GraphQL.Types
{
    public class TopRatedMoviesType : ObjectType<TopRated>
    {
        protected override void Configure(IObjectTypeDescriptor<TopRated> descriptor)
        {
            descriptor.Description("All the top rated movies.");
            descriptor.Field(f => f.isAdult).Type<BooleanType>().Name("Adult");
        }
    }
}
