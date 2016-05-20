using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;
using ExcepcionesTangerine;

namespace DatosTangerine.M5
{
    public class BDContacto
    {

        /// <summary>
        /// Metodo para agregar una contacto nuevo en la base de datos.
        /// </summary>
        /// <param name="theContact">objeto de tipo Contacto para agregar en bd</param>
        /// <returns>true si fue agregado</returns>
        public static bool AddContact(Contacto theContact)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                ResourceContact.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceContact.ParamName, SqlDbType.VarChar, theContact.Nombre,false);
                parameters.Add(theParam);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceContact.ParamLName, SqlDbType.VarChar, theContact.Apellido, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamDepa, SqlDbType.VarChar, theContact.Departamento, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamRol, SqlDbType.VarChar, theContact.Cargo, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamTele, SqlDbType.VarChar, theContact.Telefono, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamEmail, SqlDbType.VarChar, theContact.Correo, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamTComp, SqlDbType.Int, theContact.TipoCompañia.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamIdComp, SqlDbType.Int, theContact.IdCompañia.ToString(), false);
                parameters.Add(theParam);
                
                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceContact.AddNewContact, parameters);

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

            return true;
        }

        /// <summary>
        /// Metodo para eliminar un contacto de la base de datos.
        /// </summary>
        /// <param name="contact">objeto de tipo Contacto a eliminar en bd</param>
        /// <returns>true si fue eliminado</returns>
        public static Boolean DeleteContact(Contacto contact)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                ResourceContact.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceContact.ParamId, SqlDbType.Int, contact.IdContacto.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceContact.DeleteContact, parameters);

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

            return true;
        }

        /// <summary>
        /// Metodo para modificar un contacto en la base de datos.
        /// </summary>
        /// <param name="theContact">objeto de tipo Contacto para modificar en bd</param>
        /// <returns>true si fue modificado</returns>
        public static Boolean ChangeContact(Contacto theContact)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                ResourceContact.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceContact.ParamId, SqlDbType.Int, theContact.IdContacto.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamName, SqlDbType.VarChar, theContact.Nombre, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamLName, SqlDbType.VarChar, theContact.Apellido, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamDepa, SqlDbType.VarChar, theContact.Departamento, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamRol, SqlDbType.VarChar, theContact.Cargo, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamTele, SqlDbType.VarChar, theContact.Telefono, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamEmail, SqlDbType.VarChar, theContact.Correo, false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceContact.ChangeContact, parameters);

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

            return true;
        }

        /// <summary>
        /// Metodo para consultar todos los Contactos que pertenecen a una Empresa.
        /// <param name="typeCompany">es 1 si es Compania o 2 si es Cliente Potencial (Lead)</param>
        /// <param name="idCompany">es el id de la Empresa (Compania o Lead)
        /// </summary>
        /// <returns>Lista de contactos de la Empresa</returns>
        public static List<Contacto> ContactCompany(int typeCompany, int idCompany)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                ResourceContact.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();
            List<Contacto> listContact = new List<Contacto>();

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceContact.ParamTComp, SqlDbType.Int, typeCompany.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamIdComp, SqlDbType.Int, idCompany.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceContact.ContactCompany, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    int conId = int.Parse(row[ResourceContact.ConIdContact].ToString());
                    String conName = row[ResourceContact.ConNameContact].ToString();
                    String conLName = row[ResourceContact.ConLastNameContact].ToString();
                    String conDepart = row[ResourceContact.ConDepartmentContact].ToString();
                    String conRol = row[ResourceContact.ConRolContact].ToString();
                    String conTele = row[ResourceContact.ConPhoneContact].ToString();
                    String conEmail = row[ResourceContact.ConEmailContact].ToString();
                    int conTypeC = int.Parse(row[ResourceContact.ConTypeComp].ToString());
                    int conCompId = int.Parse(row[ResourceContact.ConIdComp].ToString());

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    Contacto theContact = new Contacto(conId, conName, conLName, conDepart, conRol, conTele, conEmail, conTypeC, conCompId);
                    listContact.Add(theContact);
                }

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

        /// <summary>
        /// Metodo para consultar el Contacto especifico.
        /// <param name="contact">objeto de tipo contacto a buscar en bd</param>
        /// </summary>
        /// <returns>Objeto de tipo Contacto si existe</returns>
        public static Contacto SingleContact(Contacto contact)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                ResourceContact.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();
            Contacto theContact = null;

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceContact.ParamId, SqlDbType.Int, contact.IdContacto.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceContact.SingleContact, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    int conId = int.Parse(row[ResourceContact.ConIdContact].ToString());
                    String conName = row[ResourceContact.ConNameContact].ToString();
                    String conLName = row[ResourceContact.ConLastNameContact].ToString();
                    String conDepart = row[ResourceContact.ConDepartmentContact].ToString();
                    String conRol = row[ResourceContact.ConRolContact].ToString();
                    String conTele = row[ResourceContact.ConPhoneContact].ToString();
                    String conEmail = row[ResourceContact.ConEmailContact].ToString();
                    int conTypeC = int.Parse(row[ResourceContact.ConTypeComp].ToString());
                    int conCompId = int.Parse(row[ResourceContact.ConIdComp].ToString());

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    theContact = new Contacto(conId, conName, conLName, conDepart, conRol, conTele, conEmail, conTypeC, conCompId);
                }

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

            return theContact;
        }

        //Metodos para la tabla Contacto_Proyecto

        /// <summary>
        /// Metodo para agregar un contacto a un proyecto en la base de datos.
        /// </summary>
        /// <param name="contact">objeto de tipo contacto a agregar al proyecto</param>
        /// <param name="proyect">objeto de tipo proyecto a asignarle el contacto</param>
        /// <returns>true si fue agregado</returns>
        public static Boolean AddContactProy(Contacto contact, Proyecto proyect)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceContact.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceContact.ParamIdContact, SqlDbType.Int, contact.IdContacto.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamIdProy, SqlDbType.Int, proyect.Idproyecto.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceContact.AddNewContactProy, parameters);

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

            return true;
        }

        /// <summary>
        /// Metodo para consultar todos los Contactos que pertenecen a un Proyecto.
        /// <param name="proyect">objeto de tipo Proyecto a consultar sus contactos</param>
        /// </summary>
        /// <returns>Lista de contactos del Proyecto</returns>
        public static List<Contacto> ContactProyect(Proyecto theProyect)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                ResourceContact.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();
            List<Contacto> listContact = new List<Contacto>();

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceContact.ParamIdProy, SqlDbType.Int, theProyect.Idproyecto.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceContact.ContactProyect, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    int conId = int.Parse(row[ResourceContact.ConIdContact].ToString());
                    String conName = row[ResourceContact.ConNameContact].ToString();
                    String conLName = row[ResourceContact.ConLastNameContact].ToString();
                    String conDepart = row[ResourceContact.ConDepartmentContact].ToString();
                    String conRol = row[ResourceContact.ConRolContact].ToString();
                    String conTele = row[ResourceContact.ConPhoneContact].ToString();
                    String conEmail = row[ResourceContact.ConEmailContact].ToString();
                    int conTypeC = int.Parse(row[ResourceContact.ConTypeComp].ToString());
                    int conCompId = int.Parse(row[ResourceContact.ConIdComp].ToString());

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    Contacto theContact = new Contacto(conId, conName, conLName, conDepart, conRol, conTele, conEmail, conTypeC, conCompId);
                    listContact.Add(theContact);
                }

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

        /// <summary>
        /// Metodo para eliminar un contacto de un proyecto en la base de datos.
        /// </summary>
        /// <param name="contact">objeto de tipo Contacto a eliminar en bd</param>
        /// <param name="proyect">objeto de tipo Proyecto a eliminar su contacto</param>
        /// <returns>true si fue eliminado</returns>
        public static Boolean DeleteContactProyect(Contacto contact, Proyecto proyect)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceContact.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceContact.ParamIdContact, SqlDbType.Int, contact.IdContacto.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamIdProy, SqlDbType.Int, proyect.Idproyecto.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceContact.DeleteContactProyect, parameters);

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

            return true;
        }
        //Falta consultar contactos que no estan en un proyecto
        /// <summary>
        /// Metodo para consultar todos los Contactos que pertenecen a un Proyecto.
        /// <param name="proyect">objeto de tipo Proyecto a consultar sus contactos</param>
        /// </summary>
        /// <returns>Lista de contactos del Proyecto</returns>
        public static List<Contacto> ContactNoProyect(Proyecto theProyect)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceContact.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();
            List<Contacto> listContact = new List<Contacto>();

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceContact.ParamIdProy, SqlDbType.Int, theProyect.Idproyecto.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceContact.ContactNoProyect, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    int conId = int.Parse(row[ResourceContact.ConIdContact].ToString());
                    String conName = row[ResourceContact.ConNameContact].ToString();
                    String conLName = row[ResourceContact.ConLastNameContact].ToString();
                    String conDepart = row[ResourceContact.ConDepartmentContact].ToString();
                    String conRol = row[ResourceContact.ConRolContact].ToString();
                    String conTele = row[ResourceContact.ConPhoneContact].ToString();
                    String conEmail = row[ResourceContact.ConEmailContact].ToString();
                    int conTypeC = int.Parse(row[ResourceContact.ConTypeComp].ToString());
                    int conCompId = int.Parse(row[ResourceContact.ConIdComp].ToString());

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    Contacto theContact = new Contacto(conId, conName, conLName, conDepart, conRol, conTele, conEmail, conTypeC, conCompId);
                    listContact.Add(theContact);
                }

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
    }
}
