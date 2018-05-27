using M4Movie.Api.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace M4Movie.Api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private MovieApiContext _context { get; }
        public IMovieRepository Movies { get; set; }
        public IUserRepository Users { get; set; }
        public IWatchListRepository WatchLists { get; set; }

        public UnitOfWork(MovieApiContext context)
        {
            _context = context;
            Movies = new MovieRepository(_context);
            Users = new UserRepository(_context);
            WatchLists = new WatchListRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
