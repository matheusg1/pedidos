using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pedidos.Models
{
    [Table("TB_PRODUTO")]
    public class Produto
    {
        [Key, Column("PROD_ID")]
        public required long Id { get; set; }

        [Column("PROD_NOME")]
        public required string Nome { get; set; }

        [Column("PROD_VALOR")]
        public required decimal Valor { get; set; }

        [Column("PROD_QUANTIDADE")]
        public required int Quantidade { get; set; }

        [Column("PROD_DT_INCLUSAO")]
        public required DateTime DtInclusao { get; set; }

        [Column("PROD_DT_ALTERACAO")]
        public DateTime? DtAlteracao { get; set; }
    }
}
