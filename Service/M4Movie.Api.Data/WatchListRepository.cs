using M4Movie.Api.Contracts;
using M4Movie.Api.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4Movie.Api.Data
{
    public class WatchListRepository : Repository<WatchList>, IWatchListRepository
    {
        public WatchListRepository(DbContext context) : base(context)
        {

        }

        public IEnumerable<Movie> GetWatchList(int userId)
        {
            List<Movie> movies = new List<Movie>();
            var watchLists = Context.Set<WatchList>().Where(itm => itm.UserId == userId);
            foreach (var item in watchLists)
            {
                movies.Add(Context.Set<Movie>().SingleOrDefault(itm => itm.MovieId == item.MovieId));
            }
            return movies;
        }
    }
}
