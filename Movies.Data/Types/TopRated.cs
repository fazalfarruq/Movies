using Movies.Data.Interfacess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate;

namespace Movies.Data.Types
{
    [GraphQLDescription("All time top rated movies.")]

    public class TopRated : Movie
    {
    }
}
