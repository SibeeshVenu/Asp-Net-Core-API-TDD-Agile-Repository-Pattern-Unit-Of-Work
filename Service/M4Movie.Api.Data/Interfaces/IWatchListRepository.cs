using M4Movie.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4Movie.Api.Data.Interfaces
{
    public interface IWatchListRepository: IRepository<WatchList>
    {
        IEnumerable<Movie> GetWatchList(int userId);
    }
}
