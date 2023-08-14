using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Data.DTOS;
using FilmesApi.Models;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace FilmesApi.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        CreateMap<CinemaDTO, Cinema>();
        CreateMap<Cinema, ReadCinemaDTO>().ForMember(cinemaDTO => cinemaDTO.Endereco, opt => opt.MapFrom(cinema => cinema.Endereco)).ForMember(cinemaDTO => cinemaDTO.Sessoes, opt => opt.MapFrom(cinema => cinema.Sessoes));
        CreateMap<UpdateCinemaDTO, Cinema>();
    }
    
}
