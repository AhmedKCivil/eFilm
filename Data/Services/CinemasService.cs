using eFilm.Data.Base;
using eFilm.Data.Services.Interfaces;
using eFilm.Models;

namespace eFilm.Data.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService

    {
        public CinemasService(ApplicationDbContext context) : base(context) { }

    }
    
}
