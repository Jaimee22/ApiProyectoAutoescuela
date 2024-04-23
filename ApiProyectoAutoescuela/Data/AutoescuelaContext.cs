using Microsoft.EntityFrameworkCore;
using ProyectoAutoescuela.Models;
using System.Numerics;

namespace ApiProyectoAutoescuela.Data
{
    public class AutoescuelaContext : DbContext
    {
        public AutoescuelaContext(DbContextOptions<AutoescuelaContext> options)
            : base(options) { }

        public DbSet<Autoescuela> Autoescuelas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<AlumnoCompleto> AlumnosCompletos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<ProfesorCompleto> ProfesoresCompletos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Coche> Coches { get; set; }
        public DbSet<VehiculoCategoria> VehiculosCategorias { get; set; }
        public DbSet<Permiso> Permisos { get; set; }

    }
}
