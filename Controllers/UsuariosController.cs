using Microsoft.AspNetCore.Mvc;
using pedidos.Models;
using pedidos.Services;

namespace pedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        public UsuariosService _service;

        public UsuariosController(UsuariosService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get-usuarios")]
        public IActionResult GetUsuarios()
        {
            List<Usuario> usuarios = _service.BuscarUsuarios();
            return Ok(usuarios);
        }

        [HttpPost]
        [Route("criar-usuario")]
        public IActionResult CriarUsuario(string nome)
        {
            Usuario usuario = _service.CriarUsuario(nome);
            return Ok(usuario);
        }
    }
}
