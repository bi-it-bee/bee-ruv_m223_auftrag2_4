using bee_m223_auftrag2_3.Models;
using Microsoft.EntityFrameworkCore;

namespace bee_m223_auftrag2_3.Services
{
    public class UserService
    {
        private readonly DatabaseContext _databaseContext;

        public UserService(DatabaseContext context)
        {
            _databaseContext = context;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await _databaseContext.Users.ToListAsync();
            return users.Select(u => new UserDTO
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email
            }).ToList();
        }
    }
}