using M4Movie.Api.Contracts;
using M4Movie.Api.Data;
using M4Movie.Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests.Service.Data
{
    public class UserRepositoryTests
    {
        public readonly MovieApiContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public UserRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<MovieApiContext>()
                .UseInMemoryDatabase(databaseName: "M4Movie")
                .Options;

            _context = new MovieApiContext(options);
            _unitOfWork = new UnitOfWork(_context);
            AddUser();
        }

        private void AddUser()
        {
            _unitOfWork.Users.Add(
                            new User()
                            {
                                UserEmail ="a@a.a",
                                UserImage ="Test.png",
                                UserName ="Test"
                            });
            _unitOfWork.Complete();
        }

        [Fact]
        public void Should_Return_Users()
        {
            var users = _unitOfWork.Users.GetAll();
            Assert.NotEmpty(users);
        }

        [Fact]
        public void Shoud_Add_User()
        {
            var user = new User()
            {
                UserEmail = "b@b.b",
                UserImage = "Test1.png",
                UserName = "Test1"
            };

            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();

            var users = _unitOfWork.Users.GetAll();
            Assert.Contains<User>(user, users);
        }
    }
}
