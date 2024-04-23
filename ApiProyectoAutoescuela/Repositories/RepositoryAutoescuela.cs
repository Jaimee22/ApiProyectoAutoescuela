using ApiProyectoAutoescuela.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProyectoAutoescuela.Models;

namespace ApiProyectoAutoescuela.Repositories
{
    public class RepositoryAutoescuela
    {
        private readonly AutoescuelaContext context;

        public RepositoryAutoescuela(AutoescuelaContext context)
        {
            this.context = context;
        }


        public async Task<Usuario> LoginUsuarioAsync(string email, string password)
        { 
            return await this.context.Usuarios.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
        }


        //--------------------------------------------------------------------------------
        //AUTOESCUELA
        //--------------------------------------------------------------------------------

        /*SACAR TODAS LAS AUTOESCUELAS*/
        public async Task<List<Autoescuela>> GetAutoescuelasAsync()
        {
           
                string sql = "SP_MOSTRARTODASAUTOESCUELAS";
                var consulta = await context.Autoescuelas.FromSqlRaw(sql).ToListAsync();
                //Console.WriteLine("La consulta se ejecutó correctamente.");
                return consulta;
            
        }

        /*INSERTAR AUTOESCUELA*/
        public async Task InsertAutoescuelaAsync(string nombre, string direccion, string telefono)
        {
            try
            {
                string sql = "SP_INSERTARAUTOESCUELA @Nombre, @Direccion, @Telefono";
                await context.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@Nombre", nombre),
                    new SqlParameter("@Direccion", direccion),
                    new SqlParameter("@Telefono", telefono));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar insertar la autoescuela: " + ex.Message);
            }
        }

