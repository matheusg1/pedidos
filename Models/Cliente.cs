using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pedidos.Models
{
    [Table("TB_CLIENTE")]
    public class Cliente
    {
        [Key, Column("CLIE_ID")]
        public required long Id { get; set; }
        [Column("CLIE_NOME")]
        public required string Nome { get; set; }
    }
}
