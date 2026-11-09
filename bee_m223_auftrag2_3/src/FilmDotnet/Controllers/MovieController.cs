using bee_m223_auftrag2_3.FilmDotnet.Services;
using bee_m223_auftrag2_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace bee_m223_auftrag2_3.FilmDotnet.Controllers
{
    [Route("movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allMovies = await _movieService.FindAll();
            var result = allMovies.Select(movie =>
                new MovieDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description
                });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieDTO movieDto)
        {
            var movie = new Movie
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                Duration = movieDto.Duration

            };

            var newMovie = await _movieService.Add(movie);

            var result =
                new MovieDTO
                {
                    Id = newMovie.Id,
                    Title = newMovie.Title,
                    Description = newMovie.Description,
                    Duration = newMovie.Duration
                };

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieService.FindById(id);

            if (movie == null)
            {
                return NotFound();
            }

            await _movieService.DeleteMovie(movie);
            
            return Ok();
        }

    }
}
