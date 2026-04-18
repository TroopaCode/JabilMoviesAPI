using JabilMoviesAPI.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace JabilMoviesAPI.Models.Data
{

    public class JabilMoviesDbContext : DbContext
    {
        public JabilMoviesDbContext(DbContextOptions<JabilMoviesDbContext> options) : base(options)
        {}
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
    }
}
