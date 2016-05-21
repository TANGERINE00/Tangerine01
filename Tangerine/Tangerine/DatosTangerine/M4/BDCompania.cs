using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;

namespace DatosTangerine.M4
{
    public class BDCompania
    {
        BDConexion theConnection;
        List<Parametro> parameters;
        Parametro theParam = new Parametro();

        /// <summary>
        /// Metodo para agregar una compañia nueva en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Compania para agregar en bd</param>
        /// <returns>true si fue agregado</returns>
        public static bool AddCompany(Compania theCompany)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceCompany.ParamNombre, SqlDbType.VarChar, theCompany.NombreCompania, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamRif, SqlDbType.VarChar, theCompany.RifCompania, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamEmail, SqlDbType.VarChar, theCompany.EmailCompania, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamTelefono, SqlDbType.VarChar, theCompany.TelefonoCompania, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamAcronimo, SqlDbType.VarChar, theCompany.AcronimoCompania, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamFechaRegistro, SqlDbType.Date, theCompany.FechaRegistroCompania.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamStatus, SqlDbType.Int, theCompany.StatusCompania.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamPresupuesto, SqlDbType.Int, theCompany.PresupuestoCompania.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamPlazoPago, SqlDbType.Int, theCompany.PlazoPagoCompania.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamIdLugar, SqlDbType.Int, theCompany.IdLugar.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M4_AgregarCompania y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceCompany.AddNewCompany, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

        /// <summary>
        /// Metodo para consultar el ultimo id de compania en la base de datos.
        /// </summary>
        /// <returns>el ultimo id de compania registrado</returns>
        public static int ConsultLastCompanyId()
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();
            int mayorId = 0;

            try
            {
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceCompany.ConsultLastCompanyId, parameters);


                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    mayorId = int.Parse(row[ResourceCompany.ComIdCompany].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return mayorId;
        }

        /// <summary>
        /// Metodo para eliminar una compañia en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Compania para borrar en bd</param>
        /// <returns>true si fue agregado</returns>
        public static bool DeleteCompany(Compania theCompany)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceCompany.ParamId, SqlDbType.Int, theCompany.IdCompania.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M4_AgregarCompania y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceCompany.DeleteCompany, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }


        /// <summary>
        /// Metodo para habilitar una compañia en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Compania para habilitar en bd</param>
        /// <returns>true si fue agregado</returns>
        public static bool EnableCompany(Compania theCompany)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceCompany.ParamId, SqlDbType.Int, theCompany.IdCompania.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamStatus, SqlDbType.Int, "1", false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M4_InhabilitarHabilitar y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceCompany.DisableAbleComany, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

        /// <summary>
        /// Metodo para inhabilitar una compañia en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Compania para habilitar en bd</param>
        /// <returns>true si fue agregado</returns>
        public static bool DisableCompany(Compania theCompany)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceCompany.ParamId, SqlDbType.Int, theCompany.IdCompania.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamStatus, SqlDbType.Int, "0", false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M4_InhabilitarHabilitar y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceCompany.DisableAbleComany, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

       
        /// <summary>
        /// Metodo para modificar una compañia en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Compania para modificar en bd</param>
        /// <returns>true si fue modificado</returns>
        public static Boolean ChangeCompany(Compania theCompany)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceCompany.ParamId, SqlDbType.Int, theCompany.IdCompania.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamNombre, SqlDbType.VarChar, theCompany.NombreCompania, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamRif, SqlDbType.VarChar, theCompany.RifCompania, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamEmail, SqlDbType.VarChar, theCompany.EmailCompania, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamTelefono, SqlDbType.VarChar, theCompany.TelefonoCompania, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamAcronimo, SqlDbType.VarChar, theCompany.AcronimoCompania, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamFechaRegistro, SqlDbType.Date, theCompany.FechaRegistroCompania.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamStatus, SqlDbType.Int, theCompany.StatusCompania.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamPresupuesto, SqlDbType.Int, theCompany.PresupuestoCompania.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamPlazoPago, SqlDbType.Int, theCompany.PlazoPagoCompania.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceCompany.ParamIdLugar, SqlDbType.Int, theCompany.IdLugar.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceCompany.ChangeCompany, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

       
        /// <summary>
        /// Metodo para consultar una compañia en especifico.
        /// Recibe un parametros: idCompany que es el id de la Compañia a consultar.
        /// </summary>
        /// <returns>Lista de contactos de la Empresa</returns>
        public static Compania ConsultCompany(int idCompany)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            Compania theCompany = new Compania();

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceCompany.ParamId, SqlDbType.Int, idCompany.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceCompany.ConsultCompany, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];

                int comId = int.Parse(row[ResourceCompany.ComIdCompany].ToString());
                String comName = row[ResourceCompany.ComNameCompany].ToString();
                String comRif = row[ResourceCompany.ComRifCompany].ToString();
                String comEmail = row[ResourceCompany.ComEmailCompany].ToString();
                String comTelephone = row[ResourceCompany.ComTelephoneCompany].ToString();
                String comAcronym = row[ResourceCompany.ComAcronymCompany].ToString();
                DateTime comRegisterDate = DateTime.Parse(row[ResourceCompany.ComRegisterDateCompany].ToString());
                int comStatus = int.Parse(row[ResourceCompany.ComStatusCompany].ToString());
                int comBudget = int.Parse(row[ResourceCompany.ComBudgetCompany].ToString());
                int comDeadline = int.Parse(row[ResourceCompany.ComDeadlineCompany].ToString()); 
                int comIdPlace = int.Parse(row[ResourceCompany.ComIdPlace].ToString());

                //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                Compania theCompanybeta = new Compania(comId, comName, comRif, comEmail, comTelephone, comAcronym, 
                                                    comRegisterDate, comStatus, comBudget, comDeadline, comIdPlace);

                theCompany = theCompanybeta;
            
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return theCompany;
        }

        
        /// <summary>
        /// Metodo para consultar todas las Compañias registradas en la BD.
        /// Recibe cero parametros.
        /// </summary>
        /// <returns>Lista de Companias registradas</returns>
        public static List<Compania> ConsultCompanies()
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            List<Compania> listCompany = new List<Compania>();

            try
            {
                theConnection.Conectar();

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceCompany.ConsultCompanies, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int comId = int.Parse(row[ResourceCompany.ComIdCompany].ToString());
                    String comName = row[ResourceCompany.ComNameCompany].ToString();
                    String comRif = row[ResourceCompany.ComRifCompany].ToString();
                    String comEmail = row[ResourceCompany.ComEmailCompany].ToString();
                    String comTelephone = row[ResourceCompany.ComTelephoneCompany].ToString();
                    String comAcronym = row[ResourceCompany.ComAcronymCompany].ToString();
                    DateTime comRegisterDate = DateTime.Parse(row[ResourceCompany.ComRegisterDateCompany].ToString());
                    int comStatus = int.Parse(row[ResourceCompany.ComStatusCompany].ToString());
                    int comBudget = int.Parse(row[ResourceCompany.ComBudgetCompany].ToString());
                    int comDeadline = int.Parse(row[ResourceCompany.ComDeadlineCompany].ToString());
                    int comIdPlace = int.Parse(row[ResourceCompany.ComIdPlace].ToString());

                    Compania theCompany = new Compania(comId, comName, comRif, comEmail, comTelephone, comAcronym,
                                                         comRegisterDate, comStatus, comBudget, comDeadline, comIdPlace);
                    listCompany.Add(theCompany);
                }

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listCompany;
        }
    }
}
