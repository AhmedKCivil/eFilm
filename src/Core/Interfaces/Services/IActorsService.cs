using Core;
using Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IActorsService : IEntityBaseRepository<Actor>
    {
        Task AddAsync(Actor actor);
    }

}
