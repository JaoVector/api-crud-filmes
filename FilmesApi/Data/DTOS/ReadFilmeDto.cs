using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOS;

public class ReadFilmeDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public int Duracao { get; set; }
    public DateTime DataConsulta { get; set; } = DateTime.Now;
    public ICollection<ReadSessaoDTO> Sessoes { get; set; }

}
