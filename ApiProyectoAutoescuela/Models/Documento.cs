using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoAutoescuela.Models
{
    [Table("DOCUMENTO")]
    public class Documento
    {
        [Key]
        [Column("DocumentoId")]
        public int DocumentoId { get; set; }

        [Column("NombreDocumento")]
        public string NombreDocumento { get; set; }

        [Column("RutaArchivo")]
        public string RutaArchivo { get; set; }

        [Column("ContenidoDocumento")]
        public string ContenidoDocumento { get; set; }

        [Column("PDFData")]
        public byte[]? PDFData { get; set; }

        // Propiedades de navegación para los campos adicionales en la tabla de relación
        //[NotMapped] // Para evitar que Entity Framework intente mapear estas propiedades
        [Column("AlumnoId")]
        public int AlumnoId { get; set; }

        //[NotMapped]
        [Column("AutoescuelaId")]

        public int AutoescuelaId { get; set; }

        //[NotMapped]
        [Column("SeccionId")]
        public int SeccionId { get; set; }
    }
}
