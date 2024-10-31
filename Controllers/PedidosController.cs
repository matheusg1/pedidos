using Microsoft.AspNetCore.Mvc;
using pedidos.Services;
using pedidos.Models;

namespace pedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {

        public PedidosService _service;

        public PedidosController(PedidosService service)
        {
            _service = service;
        }
        

        [HttpGet]
        [Route("get-pedidos")]
        public IActionResult GetPedidos()
        {
            List<Pedido> pedidos = _service.BuscarPedidos();
            return Ok(pedidos);
        }

        [HttpPost]
        [Route("criar-pedido")]
        public IActionResult CriarPedido(long idProduto, int quantidadeProdutoSolicitada, long idCliente, long idUsuario)
        {
            if (idProduto == 0 || quantidadeProdutoSolicitada == 0 || idCliente == 0 || idUsuario == 0)
            {
                return BadRequest("Solicitação inválida");
            }

            try
            {
                _service.CriarPedido(idProduto, quantidadeProdutoSolicitada, idCliente, idUsuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Falha");
            }
        }
    }
}
