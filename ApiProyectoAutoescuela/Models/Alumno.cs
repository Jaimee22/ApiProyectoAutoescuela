using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAutoescuela.Models
{
    [Table("ALUMNO")]
    public class Alumno
    {
        [Key]
        [Column("AlumnoId")]
        public int AlumnoId { get; set; }


        [Column("Nombre")]
        public string Nombre { get; set; }


        [Column("Apellido")]
        public string Apellido {  get; set; }
        

        [Column("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }


        [Column("VehiculoId")]
        public int VehiculoId { get; set; }


        [Column("AutoescuelaId")]
        public int AutoescuelaId { get; set; }


        [Column("SeccionId")]
        public int SeccionId { get; set; }


        [Column("ProfesorId")]
        public int ProfesorId { get; set; }
    }
}
