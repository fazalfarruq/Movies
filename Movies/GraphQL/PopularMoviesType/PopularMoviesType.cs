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
        }
    }

    public class UpcomingMoviesType : ObjectType<UpComing>
    {
        protected override void Configure(IObjectTypeDescriptor<UpComing> descriptor)
        {
            descriptor.Description("All the upcoming movies.");
        }
    }


    public class TopRatedMoviesType : ObjectType<TopRated>
    {
        protected override void Configure(IObjectTypeDescriptor<TopRated> descriptor)
        {
            descriptor.Description("All the top rated movies.");
        }
    }

}
