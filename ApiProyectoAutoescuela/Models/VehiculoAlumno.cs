using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAutoescuela.Models
{
    [Table("VEHICULOALUMNO")]
    public class VehiculoAlumno
    {
        [Key]
        [Column("VehiculoId")]
        public int VehiculoId { get; set; }


        [Column("AlumnoId")]
        public int AlumnoId { get; set; }
    }
}
