using BlazorCRUD.Model;

namespace BlazorCRUD.Interfaces
{
    public interface IFilmService
    {
        Task<IEnumerable<Film>> GetAllFilms();
        Task<Film> GetFilmDetails(int id);
        Task<bool> InsertFilm(Film film);
        Task<bool> SaveFilm(Film film);
    }
}
