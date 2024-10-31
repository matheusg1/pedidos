using Microsoft.EntityFrameworkCore;
using pedidos.Data;
using pedidos.Models;

namespace pedidos.Services
{
    public class RelatoriosService
    {
        private readonly AppDbContext _context;
        private readonly string _quantidadeMinimaProduto;
        public RelatoriosService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _quantidadeMinimaProduto = configuration["Config:QuantidadeMinimaProduto"]!;

        }
        public List<Pedido> BuscarPedidosByCliente(long idCliente)
        {
            return _context.Pedidos.Where(x => x.IdCliente == idCliente).AsNoTracking().ToList();
        }

        public List<Pedido> BuscarPedidosByProduto(long idProduto)
        {
            return _context.Pedidos.Where(x => x.IdProduto == idProduto).AsNoTracking().ToList();
        }

        public List<Produto>? BuscarProdutosPoucoEstoque()
        {
            if (int.TryParse(_quantidadeMinimaProduto, out int quantidadeMinima))
            {
                return _context.Produtos.Where(x => x.Quantidade < quantidadeMinima).AsNoTracking().ToList();
            }
            return null;
        }

        public object BuscarQuantidadePedidosEValorByCliente(long idCliente)
        {
            var resultado = _context.Pedidos
                        .Where(p => p.IdCliente == idCliente)
                        .Join(_context.Produtos, pedido => pedido.IdProduto, produto => produto.Id, (pedido, produto) => new
                        {
                            ValorTotal = pedido.QuantidadeProduto * produto.Valor
                        })
                        .ToList();

            decimal totalValorPedidos = resultado.Sum(x => x.ValorTotal);
            int totalPedidos = resultado.Count;

            return new
            {
                IdCliente = idCliente,
                ValorTotal = totalValorPedidos,
                QuantidadePedidos = totalPedidos
            };
        }      
    }
}
