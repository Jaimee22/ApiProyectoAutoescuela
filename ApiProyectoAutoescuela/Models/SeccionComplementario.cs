namespace ProyectoAutoescuela.Models
{
    public class SeccionComplementario
    {
        public List<Seccion> Secciones { get; set; }
        public List<Documento> Documentos { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public List<AlumnoCompleto> AlumnosCompletos { get; set; }
        public List<Profesor> Profesores { get; set; }
        public List<ProfesorCompleto> ProfesoresCompletos { get; set; }
        public List<Vehiculo> Vehiculos { get; set; }
        public List <VehiculoCategoria> VehiculoCategorias { get; set; }
        public List<Permiso> Permisos { get; set; }
    }
}
