using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using Movies.Data.Types;

namespace Movies.GraphQL.PopularMoviesType
{
    public class PopularMoviesType : ObjectType<Popular>
    {
        protected override void Configure(IObjectTypeDescriptor<Popular> descriptor)
        {
            descriptor.Description("All time popular movies.");
            descriptor.Field(f => f.isAdult).Type<BooleanType>().Name("Adult");
        }
    }
}
