 using DatosTangerine.InterfazDAO.M7;
using DatosTangerine.M5;
using DatosTangerine.M7;
using DominioTangerine;
using ExcepcionesTangerine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.DAO.M7
{
    public class DaoProyectoContacto : DAOGeneral, IDaoProyectoContacto
    {
        #region IDAO Proyecto Contacto
        public bool ContactProyectoContacto(Entidad proyecto)
        {
            throw new NotImplementedException();
        }

        public Boolean DeleteProyectoContacto(Entidad proyecto)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ContactCompany(Entidad contacto) 
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceContact.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Entidad> listContact = new List<Entidad>();

            try
            {
                string parametro1 = "1";
                /*List<Parametro> parameters = new List<Parametro>();
                Parametro theParam  = new Parametro(ResourceContact.ParamTComp, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Contacto)contacto).TipoCompañia.ToString(), false);
                parameters.Add(theParam);*/

                List<Parametro> parameters = new List<Parametro>();
                Parametro theParam = new Parametro(ResourceContact.ParamTComp, SqlDbType.Int, parametro1, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamIdComp, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Proyecto)contacto).Id.ToString(), false);
                parameters.Add(theParam);

                /*theParam = new Parametro(ResourceContact.ParamIdComp, SqlDbType.Int, parametro2, false);
                parameters.Add(theParam);*/

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceContact.ContactCompany, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad contacto2 = DominioTangerine.Fabrica.FabricaEntidades.ObtenerContacto();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Id = int.Parse(row[ResourceContact.ConIdContact].ToString());
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Nombre = row[ResourceContact.ConNameContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Apellido = row[ResourceContact.ConLastNameContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Departamento = row[ResourceContact.ConDepartmentContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Cargo = row[ResourceContact.ConRolContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Telefono = row[ResourceContact.ConPhoneContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).Correo = row[ResourceContact.ConEmailContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).TipoCompañia = int.Parse(row[ResourceContact.ConTypeComp].ToString());
                    ((DominioTangerine.Entidades.M7.Contacto)contacto2).IdCompañia = int.Parse(row[ResourceContact.ConIdComp].ToString());

                    listContact.Add(contacto2);
                }

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M5.NullArgumentException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M5.WrongFormatException(ResourceContact.Codigo_Error_Formato,
                     ResourceContact.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceContact.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

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


                        theParam = new Parametro(ResourceProyecto.ParamId_Proyecto, SqlDbType.Int, elProyecto.Id.ToString(), false);
                        parameters.Add(theParam);

                        theParam = new Parametro(ResourceProyecto.ParamPCIdContacto, SqlDbType.Int, contacto.Id.ToString(), false);
                        parameters.Add(theParam);

                        
                        //Se manda a ejecutar en BDConexion el stored procedure M7_AgregarProyecto y todos los parametros que recibe
                        List<Resultado> results = EjecutarStoredProcedure(ResourceProyecto.AddNewProyectoContacto, parameters);

                        
                    }
                    catch (Exception ex)
                    {
                        throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                        return false;
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
                ResourceContact.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            Entidad contacto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerContacto();

            try
            {
                List<Parametro> parameters = new List<Parametro>();
                Parametro theParam = new Parametro(ResourceContact.ParamIdProy, SqlDbType.Int, parametro.Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceContact.ContactProyect, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Id = int.Parse(row[ResourceContact.ConIdContact].ToString());
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Nombre = row[ResourceContact.ConNameContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Apellido = row[ResourceContact.ConLastNameContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Departamento = row[ResourceContact.ConDepartmentContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Cargo = row[ResourceContact.ConRolContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Telefono = row[ResourceContact.ConPhoneContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).Correo = row[ResourceContact.ConEmailContact].ToString();
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).TipoCompañia = int.Parse(row[ResourceContact.ConTypeComp].ToString());
                    ((DominioTangerine.Entidades.M7.Contacto)contacto).IdCompañia = int.Parse(row[ResourceContact.ConIdComp].ToString());
                }

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M5.NullArgumentException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M5.WrongFormatException(ResourceContact.Codigo_Error_Formato,
                     ResourceContact.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceContact.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return contacto;
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
