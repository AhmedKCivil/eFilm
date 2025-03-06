using Core;
using eFilm.Data;
using eFilm.Data.Base;
using Service.Interfaces;

namespace Service
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(ApplicationDbContext context) : base(context) { }
    }
}
