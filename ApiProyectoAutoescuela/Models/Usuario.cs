using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAutoescuela.Models
{
    [Table("USUARIO")]
    public class Usuario
    {
        [Key]
        [Column("UsuarioId")]
        public int IdUsuario { get; set; }



        [Column("Nombre")]
        public string Nombre { get; set; }



        [Column("Password")]
        public string? Password { get; set; }



        [Column("Email")]
        public string? Email { get; set; }



        [Column("Salt")]
        public string? Salt { get; set; }



        [Column("Activo")]
        public bool? Activo { get; set; }
        


        [Column("PasswordCifrada")]
        public byte[]? PasswordCifrada { get; set; }

    }
}
