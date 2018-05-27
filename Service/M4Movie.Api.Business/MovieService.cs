using M4Movie.Api.Business.Interfaces;
using M4Movie.Api.Contracts;
using M4Movie.Api.Data;
using M4Movie.Api.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4Movie.Api.Business
{
    public class MovieService : IMovieService
    {
        public MovieService(IUnitOfWork unit) => _unitOfWork = unit;

        private IUnitOfWork _unitOfWork { get; }

        public IEnumerable<Movie> GetMovies() => _unitOfWork.Movies.GetAll();

        public void AddMovie(Movie movie)
        {
            _unitOfWork.Movies.Add(movie);
            _unitOfWork.Complete();
        }
    }
}
