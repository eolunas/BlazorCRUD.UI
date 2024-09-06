using BlazorCRUD.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Data.Dapper.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private string ConnectionString;
        public FilmRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected SqlConnection dbConnection() { 
            return new SqlConnection(ConnectionString);
        }

        Task<bool> IFilmRepository.DeleteFilm(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Film>> IFilmRepository.GetAllFilms()
        {
            throw new NotImplementedException();
        }

        Task<Film> IFilmRepository.GetFilmDetails(int id)
        {
            throw new NotImplementedException();
        }

        async Task<bool> IFilmRepository.InsertFilm(Film film)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO Films (Title, Director, ReleaseDate)
                        VALUES (@Title, @Director, @ReleaseDate)";

            var result = await db.ExecuteAsync(sql.ToString(), 
                new { film.Title, film.Director, film.ReleaseDate});


            return result > 0;
        }

        Task<bool> IFilmRepository.UpdateFilm(Film film)
        {
            throw new NotImplementedException();
        }
    }
}
