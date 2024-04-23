using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAutoescuela.Models
{
    public class AlumnoCompleto
    {
        [Key]
        [Column("AlumnoId")]
        public int AlumnoId { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Apellido")]
        public string Apellido { get; set; }

        [Column("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Column("AutoescuelaId")]
        public int AutoescuelaId { get; set; }

        [Column("NombreAutoescuela")]
        public string NombreAutoescuela { get; set; }

        [Column("SeccionId")]
        public int SeccionId { get; set; }

        [Column("NombreSeccion")]
        public string NombreSeccion { get; set; }

        [Column("PermisoId")]
        public int PermisoId { get; set; }

        [Column("NombrePermiso")]
        public string NombrePermiso { get; set; }

        [Column("ProfesorId")]
        public int ProfesorId { get; set; }

        [Column("NombreProfesor")]
        public string NombreProfesor { get; set; }

        [Column("VehiculoId")]
        public int VehiculoId { get; set; }


        public List<Profesor> Profesores { get; set; }
    }
}
