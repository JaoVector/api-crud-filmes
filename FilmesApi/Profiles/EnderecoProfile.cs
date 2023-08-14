using AutoMapper;
using FilmesApi.Data.DTOS;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class EnderecoProfile : Profile
{
	public EnderecoProfile()
	{
		CreateMap<EnderecoDTO, Endereco>();
		CreateMap<UpdateEnderecoDTO, Endereco>();
		CreateMap<Endereco, ReadEnderecoDTO>();
	}
}
