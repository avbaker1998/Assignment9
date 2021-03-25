using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Models
{
    public static class tempStorage
    {
        private static List<MoviesModel> movieList = new List<MoviesModel>();
        public static IEnumerable<MoviesModel> Movies => movieList;
        public static void AddMovie(MoviesModel movies)
        {
            movieList.Add(movies);
        }
    }
}
