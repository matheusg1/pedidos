using Microsoft.EntityFrameworkCore;
using pedidos.Data;
using pedidos.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace pedidos.Services
{
    public class PedidosService
    {
        private readonly AppDbContext _context;

        public PedidosService(AppDbContext context)
        {
            _context = context;
        }

        public void CriarPedido(long idProduto, int quantidadeProdutoSolicitada, long idCliente, long idUsuario)
        {
            Produto? produto = _context.Produtos.FirstOrDefault(x => x.Id == idProduto);

            if (produto != null && produto.Quantidade >= quantidadeProdutoSolicitada)
            {
                DateTime dataAtual = DateTime.Now;

                int quantidadeFinal = produto.Quantidade - quantidadeProdutoSolicitada;
                decimal valorPedido = quantidadeProdutoSolicitada * produto.Valor;

                produto.Quantidade = quantidadeFinal;

                Pedido pedido = new Pedido
                {
                    Data = dataAtual,
                    QuantidadeProduto = quantidadeProdutoSolicitada,
                    Valor = valorPedido,
                    IdCliente = idCliente,
                    IdProduto = idProduto,
                    IdUsuario = idUsuario
                };

                _context.Pedidos.Add(pedido);

                _context.SaveChanges();
            }
        }
        public List<Pedido> BuscarPedidos()
        {
            List<Pedido> pedidos = _context.Pedidos.AsNoTracking().ToList();
            return pedidos;
        }
    }
}
