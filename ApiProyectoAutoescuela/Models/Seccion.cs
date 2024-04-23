using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAutoescuela.Models
{
    [Table("SECCION")]
    public class Seccion
    {
        [Key]
        [Column("SeccionId")]
        public int SeccionId { get; set; }


        [Column("Nombre")]
        public string Nombre { get; set; }


        [Column("Descripcion")]
        public string Descripcion { get; set; }

        
        [Column("AutoescuelaId")]
        public int AutoescuelaId { get; set; }
    }
}
