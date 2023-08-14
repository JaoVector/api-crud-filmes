using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOS; 
public class UpdateCinemaDTO 
{
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
}

