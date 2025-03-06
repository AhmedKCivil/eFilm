using eFilm.Data.Base;
using eFilm.Models;
using System.Threading.Tasks;

namespace eFilm.Data.Services.Interfaces
{
    public interface IActorsService : IEntityBaseRepository<Actor>
    {
        Task AddAsync(Actor actor);
    }

}
