using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M4Movie.Api.Business.Interfaces;
using M4Movie.Api.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M4Movie_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        public IUserService UserService { get; }

        [HttpGet]
        public IActionResult GetWatchList(int userId)
        {
            //[{"movieId":1,"movieName":"Deadpool 2","movieDescription":"Foul-mouthed mutant mercenary Wade Wilson (AKA. Deadpool).","movieImage":"https://ia.media-imdb.com/images/M/MV5BMjI3Njg3MzAxNF5BMl5BanBnXkFtZTgwNjI2OTY0NTM@._V1_UX182_CR0,0,182,268_AL_.jpg","moviRating":"8.2/10"},{"movieId":2,"movieName":"Avengers: Infinity War (2018)","movieDescription":"The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos","movieImage":"https://ia.media-imdb.com/images/M/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_UX182_CR0,0,182,268_AL_.jpg","moviRating":"8.8/10"}]
            if (!ModelState.IsValid) return BadRequest(ModelState);
            userId = 1;
            var movies = UserService.GetWatchList(userId);
            return Ok(movies);
        }

        [HttpPost]
        public IActionResult AddToWatchList(WatchList watchList)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                watchList.UserId = 1;
                UserService.AddToWatchList(watchList);
                return Ok(watchList);
            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }
        }
    }
}