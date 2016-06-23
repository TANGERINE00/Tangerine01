using DatosTangerine.InterfazDAO.M5;
using DominioTangerine;
using DominioTangerine.Entidades.M5;
using DominioTangerine.Fabrica;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M5;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.DAO.M5
{
    public class DAOContacto : DAOGeneral, IDAOContacto
    {
        /// <summary>
        /// Método para registrar un nuevo contacto en la base de datos
        /// </summary>
        /// <param name="nuevoContacto"></param>
        /// <returns>true si el resgistro es exitoso</returns>
        public bool Agregar( Entidad nuevoContacto )
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeInicioInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();

            ContactoM5 contacto = ( ContactoM5 ) nuevoContacto;

            try
            {
                //Se agregan los parámetro que recibe el stored procedure
                parametro = new Parametro( RecursosDAOContacto.ParametroNombre, SqlDbType.VarChar, contacto.Nombre,
                                           false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroApellido, SqlDbType.VarChar, contacto.Apellido,
                                           false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroDepartamento, SqlDbType.VarChar,
                                           contacto.Departamento, false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroCargo, SqlDbType.VarChar, contacto.Cargo,
                                           false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroTelefono, SqlDbType.VarChar, contacto.Telefono,
                                           false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroCorreo, SqlDbType.VarChar, contacto.Correo,
                                           false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroTipoCompania, SqlDbType.Int,
                                           contacto.TipoCompañia.ToString(), false );
                parametros.Add(parametro);

                parametro = new Parametro( RecursosDAOContacto.ParametroIdCompania, SqlDbType.Int,
                                           contacto.IdCompañia.ToString(), false );
                parametros.Add( parametro );

                //Se ejecuta el stored procedure
                List<Resultado> results = EjecutarStoredProcedure( RecursosDAOContacto.AgregarContacto, parametros );

            }

            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new AgregarContactoException( "DS-505", "Ingreso de un argumento con valor invalido", ex );
            }
            catch( FormatException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new AgregarContactoException( "DS-505", "Ingreso de datos con un formato invalido", ex );
            }
            catch( ExceptionTGConBD ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new BaseDeDatosContactoException( "DS-505", "Error con la base de datos", ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new AgregarContactoException( RecursoGeneralBD.Mensaje_Generico_Error, ex );
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeFinInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            return true;
        }

        /// <summary>
        /// Método para eliminar un contacto de la base de datos
        /// </summary>
        /// <param name="contactoEliminar"></param>
        /// <returns>true si el usuario es eliminado exitosamente</returns>
        public bool Eliminar( Entidad contactoEliminar )
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeInicioInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();

            ContactoM5 contacto = ( ContactoM5 ) contactoEliminar;

            try
            {
                //Se agregan los parámetro que recibe el stored procedure
                parametro = new Parametro( RecursosDAOContacto.ParametroId, SqlDbType.Int, contacto.Id.ToString(),
                                           false );
                parametros.Add( parametro );

                //Se ejecuta el stored procedure
                List<Resultado> results = EjecutarStoredProcedure( RecursosDAOContacto.EliminarConacto, parametros );

            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new EliminarContactoException( "DS-505", "Ingreso de un argumento con valor invalido", ex );
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new EliminarContactoException( "DS-505", "Ingreso de datos con un formato invalido", ex );
            }
            catch ( ExceptionTGConBD ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new BaseDeDatosContactoException( "DS-505", "Error con la base de datos", ex );

            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new EliminarContactoException( RecursoGeneralBD.Mensaje_Generico_Error, ex );
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeFinInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            return true;
        }

        /// <summary>
        /// Método para modificar algún dato de un contacto en la base de datos
        /// </summary>
        /// <param name="contactoModificar"></param>
        /// <returns>true si la modificación es exitosa</returns>
        public bool Modificar( Entidad contactoModificar )
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeInicioInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();

            ContactoM5 contacto = ( ContactoM5 ) contactoModificar;

            try
            {
                //Se agregan los parámetro que recibe el stored procedure
                parametro = new Parametro( RecursosDAOContacto.ParametroId, SqlDbType.Int, contacto.Id.ToString(),
                                           false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroNombre, SqlDbType.VarChar, contacto.Nombre,
                                           false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroApellido, SqlDbType.VarChar, contacto.Apellido,
                                           false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroDepartamento, SqlDbType.VarChar,
                                           contacto.Departamento, false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroCargo, SqlDbType.VarChar, contacto.Cargo,
                                           false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroTelefono, SqlDbType.VarChar, contacto.Telefono,
                                           false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroCorreo, SqlDbType.VarChar, contacto.Correo,
                                           false );
                parametros.Add( parametro );

                //Se ejecuta el stored procedure
                List<Resultado> results = EjecutarStoredProcedure( RecursosDAOContacto.ModificarContacto, parametros );

            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ModificarContactoException( "DS-505", "Ingreso de un argumento con valor invalido", ex );
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ModificarContactoException( "DS-505", "Ingreso de datos con un formato invalido", ex );
            }
            catch ( ExceptionTGConBD ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new BaseDeDatosContactoException( "DS-505", "Error con la base de datos", ex );

            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ModificarContactoException( RecursoGeneralBD.Mensaje_Generico_Error, ex );
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeFinInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            return true;
        }

        /// <summary>
        /// Método para consultar un contacto por id en la base de datos
        /// </summary>
        /// <param name="contacto"></param>
        /// <returns>un contacto</returns>
        public Entidad ConsultarXId( Entidad contacto )
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeInicioInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();

            try
            {
                //Se agregan los parámetro que recibe el stored procedure
                parametro = new Parametro( RecursosDAOContacto.ParametroId, SqlDbType.Int, contacto.Id.ToString(),
                                           false );
                parametros.Add( parametro );

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas( RecursosDAOContacto.ConsultarContactoId, parametros );

                //Por cada fila de la tabla voy a guardar los datos 
                foreach ( DataRow row in dt.Rows )
                {
                    int conId = int.Parse( row[ RecursosDAOContacto.ConIdContacto ].ToString() );
                    string conName = row[ RecursosDAOContacto.ConNombreContacto ].ToString();
                    string conLName = row[ RecursosDAOContacto.ConApellidoContacto ].ToString();
                    string conDepart = row[ RecursosDAOContacto.ConDepartamentoContacto ].ToString();
                    string conRol = row[ RecursosDAOContacto.ConCargoContacto ].ToString();
                    string conTele = row[ RecursosDAOContacto.ConTelefono ].ToString();
                    string conEmail = row[ RecursosDAOContacto.ConCorreo ].ToString();
                    int conTypeC = int.Parse( row[ RecursosDAOContacto.ConTipoCompania ].ToString() );
                    int conCompId = int.Parse( row[ RecursosDAOContacto.ConIdCompania ].ToString() );

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    Entidad nuevoContacto = FabricaEntidades.crearContactoConId( conId, conName, conLName, conDepart,
                                                                                 conRol, conTele, conEmail, conTypeC,
                                                                                 conCompId );
                    return nuevoContacto;
                }

            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ConsultarContactoException( "DS-505", "Ingreso de un argumento con valor invalido", ex );
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ConsultarContactoException( "DS-505", "Ingreso de datos con un formato invalido", ex );
            }
            catch ( ExceptionTGConBD ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new BaseDeDatosContactoException( "DS-505", "Error con la base de datos", ex );

            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ConsultarContactoException( RecursoGeneralBD.Mensaje_Generico_Error, ex );
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeFinInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            return FabricaEntidades.crearContactoVacio();
        }

        /// <summary>
        /// Método para consultar todos los contactos de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Entidad> ConsultarTodos()
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeInicioInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Parametro> parametros = new List<Parametro>();
            List<Entidad> lista = new List<Entidad>();

            try
            {
                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas( RecursosDAOContacto.ConsultarTodosContactos,
                                                              parametros );

                //Por cada fila de la tabla voy a guardar los datos 
                foreach ( DataRow row in dt.Rows )
                {
                    int conId = int.Parse( row[ RecursosDAOContacto.ConIdContacto ].ToString() );
                    string conName = row[ RecursosDAOContacto.ConNombreContacto ].ToString();
                    string conLName = row[ RecursosDAOContacto.ConApellidoContacto ].ToString();
                    string conDepart = row[ RecursosDAOContacto.ConDepartamentoContacto ].ToString();
                    string conRol = row[ RecursosDAOContacto.ConCargoContacto ].ToString();
                    string conTele = row[ RecursosDAOContacto.ConTelefono ].ToString();
                    string conEmail = row[ RecursosDAOContacto.ConCorreo ].ToString();
                    int conTypeC = int.Parse( row[ RecursosDAOContacto.ConTipoCompania ].ToString() );
                    int conCompId = int.Parse( row[ RecursosDAOContacto.ConIdCompania ].ToString() );

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    Entidad nuevoContacto = FabricaEntidades.crearContactoConId( conId, conName, conLName, conDepart,
                                                                                 conRol, conTele, conEmail, conTypeC,
                                                                                 conCompId );
                    lista.Add( nuevoContacto );
                }

            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ConsultarContactoException( "DS-505", "Ingreso de un argumento con valor invalido", ex );
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ConsultarContactoException( "DS-505", "Ingreso de datos con un formato invalido", ex );
            }
            catch ( ExceptionTGConBD ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new BaseDeDatosContactoException( "DS-505", "Error con la base de datos", ex );

            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ConsultarContactoException( RecursoGeneralBD.Mensaje_Generico_Error, ex );
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeFinInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            return lista;
        }

        /// <summary>
        /// Método para consultar todos contacto de una comañía en la base de datos
        /// </summary>
        /// <param name="tipoCompania"></param>
        /// <param name="idCompania"></param>
        /// <returns>lista de contactos</returns>
        public List<Entidad> ContactosPorCompania( int tipoCompania, int idCompania )
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeInicioInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            List<Entidad> lista = new List<Entidad>();

            try
            {
                //Se agregan los parámetro que recibe el stored procedure
                parametro = new Parametro( RecursosDAOContacto.ParametroTipoCompania, SqlDbType.Int,
                                           tipoCompania.ToString(), false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroIdCompania, SqlDbType.Int,
                                           idCompania.ToString(), false );
                parametros.Add( parametro );

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas( RecursosDAOContacto.ConsultarContactoCompania, parametros );

                //Por cada fila de la tabla voy a guardar los datos 
                foreach ( DataRow row in dt.Rows )
                {
                    int conId = int.Parse( row[ RecursosDAOContacto.ConIdContacto ].ToString() );
                    string conName = row[ RecursosDAOContacto.ConNombreContacto ].ToString();
                    string conLName = row[ RecursosDAOContacto.ConApellidoContacto ].ToString();
                    string conDepart = row[ RecursosDAOContacto.ConDepartamentoContacto ].ToString();
                    string conRol = row[ RecursosDAOContacto.ConCargoContacto ].ToString();
                    string conTele = row[ RecursosDAOContacto.ConTelefono ].ToString();
                    string conEmail = row[ RecursosDAOContacto.ConCorreo ].ToString();
                    int conTypeC = int.Parse( row[ RecursosDAOContacto.ConTipoCompania ].ToString() );
                    int conCompId = int.Parse( row[ RecursosDAOContacto.ConIdCompania ].ToString() );

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    Entidad nuevoContacto = FabricaEntidades.crearContactoConId( conId, conName, conLName, conDepart,
                                                                                 conRol, conTele, conEmail, conTypeC,
                                                                                 conCompId );
                    lista.Add( nuevoContacto );
                }

            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ConsultarContactoException( "DS-505", "Ingreso de un argumento con valor invalido", ex );
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ConsultarContactoException( "DS-505", "Ingreso de datos con un formato invalido", ex );
            }
            catch ( ExceptionTGConBD ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new BaseDeDatosContactoException( "DS-505", "Error con la base de datos", ex );

            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ConsultarContactoException( RecursoGeneralBD.Mensaje_Generico_Error, ex );
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeFinInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            return lista;
        }

        /// <summary>
        /// Método para unir un proyecto y un contacto de la base de datos
        /// </summary>
        /// <param name="contactoAgregar"></param>
        /// <param name="proyectoAgregar"></param>
        /// <returns>true si el registro es exitoso</returns>
        public bool AgregarContactoAProyecto( Entidad contactoAgregar, Entidad proyectoAgregar )
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeInicioInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();

            ContactoM5 contacto = ( ContactoM5 ) contactoAgregar;
            DominioTangerine.Entidades.M7.Proyecto proyecto = ( DominioTangerine.Entidades.M7.Proyecto ) 
                                                              proyectoAgregar;

            try
            {
                //Se agregan los parámetro que recibe el stored procedure
                parametro = new Parametro( RecursosDAOContacto.ParametroIdContacto, SqlDbType.Int,
                                           contacto.Id.ToString(), false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroIdProyecto, SqlDbType.Int,
                                           proyecto.Id.ToString(), false );
                parametros.Add( parametro );

                List<Resultado> results = EjecutarStoredProcedure( RecursosDAOContacto.AgregarContactoProyecto, 
                                          parametros );
                
            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new AgregarContactoException( "DS-505", "Ingreso de un argumento con valor invalido", ex );
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new AgregarContactoException( "DS-505", "Ingreso de datos con un formato invalido", ex );
            }
            catch ( ExceptionTGConBD ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new BaseDeDatosContactoException( "DS-505", "Error con la base de datos", ex );

            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new AgregarContactoException( RecursoGeneralBD.Mensaje_Generico_Error, ex );
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeFinInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            return true;
        }

        /// <summary>
        /// Método que devuelve todos los contactos de un proyecto de la base de datos
        /// </summary>
        /// <param name="proyecto"></param>
        /// <returns>lista de contactos</returns>
        public List<Entidad> ContactosPorProyecto( Entidad proyecto )
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeInicioInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            List<Entidad> lista = new List<Entidad>();

            DominioTangerine.Entidades.M7.Proyecto proyectoConsulta = ( DominioTangerine.Entidades.M7.Proyecto )
                                                                      proyecto;

            try
            {
                //Se agregan los parámetro que recibe el stored procedure
                parametro = new Parametro( RecursosDAOContacto.ParametroIdProyecto, SqlDbType.Int,
                                           proyectoConsulta.Id.ToString(), false);
                parametros.Add( parametro );

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas( RecursosDAOContacto.ConsultarContactoProyecto,
                                                              parametros );

                //Por cada fila de la tabla voy a guardar los datos 
                foreach ( DataRow row in dt.Rows )
                {
                    int conId = int.Parse( row[ RecursosDAOContacto.ConIdContacto ].ToString() );
                    string conName = row[ RecursosDAOContacto.ConNombreContacto ].ToString();
                    string conLName = row[ RecursosDAOContacto.ConApellidoContacto ].ToString();
                    string conDepart = row[ RecursosDAOContacto.ConDepartamentoContacto ].ToString();
                    string conRol = row[ RecursosDAOContacto.ConCargoContacto] .ToString();
                    string conTele = row[ RecursosDAOContacto.ConTelefono ].ToString();
                    string conEmail = row[ RecursosDAOContacto.ConCorreo ].ToString();
                    int conTypeC = int.Parse( row[ RecursosDAOContacto.ConTipoCompania ].ToString() );
                    int conCompId = int.Parse( row[ RecursosDAOContacto.ConIdCompania ].ToString() );

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    Entidad nuevoContacto = FabricaEntidades.crearContactoConId( conId, conName, conLName, conDepart,
                                                                                 conRol, conTele, conEmail, conTypeC,
                                                                                 conCompId );
                    lista.Add( nuevoContacto );
                }

            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ConsultarContactoException( "DS-505", "Ingreso de un argumento con valor invalido", ex);
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ConsultarContactoException( "DS-505", "Ingreso de datos con un formato invalido", ex);
            }
            catch ( ExceptionTGConBD ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new BaseDeDatosContactoException( "DS-505", "Error con la base de datos", ex);

            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ConsultarContactoException( RecursoGeneralBD.Mensaje_Generico_Error, ex );
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeFinInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            return lista;
        }

        /// <summary>
        /// Método eliminar un contacto de un proyecto de la base de datos
        /// </summary>
        /// <param name="contactoEliminar"></param>
        /// <param name="proyectoEliminar"></param>
        /// <returns>true si la eliminación es exitosa</returns>
        public bool EliminarContactoDeProyecto( Entidad contactoEliminar, Entidad proyectoEliminar )
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeInicioInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();

            ContactoM5 contacto = ( ContactoM5 ) contactoEliminar;
            DominioTangerine.Entidades.M7.Proyecto proyecto = ( DominioTangerine.Entidades.M7.Proyecto )
                                                              proyectoEliminar;

            try
            {
                //Se agregan los parámetro que recibe el stored procedure
                parametro = new Parametro( RecursosDAOContacto.ParametroIdContacto, SqlDbType.Int,
                                           contacto.Id.ToString(), false );
                parametros.Add( parametro );

                parametro = new Parametro( RecursosDAOContacto.ParametroIdProyecto, SqlDbType.Int,
                                           proyecto.Id.ToString(), false );
                parametros.Add( parametro );

                List<Resultado> results = EjecutarStoredProcedure( RecursosDAOContacto.EliminarContactoProyecto,
                                          parametros );

            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new EliminarContactoException( "DS-505", "Ingreso de un argumento con valor invalido", ex );
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new EliminarContactoException( "DS-505", "Ingreso de datos con un formato invalido", ex );
            }
            catch ( ExceptionTGConBD ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new BaseDeDatosContactoException( "DS-505", "Error con la base de datos", ex );

            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new EliminarContactoException( RecursoGeneralBD.Mensaje_Generico_Error, ex );
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeFinInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            return true;
        }

        /// <summary>
        /// Método que devuelve todos los contactos que no pertenecen a un proyecto de la base de datos
        /// </summary>
        /// <param name="proyecto"></param>
        /// <returns>lista de contactos</returns>
        public List<Entidad> ContactosNoPertenecenAProyecto( Entidad proyecto )
        {
            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeInicioInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();
            List<Entidad> lista = new List<Entidad>();

            DominioTangerine.Entidades.M7.Proyecto proyectoConsulta = ( DominioTangerine.Entidades.M7.Proyecto )
                                                                      proyecto;

            try
            {
                //Se agregan los parámetro que recibe el stored procedure
                parametro = new Parametro( RecursosDAOContacto.ParametroIdProyecto, SqlDbType.Int,
                                           proyectoConsulta.Id.ToString(), false );
                parametros.Add( parametro );

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas( RecursosDAOContacto.ConsultarContactoNoProyecto,
                                                              parametros );

                //Por cada fila de la tabla voy a guardar los datos 
                foreach ( DataRow row in dt.Rows )
                {
                    int conId = int.Parse( row[ RecursosDAOContacto.ConIdContacto ].ToString() );
                    string conName = row[ RecursosDAOContacto.ConNombreContacto ].ToString();
                    string conLName = row[ RecursosDAOContacto.ConApellidoContacto ].ToString();
                    string conDepart = row[ RecursosDAOContacto.ConDepartamentoContacto ].ToString();
                    string conRol = row[ RecursosDAOContacto.ConCargoContacto ].ToString();
                    string conTele = row[ RecursosDAOContacto.ConTelefono ].ToString();
                    string conEmail = row[ RecursosDAOContacto.ConCorreo ].ToString();
                    int conTypeC = int.Parse( row[ RecursosDAOContacto.ConTipoCompania ].ToString() );
                    int conCompId = int.Parse( row[ RecursosDAOContacto.ConIdCompania ].ToString() );

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    Entidad nuevoContacto = FabricaEntidades.crearContactoConId( conId, conName, conLName, conDepart,
                                                                                 conRol, conTele, conEmail, conTypeC,
                                                                                 conCompId );
                    lista.Add( nuevoContacto );
                }

            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ConsultarContactoException( "DS-505", "Ingreso de un argumento con valor invalido", ex );
            }
            catch ( FormatException ex )
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ConsultarContactoException( "DS-505", "Ingreso de datos con un formato invalido", ex );
            }
            catch ( ExceptionTGConBD ex )
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new BaseDeDatosContactoException( "DS-505", "Error con la base de datos", ex );

            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex );
                throw new ConsultarContactoException( RecursoGeneralBD.Mensaje_Generico_Error, ex );
            }

            Logger.EscribirInfo( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                 RecursosDAOContacto.MensajeFinInfoLogger,
                                 System.Reflection.MethodBase.GetCurrentMethod().Name );

            return lista;
        }
    }
}
