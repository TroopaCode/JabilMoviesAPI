using AutoMapper;
using JabilMoviesAPI.Models.Data;
using JabilMoviesAPI.Models.DTOs;
using JabilMoviesAPI.Models.Entity;
using JabilMoviesAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JabilMoviesAPI.Services
{
    public class DirectorsServices : IService<DirectorDTO, DirectorInsertDTO, DirectorUpdateDTO>
    {
        private JabilMoviesDbContext _context;
        private IMapper _mapper;
        public DirectorsServices(JabilMoviesDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DirectorDTO>> GetAll()
        {
            var directors = await _context.Directors.ToListAsync();
            return _mapper.Map<IEnumerable<DirectorDTO>>(directors);
        }

        public async Task<DirectorDTO> GetById(int id)
        {
            var director = _context.Directors.FirstOrDefault(m => m.Id == id);
            return _mapper.Map<DirectorDTO>(director);
        }

        public async Task<DirectorDTO> Create(DirectorInsertDTO TEntityInsert)
        {
            var director = _mapper.Map<Director>(TEntityInsert);
            _context.Directors.Add(director);
            _context.SaveChanges();
            return _mapper.Map<DirectorDTO>(director);
        }
        public async Task<bool> Update(int id, DirectorUpdateDTO TEntityUpdate)
        {
            var director = _context.Directors.FirstOrDefault(m => m.Id == id);
            if (director == null)
            {
                return false;
            }
            _mapper.Map(TEntityUpdate, director); //Mapeo de los datos del DTO al objeto existente
            _context.SaveChanges();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var director = _context.Directors.FirstOrDefault(m => m.Id == id);
            if (director == null)
            {
                return false;
            }
            _context.Directors.Remove(director);
            _context.SaveChanges();
            return true;
        }




    }
}
