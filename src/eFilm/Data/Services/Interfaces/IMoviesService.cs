using eFilm.Data.Base;
using eFilm.Data.ViewModels;
using eFilm.Models;

namespace eFilm.Data.Services.Interfaces
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);


    }
}