        /*DELETE AUTOESCUELA*/
        public async Task DeleteAutoescuelaAsync(int idAutoescuela)
        {
            try
            {
                string sql = "SP_ELIMINARAUTOESCUELA @IdAutoescuela";
                await context.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@IdAutoescuela", idAutoescuela));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar eliminar la autoescuela: " + ex.Message);
            }
        }


        /*FIND AUTOESCUELA*/
        public async Task<Autoescuela> FindAutoescuela(int IdAutoescuela)
        {
            string sql = "SP_OBTENERAUTOESCUELAPORID @IdAutoescuela";
            SqlParameter pamId = new SqlParameter("@IdAutoescuela", IdAutoescuela);
            var consulta = this.context.Autoescuelas.FromSqlRaw(sql, pamId);
            Autoescuela autoescuela = consulta.AsEnumerable().FirstOrDefault();
            return autoescuela;
        }


        /*GET AUTOESCUELA POR ID
         (igual que el find de arriba pero creo que no funciona)
        */
        public async Task<Autoescuela> GetAutoescuelaByIdAsync(int idAutoescuela)
        {
            try
            {
                string sql = "SP_OBTENERAUTOESCUELAPORID @IdAutoescuela";
                return await context.Autoescuelas.FromSqlRaw(sql, new SqlParameter("@IdAutoescuela", idAutoescuela)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar obtener la autoescuela por ID: " + ex.Message);
                return null;
            }
        }


        /*EDITAR / ACTUALIZAR AUTOESCUELA
         (no está probado que funcione)
         */
        public async Task UpdateAutoescuelaAsync(int idAutoescuela, string nombre, string direccion, string telefono)
        {
            try
            {
                string sql = "SP_ACTUALIZARAUTOESCUELA @IdAutoescuela, @Nombre, @Direccion, @Telefono";
                await context.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@IdAutoescuela", idAutoescuela),
                    new SqlParameter("@Nombre", nombre),
                    new SqlParameter("@Direccion", direccion),
                    new SqlParameter("@Telefono", telefono));
                Console.WriteLine("La autoescuela se actualizó correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar actualizar la autoescuela: " + ex.Message);
            }
        }

        //--------------------------------------------------------------------------------
        //SECCION
        //--------------------------------------------------------------------------------






        //--------------------------------------------------------------------------------
        //ALUMNO
        //--------------------------------------------------------------------------------

        /*SACAR TODOS LOS ALUMNOS*/
        public async Task<List<Alumno>> GetAlumnosAsync()
        {
            string sql = "SP_MOSTRARALUMNOS";
            var consulta = await context.Alumnos.FromSqlRaw(sql).ToListAsync();
            return consulta;
            //return await this.context.Alumnos.ToListAsync();
		}

        //FIND ALUMNO
        public async Task<Alumno> FindAlumno(int idAlumno)
        {
            string sql = "SP_FINDALUMNO @idAlumno";
            SqlParameter pamId = new SqlParameter("@idAlumno", idAlumno);
            var consulta = this.context.Alumnos.FromSqlRaw(sql, pamId);
            Alumno alumno = consulta.AsEnumerable().FirstOrDefault();
            return alumno;
        }

        //INSERT ALUMNO
        public async Task InsertAlumnoAsync(string nombre, string apellido, DateTime fechaNacimiento, int vehiculoId, int autoescuelaId, int seccionId, int profesorId)
        {

            string sql = "SP_INSERTARALUMNO @Nombre, @Apellido, @FechaNacimiento, @VehiculoId, @AutoescuelaId, @SeccionId, @ProfesorId";
            await context.Database.ExecuteSqlRawAsync(sql,
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Apellido", apellido),
                new SqlParameter("@FechaNacimiento", fechaNacimiento),
                new SqlParameter("@VehiculoId", vehiculoId),
                new SqlParameter("@AutoescuelaId", autoescuelaId),
                new SqlParameter("@SeccionId", seccionId),
                new SqlParameter("@ProfesorId", profesorId));

        }

        //EDITAR ALUMNO
        public async Task UpdateAlumnoAsync(int idAlumno, string nombre, string apellido, DateTime fechaNacimiento, int vehiculoId, int autoescuelaId, int seccionId, int profesorId)
        {
            try
            {
                string sql = "SP_EDITARALUMNO @AlumnoId, @Nombre, @Apellido, @FechaNacimiento, @IdVehiculo, @AutoescuelaId, @SeccionId";
                await context.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@AlumnoId", idAlumno),
                    new SqlParameter("@Nombre", nombre),
                    new SqlParameter("@Apellido", apellido),
                    new SqlParameter("@FechaNacimiento", fechaNacimiento),
                    new SqlParameter("@IdVehiculo", vehiculoId),
                    new SqlParameter("@AutoescuelaId", autoescuelaId),
                    new SqlParameter("@SeccionId", seccionId),
                    new SqlParameter("@ProfesorId", profesorId));
                Console.WriteLine("El alumno se actualizó correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar actualizar la autoescuela: " + ex.Message);
            }
        }

        //ALUMNO POR SECCION O DE TODAS LAS SECCIONES
        public async Task<List<Alumno>> GetAlumnosPorSeccionAsync(int seccionId)
        {
            try
            {
                string sql = "SP_OBTENERALUMNOSSECCION @SeccionId";
                var parameter = new SqlParameter("@SeccionId", seccionId);
                return await context.Alumnos.FromSqlRaw(sql, parameter).ToListAsync();
            }
            catch (Exception ex)
            {
                // Capturar y manejar cualquier excepción que ocurra
                Console.WriteLine("ERROR AL OBTENER LOS ALUMNOS DE LA SECCIÓN: " + ex.Message);
                return null;
            }
        }


        public async Task<AlumnoCompleto> GetDetallesAlumnoAsync(int alumnoId)
        {
            try
            {
                string sql = "SP_OBTENERDETALLESALUMNO @AlumnoId";
                var parameter = new SqlParameter("@AlumnoId", alumnoId);

                // Ejecutar la consulta SQL y realizar la composición en memoria
                var result = context.AlumnosCompletos.FromSqlRaw(sql, parameter).AsEnumerable().FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener los detalles del alumno: " + ex.Message);
                return null;
            }
        }

        public async Task InsertarAlumnoCompletoAsync(string nombre, string apellido, DateTime fechaNacimiento, int vehiculoId, int autoescuelaId, int seccionId, int profesorId, int permisoId)
        {
            try
            {
                string sql = "SP_INSERTARALUMNOCOMPLETO @Nombre, @Apellido, @FechaNacimiento, @VehiculoId, @AutoescuelaId, @SeccionId, @ProfesorId, @PermisoId";
                await context.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@Nombre", nombre),
                    new SqlParameter("@Apellido", apellido),
                    new SqlParameter("@FechaNacimiento", fechaNacimiento),
                    new SqlParameter("@VehiculoId", vehiculoId),
                    new SqlParameter("@AutoescuelaId", autoescuelaId),
                    new SqlParameter("@SeccionId", seccionId),
                    new SqlParameter("@ProfesorId", profesorId),
                    new SqlParameter("@PermisoId", permisoId));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar insertar el alumno completo: " + ex.Message);
                throw;
            }
        }


        public async Task DeleteAlumnoAsync(int idAlumno)
        {
            try
            {
                var alumnoToDelete = await context.Alumnos.FirstOrDefaultAsync(a => a.AlumnoId == idAlumno);

                if (alumnoToDelete != null)
                {
                    context.Alumnos.Remove(alumnoToDelete);
                    await context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("El alumno no fue encontrado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar eliminar el alumno: " + ex.Message);
                throw;
            }
        }







        //--------------------------------------------------------------------------------
        //COCHE
        //--------------------------------------------------------------------------------







        //--------------------------------------------------------------------------------
        //USUARIO
        //--------------------------------------------------------------------------------
        //public async Task<Usuario> RegisterUserAsync(string nombre, string email, string password)
        //{
        //    try
        //    {
        //        // Obtener el máximo UsuarioId de la tabla Usuario
        //        int maxUsuarioId = await context.Usuarios.MaxAsync(u => (int?)u.IdUsuario) ?? 0;

        //        // Añadir 1 al máximo UsuarioId para obtener el nuevo UsuarioId
        //        int nuevoUsuarioId = maxUsuarioId + 1;

        //        // Generar el salt y cifrar la contraseña
        //        string salt = HelperTools.GenerateSalt();
        //        byte[] passwordCifrada = HelperCryptography.EncryptPassword(password, salt);

        //        // Crear el objeto Usuario con los datos proporcionados
        //        Usuario usuario = new Usuario
        //        {
        //            IdUsuario = nuevoUsuarioId,
        //            Nombre = nombre,
        //            Email = email,
        //            Password = password,
        //            Salt = salt,
        //            Activo = false,
        //            PasswordCifrada = passwordCifrada
        //        };

        //        // Agregar el usuario a la base de datos y guardar los cambios
        //        context.Usuarios.Add(usuario);
        //        await context.SaveChangesAsync();

        //        return usuario;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Manejar cualquier excepción que pueda ocurrir durante la inserción del usuario
        //        Console.WriteLine("Error al intentar registrar el usuario: " + ex.Message);
        //        throw;
        //    }
        //}



        //public async Task<Usuario> LoginUserAsync(string email, string password)
        //{
        //    try
        //    {
        //        Usuario usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
        //        if (usuario == null)
        //        {
        //            // Usuario no encontrado
        //            Console.WriteLine("El usuario no se encontró en la base de datos.");
        //            return null;
        //        }

        //        if (usuario.Password == null)
        //        {
        //            // La contraseña en la base de datos es nula
        //            Console.WriteLine("La contraseña del usuario es nula en la base de datos.");
        //            return null;
        //        }

        //        // Comprobar la contraseña si el usuario y la contraseña no son nulos
        //        byte[] passwordCifradaInput = HelperCryptography.EncryptPassword(password, usuario.Salt);
        //        bool contraseniaValida = HelperTools.CompareArrays(passwordCifradaInput, usuario.PasswordCifrada);

        //        if (!contraseniaValida)
        //        {
        //            // Contraseña incorrecta
        //            Console.WriteLine("La contraseña proporcionada no coincide con la contraseña almacenada.");
        //            return null;
        //        }

        //        return usuario;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Capturar y registrar cualquier excepción
        //        Console.WriteLine("Error al intentar iniciar sesión: " + ex.Message);
        //        return null;
        //    }
        //}






        public async Task<List<Seccion>> GetSeccionesUsuarioAsync(int usuarioId)
        {

            string sql = "SP_MOSTRARSECCIONESUSUARIO @UsuarioId";
            var parameter = new SqlParameter("@UsuarioId", usuarioId);
            return await context.Secciones.FromSqlRaw(sql, parameter).ToListAsync();

        }




        //--------------------------------------------------------------------------------
        //DOCUMENTO
        //--------------------------------------------------------------------------------

        public async Task<List<Documento>> GetDocumentosAsync()
        {
            string sql = "SP_MOSTRARDOCUMENTOS";
            var documentos = await context.Documentos.FromSqlRaw(sql).ToListAsync();
            return documentos;
        }




        public async Task<List<Documento>> GetDocumentosPorSeccionAsync(int seccionId)
        {
            try
            {
                string sql = "SP_OBTENERDOCUMENTOSSECCION @SeccionId";
                var parameter = new SqlParameter("@SeccionId", seccionId);
                return await context.Documentos.FromSqlRaw(sql, parameter).ToListAsync();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra
                Console.WriteLine("Error al obtener documentos por sección: " + ex.Message);
                return null;
            }
        }



        public async Task InsertDocumentoAsync(Documento documento)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    // Copiar los datos del PDF a memoryStream
                    await new MemoryStream(documento.PDFData).CopyToAsync(memoryStream);
                    // Obtener los datos como un arreglo de bytes
                    byte[] pdfData = memoryStream.ToArray();

                    // Insertar el documento en la base de datos
                    string sql = "SP_INSERTARDOCUMENTO @NombreDocumento, @RutaArchivo, @ContenidoDocumento, @PDFData";
                    await context.Database.ExecuteSqlRawAsync(sql,
                        new SqlParameter("@NombreDocumento", documento.NombreDocumento),
                        new SqlParameter("@RutaArchivo", documento.RutaArchivo),
                        new SqlParameter("@ContenidoDocumento", documento.ContenidoDocumento),
                        new SqlParameter("@PDFData", pdfData));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar insertar el documento: " + ex.Message);
                throw;
            }
        }





        //--------------------------------------------------------------------------------
        //PROFESOR
        //--------------------------------------------------------------------------------
        public async Task<List<Profesor>> GetProfesoresAsync()
        {
            try
            {
                string sql = "SP_OBTENERPROFESORES";
                return await context.Profesores.FromSqlRaw(sql).ToListAsync();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra
                Console.WriteLine("Error al obtener la lista de profesores: " + ex.Message);
                throw;
            }
        }


        public async Task<List<ProfesorCompleto>> GetProfesoresPorSeccionAsync(int seccionId)
        {
            try
            {
                string sql = "SP_OBTENERPROFESORESSECCION @SeccionId";
                var parameter = new SqlParameter("@SeccionId", seccionId);
                return await context.ProfesoresCompletos.FromSqlRaw(sql, parameter).ToListAsync();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra
                Console.WriteLine("Error al obtener los profesores de la sección: " + ex.Message);
                return null;
            }
        }






        //--------------------------------------------------------------------------------
        //VEHICULOS
        //--------------------------------------------------------------------------------
        public async Task<List<VehiculoCategoria>> GetVehiculoCategoriasAsync(int seccionId)
        {
            try
            {
                string sql = "SP_OBTENERVEHICULOSCATEGORIASECCION @SeccionId";
                var parameter = new SqlParameter("@SeccionId", seccionId);
                return await context.VehiculosCategorias.FromSqlRaw(sql, parameter).ToListAsync();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra
                Console.WriteLine("Error al obtener los profesores de la sección: " + ex.Message);
                return null;
            }
        }





        public async Task EliminarAlumnoAsync(int alumnoId)
        {
            try
            {
                string sql = "SP_ELIMINARALUMNO @AlumnoId";
                await context.Database.ExecuteSqlRawAsync(sql, new SqlParameter("@AlumnoId", alumnoId));
                Console.WriteLine("El alumno se eliminó correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar eliminar el alumno: " + ex.Message);
            }
        }


        public async Task EliminarProfesorAsync(int profesorId)
        {
            try
            {
                string sql = "SP_ELIMINARPROFESOR @ProfesorId";
                await context.Database.ExecuteSqlRawAsync(sql, new SqlParameter("@ProfesorId", profesorId));
                Console.WriteLine("El profesor se eliminó correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar eliminar el profesor: " + ex.Message);
            }
        }


        public async Task<List<Coche>> ObtenerTodosLosCochesAsync()
        {
            return await this.context.Coches.ToListAsync();
        }




        public async Task InsertarProfesorAsync(string nombre, string apellido, int seccionId)
        {
            try
            {
                string sql = "SP_INSERTARPROFESOR @Nombre, @Apellido, @SeccionId";
                await this.context.Database.ExecuteSqlRawAsync(sql,
                    new SqlParameter("@Nombre", nombre),
                    new SqlParameter("@Apellido", apellido),
                    new SqlParameter("@SeccionId", seccionId));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al intentar insertar el profesor: " + ex.Message);
                throw;
            }
        }


        public async Task EditarProfesorAsync(int profesorId, string nombre, string apellido)
        {
            var profesor = await context.Profesores.FindAsync(profesorId);
            if (profesor != null)
            {
                profesor.Nombre = nombre;
                profesor.Apellido = apellido;
                await context.SaveChangesAsync();
            }
        }

        public async Task<Profesor> ObtenerProfesorAsync(int profesorId)
        {
            try
            {
                string sql = "SP_OBTENERPROFESORID @ProfesorId";
                var parameter = new SqlParameter("@ProfesorId", profesorId);
                return await context.Profesores.FromSqlRaw(sql, parameter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que ocurra
                Console.WriteLine("Error al obtener el profesor por ID: " + ex.Message);
                return null;
            }
        }


        //--------------------------------------------------------------------------------
        // SESION
        //--------------------------------------------------------------------------------

        /* Obtener todas las sesiones */
        public async Task<List<Sesion>> GetSesionesAsync()
        {
            return await context.Sesiones.ToListAsync();
        }

        /* Insertar una nueva sesión */
        public async Task InsertSesionAsync(Sesion sesion)
        {
            // Eliminar todas las sesiones existentes
            var sesiones = await context.Sesiones.ToListAsync();
            context.Sesiones.RemoveRange(sesiones);

            // Establecer el Id de la sesión como 1 y guardarla
            sesion.SesionId = 1;
            context.Sesiones.Add(sesion);
            await context.SaveChangesAsync();
        }

        /* Eliminar la sesión con Id = 1 */
        public async Task DeleteSesionAsync()
        {
            var sesion = await context.Sesiones.FindAsync(1);
            if (sesion != null)
            {
                context.Sesiones.Remove(sesion);
                await context.SaveChangesAsync();
            }
        }

        /* Actualizar la sesión con Id = 1 */
        public async Task UpdateSesionAsync(Sesion sesion)
        {
            var existingSesion = await context.Sesiones.FindAsync(1);
            if (existingSesion != null)
            {
                // Actualizar los datos de la sesión existente
                existingSesion.UserId = sesion.UserId;
                existingSesion.SeccionId = sesion.SeccionId;
                await context.SaveChangesAsync();
            }
        }

        /* Encontrar la sesión con Id = 1 */
        public async Task<Sesion> FindSesionAsync()
        {
            return await context.Sesiones.FindAsync(1);
        }





    }
}
