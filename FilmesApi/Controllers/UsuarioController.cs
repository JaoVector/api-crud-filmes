using FilmesApi.Data.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    public IActionResult CadastraUsuario(UsuarioDTO usuarioDTO) 
    {
        throw new NotImplementedException();
    }

}
