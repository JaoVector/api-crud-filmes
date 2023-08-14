using AutoMapper;
using FilmesApi.Data.DTOS;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class SessaoProfile : Profile
{
	public SessaoProfile()
	{
		CreateMap<CreateSessaoDTO, Sessao>();
		CreateMap<Sessao, ReadSessaoDTO>();

	}
}
