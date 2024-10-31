using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pedidos.Models
{
    [Table("TB_FORNECEDOR")]
    public class Fornecedor
    {
        [Key, Column("FORN_ID")]
        public required long Id { get; set; }
        [Column("FORN_NOME")]
        public required string Nome { get; set; }

    }
}
