using M4Movie.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4Movie.Api.Business.Interfaces
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetMovies();
        void AddMovie(Movie movie);
    }
}
