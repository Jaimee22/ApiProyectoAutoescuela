using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAutoescuela.Models
{
    [Table("SESION")]
    public class Sesion
    {
        [Key]
        [Column("SesionId")]
        public int SesionId { get; set; }


        [Column("UserId")]
        public int UserId { get; set; }


        [Column("SeccionId")]
        public int SeccionId { get; set; }

        
    }
}
