using AutoMapper;
using JabilMoviesAPI.Mapping;
using JabilMoviesAPI.Models.Data;
using JabilMoviesAPI.Models.DTOs;
using JabilMoviesAPI.Models.Entity;
using JabilMoviesAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JabilMoviesAPI.Services
{
    public class MoviesServices : IService<MoviesDTO, MoviesInsertDTO, MoviesUpdateDTO>
    {
        private JabilMoviesDbContext _context;
        private IMapper _mapper; //IMapper

        public MoviesServices(JabilMoviesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MoviesDTO>> GetAll()
        {
            var movies = await _context.Movies.ToListAsync();
            return _mapper.Map<IEnumerable<MoviesDTO>>(movies);
        }

        public async Task<MoviesDTO> GetById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            return _mapper.Map<MoviesDTO>(movie);
        }

        public async Task<MoviesDTO> Create(MoviesInsertDTO TEntityInsert)
        {
            var movie = _mapper.Map<Movies>(TEntityInsert);
            var director = _context.Directors.FirstOrDefault(d => d.Id == TEntityInsert.DirectorId);
            movie.Director = director; // Asignar el director al objeto película
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return _mapper.Map<MoviesDTO>(movie);
        }
        public async Task<bool> Update(int id, MoviesUpdateDTO TEntityUpdate)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return false;
            }
            _mapper.Map(TEntityUpdate, movie); //Mapeo de los datos del DTO al objeto existente
            _context.SaveChanges();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return false;
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return true;
        }
        
    }
}
