using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Types
{
    public class MovieWrapper<T> where T: Movie
    {
        public Dates dates { get; set; }
        public int page { get; set; }
        public List<T> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }

    public class Dates
    {
        public string maximum { get; set; }
        public string minimum { get; set; }
    }
}
