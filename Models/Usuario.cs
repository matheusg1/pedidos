using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pedidos.Models
{
    [Table("TB_USUARIO")]
    public class Usuario
    {
        [Key, Column("USU_ID")]
        public long Id { get; set; }
        [Column("USU_NOME")]
        public required string Nome { get; set; }
    }
}
