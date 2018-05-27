using M4Movie.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4Movie.Api.Business.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        void AddUser(User movie);
        void AddToWatchList(WatchList watchList);
        IEnumerable<Movie> GetWatchList(int userId);
    }
}
