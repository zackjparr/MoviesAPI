using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        MovieDAL m = new MovieDAL();
        public List<Movie> GetMovie()
        {
            return m.GetMovies();
        }


        [HttpGet("GetMoviesByGenre/{genre}")]
        public List<Movie> GetMoviesByGenre(string genre)
        {
            List<Movie> movies = GetMovie();
            List<Movie> genreMovies = new List<Movie>();
            genre = genre.ToLower().ToLower();
            foreach(Movie m in movies)
            {
                if(m.Genre.ToLower().Trim() == genre)
                {
                    genreMovies.Add(m);
                }
            }
            return genreMovies;
        }

        [HttpGet("GetRandom")]
        public Movie GetRandom()
        {
            List<Movie> movies = GetMovie();
            Random rand = new Random();
            return movies[rand.Next(0, movies.Count)];
        }

        [HttpGet("GetRandomByGenre/{genre}")]
        public Movie GetRandomByGenre(string genre)
        {
            Movie m = new Movie();
            List<Movie> movies = GetMoviesByGenre(genre);
            Random r = new Random();
            try
            {
                return movies[r.Next(0, movies.Count)];
            }
            catch (ArgumentOutOfRangeException)
            {
                return m;
            }
        }
    }
}
