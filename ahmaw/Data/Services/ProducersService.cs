using eFilm.Data.Base;
using eFilm.Data.Services.Interfaces;
using eFilm.Models;

namespace eFilm.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(ApplicationDbContext context) : base(context) { }
    }
}
