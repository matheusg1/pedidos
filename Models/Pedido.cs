using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pedidos.Models
{
    [Table("TB_PEDIDO")]
    public class Pedido
    {
        [Key, Column("PED_ID")]
        public long Id { get; set; }
        [Column("PED_DATA")]
        public required DateTime Data{ get; set; }
        [Column("PED_VALOR")]
        public required decimal Valor { get; set; }
        [Column("PED_QUANT_PRODUTO")]
        public required int QuantidadeProduto { get; set; }
        [Column("CLIENTE_ID_PEDIDO")]
        public required long IdCliente{ get; set; }
        [Column("PRODUTO_ID_PEDIDO")]
        public required long IdProduto { get; set; }
        [Column("USUARIO_ID_PEDIDO")]
        public required long IdUsuario{ get; set; }

    }
}
