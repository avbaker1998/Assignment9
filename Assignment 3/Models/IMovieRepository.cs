using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_3.Models
{
    public interface IMovieRepository
    {
        IQueryable<MoviesModel> Movies { get; }
    }
}
