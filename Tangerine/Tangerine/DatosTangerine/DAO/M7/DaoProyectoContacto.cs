using DatosTangerine.InterfazDAO.M7;
using DatosTangerine.M5;
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

        public bool DeleteProyectoContacto(Entidad proyecto)
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

        #region IDAO
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

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
