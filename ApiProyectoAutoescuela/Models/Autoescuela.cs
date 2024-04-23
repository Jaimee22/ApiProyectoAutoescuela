using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAutoescuela.Models
{
	[Table("AUTOESCUELA")]
	public class Autoescuela
	{
		[Key]
		[Column("AutoescuelaId")]
		public int IdAutoescuela { get; set; }


		[Column("Nombre")]
		public string NombreAutoescuela { get; set; }


		[Column("Direccion")]
		public string DireccionAutoescuela {  get; set; }


		[Column("Telefono")]
		public string TelefonoAutoescuela { get; set; }




	}
}
