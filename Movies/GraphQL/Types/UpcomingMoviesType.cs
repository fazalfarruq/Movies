using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using Movies.Data.Types;

namespace Movies.GraphQL.Types
{
    public class UpcomingMoviesType : ObjectType<UpComing>
    {
        protected override void Configure(IObjectTypeDescriptor<UpComing> descriptor)
        {
            descriptor.Description("All the upcoming movies.");
            descriptor.Field(f => f.isAdult).Type<BooleanType>().Name("Adult");
        }
    }
}
