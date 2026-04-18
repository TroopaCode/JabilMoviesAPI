using AutoMapper;
using JabilMoviesAPI.Models.DTOs;
using JabilMoviesAPI.Models.Entity;

namespace JabilMoviesAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movies, MoviesDTO>();
            CreateMap<MoviesInsertDTO, Movies>();
            CreateMap<MoviesUpdateDTO, Movies>();
    
            CreateMap<Director, DirectorDTO>();
            CreateMap<DirectorInsertDTO, Director>();
            CreateMap<DirectorUpdateDTO, Director>();

            //Este mapeo es para que al insertar una película o Director,
            //el Id se ignore y no se intente insertar en la base de datos, ya que son campos autoincrementales.
            CreateMap<MoviesInsertDTO, MoviesDTO>().ForMember(gg => gg.Id, op => op.Ignore());
            CreateMap<DirectorInsertDTO, DirectorDTO>().ForMember(gg => gg.Id, op => op.Ignore());

        }
    }
}
