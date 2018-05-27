using M4Movie.Api.Business;
using M4Movie.Api.Business.Interfaces;
using M4Movie.Api.Contracts;
using M4Movie.Api.Data.Interfaces;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Tests.Service.Business
{
    public class MovieServiceTests
    {
        //private Mock<IUnitOfWork> _mock;
        //private IMovieService _movieService;

        //[Fact]
        //public void SetUp()
        //{
        //    _mock = new Moq.Mock<IUnitOfWork>();
        //    _movieService = new MovieService(_mock.Object);
        //}

        //[Fact]
        //public void GetMovies_Return_Correctly()
        //{
        //    _mock.Setup(item => item.Movies.GetAll()).Returns(It.IsAny<List<Movie>>());
        //    var actual = _movieService.GetMovies();
        //    Assert.NotNull(actual);
        //}

        //[Fact]
        //public void GetMovies_UnitOfService_GetAll_Called_Correctly()
        //{
        //    _mock.Setup(item => item.Movies.GetAll()).Returns(It.IsAny<List<Movie>>());
        //    var actual = _movieService.GetMovies();
        //    _mock.Verify(item => item.Movies.GetAll(), Times.Once);
        //}
    }
}
