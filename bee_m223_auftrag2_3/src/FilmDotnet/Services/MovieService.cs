using bee_m223_auftrag2_3.Models;
using bee_m223_auftrag2_3.src.FilmDotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace bee_m223_auftrag2_3.FilmDotnet.Services
{
    public class MovieService
    {
        private readonly DatabaseContext _databaseContext;

        public MovieService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<MovieDTO>> FindAll()
        {
            var movies = await _databaseContext.Movies.Include(movie => movie.Users).Include(movie => movie.Maps)
                .ToListAsync();
    
            var movieDtos = movies.Select(movie => new MovieDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Duration = movie.Duration,
                    Description =  movie.Description,
                    Users = movie.Users,
                    Maps = movie.Maps
                }
                ).ToList();
            return movieDtos;
        }

        public async Task<Movie> Add(Movie movie)
        {
            _databaseContext.Movies.Add(movie);
            await _databaseContext.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> FindById(int id)
        {
            return await _databaseContext.Movies.FindAsync(id);
        }

        public async Task DeleteMovie(Movie movie)
        {
            _databaseContext.Movies.Remove(movie);
            await _databaseContext.SaveChangesAsync();
            
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            _databaseContext.Movies.Update(movie);
            await _databaseContext.SaveChangesAsync();
            return movie;
        }
    }
}