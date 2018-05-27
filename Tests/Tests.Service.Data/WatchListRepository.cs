using M4Movie.Api.Contracts;
using M4Movie.Api.Data;
using M4Movie.Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Xunit;

namespace Tests.Service.Data
{
    public class WatchListRepositoryTests
    {
        public readonly MovieApiContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public WatchListRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MovieApiContext>()
                .UseInMemoryDatabase(databaseName: "M4Movie")
                .Options;

            _context = new MovieApiContext(options);
            _unitOfWork = new UnitOfWork(_context);
            AddToWatchLists();
        }

        private void AddToWatchLists()
        {
            _unitOfWork.WatchLists.Add(
                            new WatchList()
                            {
                                MovieId = 1,
                                UserId = 1                                
                            });
            _unitOfWork.Complete();
        }

        [Fact]
        public void Should_Return_WatchLists()
        {
            var watchLists = _unitOfWork.WatchLists.GetAll();
            Assert.NotEmpty(watchLists);
        }

        [Fact]
        public void Shoud_Add_WatchList()
        {
            var watchList = new WatchList()
            {
                MovieId = 2,
                UserId = 1
            };

            _unitOfWork.WatchLists.Add(watchList);
            _unitOfWork.Complete();

            var watchLists = _unitOfWork.WatchLists.GetAll();
            Assert.Contains<WatchList>(watchList, watchLists);
        }

        [Fact]
        public void Should_Return_WatchLists_By_User_Id()
        {
            var watchLists = _unitOfWork.WatchLists.GetWatchList(1);
            Assert.NotEmpty(watchLists);
            Assert.IsType<List<Movie>>(watchLists);
        }
    }
}
