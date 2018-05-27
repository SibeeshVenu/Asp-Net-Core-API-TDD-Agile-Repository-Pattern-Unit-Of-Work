using M4Movie.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace M4Movie.Api.Data
{
    class SeedDataToDatabase
    {
        public static void Initialize(MovieApiContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var user = new User { UserEmail = "sibikv4u@gmail.com", UserName = "sibeeshvenu", UserImage = "https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RE1Mu3b?ver=5c31" };

            context.Users.Add(user);
            context.SaveChanges();

            var movies = new Movie[]
            {
                new Movie(){
                    MovieDescription ="Foul-mouthed mutant mercenary Wade Wilson (AKA. Deadpool).",
                    MovieImage="https://ia.media-imdb.com/images/M/MV5BMjI3Njg3MzAxNF5BMl5BanBnXkFtZTgwNjI2OTY0NTM@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    MovieName="Deadpool 2",
                    MoviRating="8.2/10"
                },
                new Movie(){
                    MovieDescription ="The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos",
                    MovieImage="https://ia.media-imdb.com/images/M/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_UX182_CR0,0,182,268_AL_.jpg",
                    MovieName="Avengers: Infinity War (2018)",
                    MoviRating="8.8/10"
                }
            };

            foreach (Movie i in movies)
            {
                context.Movies.Add(i);
            }
            context.SaveChanges();

            var watchLists = new WatchList()
            {
                MovieId = 1,
                UserId = 1
            };

            context.WatchLists.Add(watchLists);
            context.SaveChanges();
        }
    }
}
