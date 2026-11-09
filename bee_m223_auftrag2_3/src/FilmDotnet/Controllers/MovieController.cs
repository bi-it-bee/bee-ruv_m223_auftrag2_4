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

    }
}
