using eFilm.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eFilm.Data
{
    public class ApplicationDbContext : IdentityDbContext<AccountUser>
    {
        public DbSet<Actor> ActorsTable { get; set; }
        public DbSet<Movie> MoviesTable { get; set; }
        public DbSet<AccountUser> UsersTable { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            

        }
        public DbSet<eFilm.Models.LoginVM> LoginVM { get; set; }
        public DbSet<eFilm.Models.RegisterVM> RegisterVM { get; set; }

    }
}
