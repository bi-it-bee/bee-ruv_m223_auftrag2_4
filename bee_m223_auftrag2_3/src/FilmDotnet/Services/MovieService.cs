using System;

namespace bee_m223_auftrag2_3.src.FilmDotnet.Services
{
    public class MovieService
    {
        private readonly DatabaseContext _databaseContext;

        public MovieService(DatabaseContext context)
        {
            _databaseContext = context;
        }

        
    }
}