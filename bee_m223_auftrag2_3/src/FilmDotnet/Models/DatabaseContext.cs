using bee_m223_auftrag2_3.Models;
using Microsoft.EntityFrameworkCore;

namespace bee_m223_auftrag2_3.src.FilmDotnet.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Map> Maps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().ToTable("Movie");

        modelBuilder.Entity<User>().ToTable("User")
        .HasMany(user => user.Movies)
        .WithMany(movie => movie.Users)
        .UsingEntity("user_movie",
        movie => movie.HasOne(typeof(Movie))
        .WithMany()
        .HasForeignKey("movie_id"),

        user => user.HasOne(typeof(User))
        .WithMany()
        .HasForeignKey("user_id")
        );

        modelBuilder.Entity<Map>().ToTable("Map")
        .HasMany(map => map.Movies)
        .WithMany(movie => movie.Maps)
        .UsingEntity("movie_map",

        movie => movie.HasOne(typeof(Movie))
        .WithMany()
        .HasForeignKey("movie_id"),

        map => map.HasOne(typeof(Map))
        .WithMany()
        .HasForeignKey("map_id")
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Host=db;Database=movies;Username=postgres;Password=postgres"
            );
}