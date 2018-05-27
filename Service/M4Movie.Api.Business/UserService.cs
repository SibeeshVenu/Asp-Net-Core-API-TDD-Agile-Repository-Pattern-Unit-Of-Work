using M4Movie.Api.Business.Interfaces;
using M4Movie.Api.Contracts;
using M4Movie.Api.Data;
using M4Movie.Api.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4Movie.Api.Business
{
    public class UserService : IUserService
    {
        public UserService(IUnitOfWork unit) => _unitOfWork = unit;

        private IUnitOfWork _unitOfWork { get; }

        public IEnumerable<User> GetUsers() => _unitOfWork.Users.GetAll();

        public void AddUser(User user)
        {
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();
        }

        public void AddToWatchList(WatchList watchList)
        {
            _unitOfWork.WatchLists.Add(watchList);
            _unitOfWork.Complete();
        }

        public IEnumerable<Movie> GetWatchList(int userId) => _unitOfWork.WatchLists.GetWatchList(userId);
    }
}
