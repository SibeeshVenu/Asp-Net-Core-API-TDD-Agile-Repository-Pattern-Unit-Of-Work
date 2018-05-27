using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M4Movie.Api.Business;
using M4Movie.Api.Business.Interfaces;
using M4Movie.Api.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace M4Movie_Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Movie")]
    public class MovieController : ControllerBase
    {
        public MovieController(IMovieService movieService)
        {
            MovieService = movieService;
        }

        public IMovieService MovieService { get; }

        [HttpGet]
        public IActionResult Get()
        {
            //[{"movieId":1,"movieName":"Deadpool 2","movieDescription":"Foul-mouthed mutant mercenary Wade Wilson (AKA. Deadpool).","movieImage":"https://ia.media-imdb.com/images/M/MV5BMjI3Njg3MzAxNF5BMl5BanBnXkFtZTgwNjI2OTY0NTM@._V1_UX182_CR0,0,182,268_AL_.jpg","moviRating":"8.2/10"},{"movieId":2,"movieName":"Avengers: Infinity War (2018)","movieDescription":"The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos","movieImage":"https://ia.media-imdb.com/images/M/MV5BMjMxNjY2MDU1OV5BMl5BanBnXkFtZTgwNzY1MTUwNTM@._V1_UX182_CR0,0,182,268_AL_.jpg","moviRating":"8.8/10"}]
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var movies = MovieService.GetMovies();
            return Ok(movies);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                MovieService.AddMovie(movie);
                return Ok(movie);
            }
            catch (Exception)
            {
                return BadRequest(ModelState);
            }            
        }       

    }
}