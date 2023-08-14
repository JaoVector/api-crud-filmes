using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOS;

public class UsuarioDTO
{
    [Required]
    public string Username { get; set; }

    [Required]
    public DateTime DataNasc { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string CompPassword { get; set; }
}
