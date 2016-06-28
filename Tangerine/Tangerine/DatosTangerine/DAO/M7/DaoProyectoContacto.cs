 using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using ExcepcionesTangerine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M7;

namespace DatosTangerine.DAO.M7
{
    public class DaoProyectoContacto : DAOGeneral, IDaoProyectoContacto
    {
        #region IDAO Proyecto Contacto
        /// <summary>
        /// Método para eliminar los contactos de un proyecto.
        /// </summary>
        /// <param name="proyecto">Proyecto del cual serán eliminados
        /// los contactos asignados.</param>
        /// <returns>True si fue exitoso, false en caso contrario.</returns>
        public bool ElimminarContactos(Entidad proyecto)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Resource_M7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            try
            {
                List<Parametro> parameters = new List<Parametro>();
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                Parametro theParam = new Parametro(Resource_M7.ParamId_Proyecto, SqlDbType.Int,
                                            ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Id.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M7_EliminarProyecto y todos los parametros que recibe
                List<Resultado> results = EjecutarStoredProcedure(Resource_M7.DeleteProyectoContacto, parameters);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-703", "Error al momento de realizar la conexion", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Resource_M7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


            return true;
        }

        /// <summary>
        /// Método que consulta los contactos de una compania
        /// </summary>
        /// <param name="contacto"></param>
        /// <returns>Lista de contactos pertenecientes a una compañia</returns>
        public List<Entidad> ContactCompany(Entidad contacto) 
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Resource_M7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> listContact = new List<Entidad>();

            try
            {
                string parametro1 = "1";
                /*List<Parametro> parameters = new List<Parametro>();
                Parametro theParam  = new Parametro(ResourceContact.ParamTComp, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Contacto)contacto).TipoCompañia.ToString(), false);
                parameters.Add(theParam);*/

                List<Parametro> parameters = new List<Parametro>();
                Parametro theParam = new Parametro(Resource_M7.ParamTComp, SqlDbType.Int, parametro1, false);
                parameters.Add(theParam);

                theParam = new Parametro(Resource_M7.ParamIdComp, SqlDbType.Int,
                                ((DominioTangerine.Entidades.M7.Proyecto)contacto).Id.ToString(), false);
                parameters.Add(theParam);

                /*theParam = new Parametro(ResourceContact.ParamIdComp, SqlDbType.Int, parametro2, false);
                parameters.Add(theParam);*/

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(Resource_M7.ContactCompany, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad contacto2 = DominioTangerine.Fabrica.FabricaEntidades.ObtenerContacto();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Id = 
                                        int.Parse(row[Resource_M7.ConIdContact].ToString());
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Nombre = 
                                        row[Resource_M7.ConNameContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Apellido = 
                                        row[Resource_M7.ConLastNameContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Departamento = 
                                        row[Resource_M7.ConDepartmentContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Cargo =
                                        row[Resource_M7.ConRolContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Telefono = 
                                        row[Resource_M7.ConPhoneContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Correo = 
                                        row[Resource_M7.ConEmailContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).TipoCompañia = 
                                        int.Parse(row[Resource_M7.ConTypeComp].ToString());
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).IdCompañia = 
                                        int.Parse(row[Resource_M7.ConIdComp].ToString());

                    listContact.Add(contacto2);
                }

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-703", "Error al momento de realizar la conexion", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Resource_M7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listContact;
        }
        #endregion

        #region DAO
        public bool Agregar(Entidad entProyecto)
        {
            {
                List<Parametro> parameters;
                Parametro theParam = new Parametro();
                DominioTangerine.Entidades.M7.Proyecto elProyecto = (DominioTangerine.Entidades.M7.Proyecto)entProyecto;

                foreach (Entidad entidad in elProyecto.get__contactos())
                {
                    DominioTangerine.Entidades.M5.ContactoM5 contacto = (DominioTangerine.Entidades.M5.ContactoM5)entidad;


                    try
                    {
                        parameters = new List<Parametro>();
                        //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                        //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)


                        theParam = new Parametro(Resource_M7.ParamId_Proyecto, SqlDbType.Int, 
                                        elProyecto.Id.ToString(), false);
                        parameters.Add(theParam);

                        theParam = new Parametro(Resource_M7.ParamPCIdContacto, SqlDbType.Int,
                                        contacto.Id.ToString(), false);
                        parameters.Add(theParam);

                        
                        //Se manda a ejecutar en BDConexion el stored procedure M7_AgregarProyecto y todos los parametros que recibe
                        List<Resultado> results = EjecutarStoredProcedure(Resource_M7.AddNewProyectoContacto, parameters);

                        
                    }
                    catch (ArgumentNullException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
                    }
                    catch (FormatException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
                    }
                    catch (SqlException ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        throw new ExceptionM7Tangerine("DS-703", "Error al momento de realizar la conexion", ex);
                    }
                    catch (Exception ex)
                    {
                        Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                        throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
                    }

                }
                return true;
            }
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para consultar el contacto de un proyecto en la base de datos.
        /// </summary>
        ///  <param name="parametro">objeto de tipo proyecto con el ID para buscar en BD</param>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>entidad Contacto asociada al proyecto</returns>
        public Entidad ConsultarXId(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Resource_M7.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            Entidad contacto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerContacto();

            try
            {
                List<Parametro> parameters = new List<Parametro>();
                Parametro theParam = new Parametro(Resource_M7.ParamIdProy, SqlDbType.Int, parametro.Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(Resource_M7.ContactProyect, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Id = 
                                        int.Parse(row[Resource_M7.ConIdContact].ToString());
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Nombre = 
                                        row[Resource_M7.ConNameContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Apellido = 
                                        row[Resource_M7.ConLastNameContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Departamento = 
                                        row[Resource_M7.ConDepartmentContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Cargo = 
                                        row[Resource_M7.ConRolContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Telefono = 
                                        row[Resource_M7.ConPhoneContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Correo = 
                                        row[Resource_M7.ConEmailContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).TipoCompañia = 
                                        int.Parse(row[Resource_M7.ConTypeComp].ToString());
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).IdCompañia = 
                                        int.Parse(row[Resource_M7.ConIdComp].ToString());
                }

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M5.NullArgumentException(Resource_M7.Codigo,
                    Resource_M7.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(Resource_M7.Codigo,
                    Resource_M7.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M5.WrongFormatException(Resource_M7.Codigo_Error_Formato,
                     Resource_M7.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(Resource_M7.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                Resource_M7.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return contacto;
        }

        #endregion

        /// <summary>
        /// Método general heradado de IDao
        /// para consultar todos los contactos.
        /// No implementado en este modulo.
        /// </summary>
        /// <returns></returns>
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para consultar todos los empleados asociados a un proyecto en la base de datos.
        /// </summary>
        ///  <param name="parametro">objeto de tipo proyecto con el ID para buscar en BD</param>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>Lista de Empleados asociados al proyecto</returns>
        public List<Entidad> ObtenerListaContactos(Entidad proyecto)
        {

            List<Entidad> listContacto = new List<Entidad>();

            try
            {
                List<Parametro> parameters = new List<Parametro>();

                Parametro theParam = new Parametro(Resource_M7.ParamId_Proyecto, SqlDbType.Int,
                                            proyecto.Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(Resource_M7.ContactProyectoContacto, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad contacto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerContacto();

                    int PEIdEmpleado = int.Parse(row[Resource_M7.PCIdContacto].ToString());
                    //creo un objeto de tipo Contacto con los datos del id y lo guardo

                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Id =
                                        int.Parse(row[Resource_M7.PCIdContacto].ToString());
                    listContacto.Add(contacto);

                }
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-701", "Ingreso de un argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-702", "Ingreso de datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-703", "Error al momento de realizar la conexion", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionM7Tangerine("DS-704", "Error al momento de realizar la operacion ", ex);
            }
            return listContacto;
        }
    }
}
