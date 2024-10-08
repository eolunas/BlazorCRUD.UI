﻿using BlazorCRUD.Data.Dapper.Repositories;
using BlazorCRUD.Interfaces;
using BlazorCRUD.Model;
using System.Data;

namespace BlazorCRUD.Services
{
    public class FilmService : IFilmService
    {
        private readonly IDbConnection _dbConnection;
        private IFilmRepository _filmRepository;

        public FilmService(IDbConnection dbConnection) {
            _dbConnection = dbConnection;
            _filmRepository = new FilmRepository(dbConnection.ConnectionString);
        }  

        Task<IEnumerable<Film>> IFilmService.GetAllFilms()
        {
            return _filmRepository.GetAllFilms();
        }

        Task<Film> IFilmService.GetFilmDetails(int id)
        {
            return _filmRepository.GetFilmDetails(id);
        }

        Task<bool> IFilmService.InsertFilm(Film film)
        {
            throw new NotImplementedException();
        }

        Task<bool> IFilmService.SaveFilm(Film film)
        {
            if (film.Id == 0)
                return _filmRepository.InsertFilm(film);
            else
                return _filmRepository.UpdateFilm(film);
        }
    }
}
