using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOS;

public class FilmeDto
{
   
    [Required(ErrorMessage = "Informação Obrigatória")]
    [StringLength(50)]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "Informação Obrigatória")]
    [StringLength(50, ErrorMessage = "Não exceder o número de caracteres maior que 50")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "Informação Obrigatória")]
    [Range(70, 600, ErrorMessage = "Duração deve ser entre 70 e 600 minutos")]
    public int Duracao { get; set; }
    [MaxLength(225)]
    public string Diretor { get; set; }
}
