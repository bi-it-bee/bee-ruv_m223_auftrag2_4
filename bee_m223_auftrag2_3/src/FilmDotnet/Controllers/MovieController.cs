using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bee_m223_auftrag2_3.src.FilmDotnet.Controllers
{
    [Route("movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _movieService;

        public UserController(MovieService movieService)
        {
            _movieService = _movieService;
        }


    }
}
