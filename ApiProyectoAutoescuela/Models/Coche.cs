using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAutoescuela.Models
{
    [Table("COCHE")]
    public class Coche
    {
        [Key]

        [Column("IdCoche")]
        public int IdCoche { get; set; }
        

        [Column("FechaAlta")]
        public DateTime FechaAlta { get; set; }


        [Column("FechaBaja")]
        public DateTime? FechaBaja { get; set; }


        [Column("Matricula")]
        public string Matricula { get; set; }


        [Column("ITV")]
        public DateTime ITV { get; set; }


        [Column("FechaAnteriorITV")]
        public DateTime? FechaAnteriorITV { get; set; }


        [Column("FechaProximaITV")]
        public DateTime? FechaProximaITV { get; set; }


        [Column("Seguro")]
        public string Seguro { get; set; }


        [Column("Imagen")]
        public string Imagen { get; set; }


        [Column("Modelo")]
        public string Modelo { get; set; }


        [Column("Marca")]
        public string Marca { get; set; }


        [Column("VehiculoId")]
        public int VehiculoId { get; set; }

    }
}
