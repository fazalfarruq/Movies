using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Types
{
    public abstract class Movie
    {
        [JsonProperty("adult")]
        public bool isAdult {get;}
        public string backdrop_path {get;}
        public List<int> genre_ids {get;}
        public int id {get;}
        public string original_language {get;}
        public string original_title {get;}
        public string overview {get;}
        public double popularity {get;}
        public string poster_path {get;}
        public string release_date {get;}
        public string title {get;}
        public bool video {get;}
        public double vote_average {get;}
        public int vote_count {get;}
    }
}
