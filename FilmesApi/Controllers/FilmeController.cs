using AutoMapper;
using Azure;
using FilmesApi.Data;
using FilmesApi.Data.DTOS;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    
    private readonly FilmeContext _context;
    private readonly IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
   
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    //Informação vem do corpo da requisição
    public IActionResult AdicionaFilem([FromBody]FilmeDto filmeDto) 
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmeId), new {id = filme.Id}, filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> ConsultaFilmes([FromQuery] int skip = 0, [FromQuery] int take = 5, [FromQuery] string? nomeCinema = null) 
    {
        if (nomeCinema == null) 
        {
            return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
        }
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take).Where(filme => filme.Sessoes.Any(sessao => sessao.Cinema.Nome == nomeCinema)).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmeId(int id) 
    {
       var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);

        return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody]FilmeDtoUpdate filmeDto) 
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme == null) return NotFound("Filme não encontrado");
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmeId), new { id = filme.Id }, filme);
    }

    [HttpPatch]
    public IActionResult AtualizaFilmePorAtributo(int id, JsonPatchDocument<FilmeDtoUpdate> jsonPatch) 
    {
        var filme = _context.Filmes.FirstOrDefault(x => x.Id == id);
        if (filme == null) return NotFound("Filme não encontrado");

        var filmeParcial = _mapper.Map<FilmeDtoUpdate>(filme);
        jsonPatch.ApplyTo(filmeParcial, ModelState);

        if (!TryValidateModel(filmeParcial))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParcial, filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmeId), new { id = filme.Id }, filme);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeletaFilme(int id) 
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null) return NotFound();

        _context.Remove(filme);
        _context.SaveChanges();

        return NoContent();
    }
}

