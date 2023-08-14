using AutoMapper;
using FilmesApi.Data.DTOS;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile() 
    {
        CreateMap<FilmeDto, Filme>();
        CreateMap<FilmeDtoUpdate, Filme>();
        CreateMap<Filme, FilmeDtoUpdate>();
        CreateMap<Filme, ReadFilmeDto>().ForMember(filmeDTO => filmeDTO.Sessoes, opt => opt.MapFrom(filme => filme.Sessoes));

    }
}
