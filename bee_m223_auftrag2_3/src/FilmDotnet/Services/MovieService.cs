using System;
using bee_m223_auftrag2_3.Models;
using bee_m223_auftrag2_3.src.FilmDotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace bee_m223_auftrag2_3.src.FilmDotnet.Services
{
    public class MovieService
    {
        private readonly DatabaseContext _databaseContext;

        public MovieService(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public async Task<List<MovieDTO>> FindAll()
        {
            var movies = await _databaseContext.Movies.Include(movie ) 
        }
    }
}