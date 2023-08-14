using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOS;

public class CinemaDTO
{
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    public int EnderecoId { get; set; }
}
