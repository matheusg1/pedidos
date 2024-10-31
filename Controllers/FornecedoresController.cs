using Microsoft.AspNetCore.Mvc;

namespace pedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedoresController : ControllerBase
    {      

        private readonly ILogger<FornecedoresController> _logger;

        public FornecedoresController(ILogger<FornecedoresController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("get-fornecedores")]
        public IActionResult GetFornecedores()
        {
            return Ok();
        }
    }
}
