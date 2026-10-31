using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace bee_m223_auftrag2_3.Models {
    public class DatabaseContext : DbContext{
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        public DbSet<Film> Films { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
