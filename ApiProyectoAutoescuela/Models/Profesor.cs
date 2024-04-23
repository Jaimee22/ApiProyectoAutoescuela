using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAutoescuela.Models
{
    [Table("PROFESOR")]
    public class Profesor
    {
        [Key]
        [Column("ProfesorId")]
        public int ProfesorId { get; set; }


        [Column("Nombre")]
        public string Nombre { get; set; }


        [Column("Apellido")]
        public string Apellido { get; set; }

    }
}
