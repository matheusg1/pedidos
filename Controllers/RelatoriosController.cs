using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using pedidos.Models;
using pedidos.Services;

namespace pedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatoriosController : ControllerBase
    {
        public RelatoriosService _service;

        public RelatoriosController(RelatoriosService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("get-relatorios")]
        public IActionResult GetRelatorios()
        {
            return Ok();
        }

        [HttpGet]
        [Route("get-pedidos-by-cliente")]
        public IActionResult BuscarPedidosByCliente(long idCliente)
        {
            return Ok(_service.BuscarPedidosByCliente(idCliente));
        }

        [HttpGet]
        [Route("get-pedidos-by-produto")]
        public IActionResult BuscarPedidosByProduto(long idProduto)
        {
            return Ok(_service.BuscarPedidosByProduto(idProduto));
        }

        [HttpGet]
        [Route("get-produtos-baixo-estoque")]
        public IActionResult BuscarProdutosPoucoEstoque()
        {
            var produtos = _service.BuscarProdutosPoucoEstoque();
            if (produtos.IsNullOrEmpty())
            {
                return Ok("Nenhum produto com baixo estoque");
            }

            return Ok(produtos);
        }
        [HttpGet]
        [Route("get-quantidade-pedidos-by-cliente")]
        public IActionResult BuscarQuantidadePedidosEValorByCliente(long idCliente)
        {
            return Ok(_service.BuscarQuantidadePedidosEValorByCliente(idCliente));
        }
    }
}
