using Core;
using eFilm.Data;
using eFilm.Data.Base;
using Service.Interfaces;

namespace Service
{
    public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService

    {
        public CinemasService(ApplicationDbContext context) : base(context) { }

    }

}
