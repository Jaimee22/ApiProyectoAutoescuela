using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAutoescuela.Models
{
    [Table("VEHICULO")]
    public class Vehiculo
    {
        [Key]
        [Column("VehiculoId")]
        public int VehiculoId { get; set; }


        [Column("CategoriaId")]
        public int CategoriaId { get; set; }


        [Column("AutoescuelaId")]
        public int AutoescuelaId { get; set; }


        [Column("SeccionId")]
        public int SeccionId { get; set; }


    }
}
