using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoAutoescuela.Models
{
    public class ProfesorCompleto
    {
            [Key]
            [Column("ProfesorId")]
            public int ProfesorId { get; set; }


            [Column("Nombre")]
            public string Nombre { get; set; }


            [Column("Apellido")]
            public string Apellido { get; set; }


            [Column("AutoescuelaId")]
            public int AutoescuelaId { get; set; }


            [Column("SeccionId")]
            public int SeccionId { get; set; }

    }
}
