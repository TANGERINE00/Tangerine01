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


namespace DatosTangerine.M3
{
    public class BDClientePotencial
    {
  //     -----------------------------Listar Clientes Potencial ---------------------------------------------
       public static List<ClientePotencial> DatosListarClientePotencial()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<ClientePotencial> objetolistaClientePotencial = new List<ClientePotencial>();

           // List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            Boolean exito = false;
            List<Parametro> parametros = new List<Parametro>();

            //BDConexion conexion = new BDConexion();
            DataTable data = new DataTable();
            data = theConnection.EjecutarStoredProcedureTuplas(ResourceClientePotencial.SP_listarClientePotencial, parametros);
            try
            {
                foreach (DataRow row in data.Rows)
                {

                    //Empleado empleado = new Empleado();
                    ClientePotencial clientePotencial = new ClientePotencial();

                    clientePotencial.IdClientePotencial = Int32.Parse(row[ResourceClientePotencial.idClientePotencial].ToString());
                    clientePotencial.NombreClientePotencial = row[ResourceClientePotencial.nombreClientePotencial].ToString();
                    //ese nombre en mayuscula es el del set y el get de la capa de dominio

                    clientePotencial.RifClientePotencial = row[ResourceClientePotencial.rifClientePotencial].ToString();
                    clientePotencial.EmailClientePotencial = row[ResourceClientePotencial.emailClientePotencial].ToString();
                    clientePotencial.PresupuestoAnual_inversion = float.Parse(row[ResourceClientePotencial.presupuestoAnual_inversion].ToString());
                    clientePotencial.Status = Int32.Parse(row[ResourceClientePotencial.status].ToString());


                    objetolistaClientePotencial.Add(clientePotencial);

                }
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(RecursoGeneralBD.Codigo,
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
                throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(ResourceClientePotencial.Codigo_Error_Formato,
                    ResourceClientePotencial.Mensaje_Error_Formato, ex);
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
                ResourceClientePotencial.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
       
            return objetolistaClientePotencial;

        }

//------------------------------------------------------termino del listar cliente potencial -------------




        //public static bool AddContact(Contacto theContact)
            public static bool AgregarClientePotencial(ClientePotencial elClientePotencial)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceClientePotencial.AnombreClientePotencial, SqlDbType.VarChar, 
                elClientePotencial.NombreClientePotencial, false);
                parameters.Add(theParam);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceClientePotencial.ArifClientePotencial, SqlDbType.VarChar, 
                elClientePotencial.RifClientePotencial, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.AemailClientePotencial, SqlDbType.VarChar, 
                elClientePotencial.EmailClientePotencial, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.ApresupuestoAnualInversion, SqlDbType.Decimal, 
                elClientePotencial.PresupuestoAnual_inversion.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceClientePotencial.Astatus, SqlDbType.Decimal, 
                elClientePotencial.Status.ToString(), false);
                parameters.Add(theParam);


                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_agregar_clientePotencial, parameters);

            }

            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(RecursoGeneralBD.Codigo,
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
                throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(ResourceClientePotencial.Codigo_Error_Formato,
                    ResourceClientePotencial.Mensaje_Error_Formato, ex);
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
                ResourceClientePotencial.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);


            return true;
        }

        //----------------------------------------borrar el cliente potencial-----------------------
     
            public static Boolean BorrarClientePotencial(ClientePotencial elClientePotencial)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                
                List<Parametro> parameters = new List<Parametro>();
                BDConexion theConnection = new BDConexion();
                Parametro theParam = new Parametro();

                try
                {
                    //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                    //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                    theParam = new Parametro(ResourceClientePotencial.AidClientePotencial, SqlDbType.Int, 
                    elClientePotencial.IdClientePotencial.ToString(), false);
                    parameters.Add(theParam);

                    //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                    List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_eliminarClientePotencial, parameters);

                }
                catch (ArgumentNullException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                    throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(RecursoGeneralBD.Codigo,
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
                    throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(ResourceClientePotencial.Codigo_Error_Formato,
                        ResourceClientePotencial.Mensaje_Error_Formato, ex);
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
                    ResourceClientePotencial.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return true;
            }

       


//-----------------------------------------------------consultar -------------------
            public static ClientePotencial ConsultarClientePotencial(int idClientePotencial)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                List<Parametro> parameters = new List<Parametro>();
                BDConexion theConnection = new BDConexion();
                Parametro theParam = new Parametro();

                List<ClientePotencial> listClientePotencial = new List<ClientePotencial>();
                ClientePotencial elClientePotencial = null;

                try
                {
                    theConnection.Conectar();

                    theParam = new Parametro(ResourceClientePotencial.AidClientePotencial, SqlDbType.Int, 
                    idClientePotencial.ToString(), false);
                    parameters.Add(theParam);

                    //Guardo la tabla que me regresa el procedimiento de consultar contactos
                    DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceClientePotencial.SP_consultarClientePotencial, parameters);

                    //Por cada fila de la tabla voy a guardar los datos 
                    foreach (DataRow row in dt.Rows)
                    {

                        int IdClientePotencial = int.Parse(row[ResourceClientePotencial.idClientePotencial].ToString());
                        String NombreClientePotencial = row[ResourceClientePotencial.nombreClientePotencial].ToString();
                        String RifClientePotencial = row[ResourceClientePotencial.rifClientePotencial].ToString();
                        String EmailClientePotencial = row[ResourceClientePotencial.emailClientePotencial].ToString();
                        float PresupuestoAnual_inversion= float.Parse(row[ResourceClientePotencial.presupuestoAnual_inversion].ToString());
                        //String PresupuestoAnual_inversion = row[ResourceClientePotencial.emailClientePotencial].ToString();
                        int NumeroLlamadas = int.Parse(row[ResourceClientePotencial.numeroLlamadas].ToString());
                        int NumeroVisitas = int.Parse(row[ResourceClientePotencial.numeroVisitas].ToString());
                       
                        //  int conCompId = int.Parse(row[ResourceClientePotencial.ConIdComp].ToString());

                        //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                        elClientePotencial = new ClientePotencial(IdClientePotencial, NombreClientePotencial, RifClientePotencial, EmailClientePotencial, PresupuestoAnual_inversion, NumeroLlamadas, NumeroVisitas);
                      
                    }

                }
                catch (ArgumentNullException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                    throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(RecursoGeneralBD.Codigo,
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
                    throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(ResourceClientePotencial.Codigo_Error_Formato,
                        ResourceClientePotencial.Mensaje_Error_Formato, ex);
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
                    ResourceClientePotencial.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return elClientePotencial;
            }
//-----------------------------------------------------

            public static Boolean ModificarClientePotencial(ClientePotencial elClientePotencial)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                   
                List<Parametro> parameters = new List<Parametro>();
                BDConexion theConnection = new BDConexion();
                Parametro theParam = new Parametro();

                try
                {
                    //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                    //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                    theParam = new Parametro(ResourceClientePotencial.AidClientePotencial, SqlDbType.Int, 
                    elClientePotencial.IdClientePotencial.ToString(), false);
                    parameters.Add(theParam);

                    theParam = new Parametro(ResourceClientePotencial.AnombreClientePotencial, SqlDbType.VarChar, 
                    elClientePotencial.NombreClientePotencial, false);
                    parameters.Add(theParam);

                    theParam = new Parametro(ResourceClientePotencial.ArifClientePotencial, SqlDbType.VarChar, 
                    elClientePotencial.RifClientePotencial, false);
                    parameters.Add(theParam);

                    theParam = new Parametro(ResourceClientePotencial.AemailClientePotencial, SqlDbType.VarChar, 
                    elClientePotencial.EmailClientePotencial, false);
                    parameters.Add(theParam);

                    theParam = new Parametro(ResourceClientePotencial.ApresupuestoAnualInversion, SqlDbType.Decimal, 
                    elClientePotencial.PresupuestoAnual_inversion.ToString(), false);
                    parameters.Add(theParam);

                    theParam = new Parametro(ResourceClientePotencial.AnumLlamadas, SqlDbType.Int, 
                    elClientePotencial.NumeroLlamadas.ToString(), false);
                    parameters.Add(theParam);

                    theParam = new Parametro(ResourceClientePotencial.AnumVisitas, SqlDbType.Int, 
                    elClientePotencial.NumeroVisitas.ToString(), false);
                    parameters.Add(theParam);


                    //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                    List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_modificarClientePotencial, parameters);

                }
                catch (ArgumentNullException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                    throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(RecursoGeneralBD.Codigo,
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
                    throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(ResourceClientePotencial.Codigo_Error_Formato,
                        ResourceClientePotencial.Mensaje_Error_Formato, ex);
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
                    ResourceClientePotencial.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return true;

            }


            public static Boolean EliminarClientePotDef(ClientePotencial ClientPot)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                List<Parametro> parameters = new List<Parametro>();
                BDConexion theConnection = new BDConexion();
                Parametro theParam = new Parametro();

                try
                {
                    //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros 
                    //reciba su stored procedure a llamar
                    //Parametro recibe (nombre del primer parametro en su stored procedure, 
                    //el tipo de dato, el valor, false)
                    theParam = new Parametro(ResourceClientePotencial.AidClientePotencial,
                        SqlDbType.Int, ClientPot.IdClientePotencial.ToString(), false);
                    parameters.Add(theParam);

                    //Se manda a ejecutar en BDConexion el stored procedure 
                    //M5_AgregarContacto y todos los parametros que recibe
                    List<Resultado> results =
                        theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_eliminarClientePotencialDef, parameters);

                }

                catch (ArgumentNullException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                    throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }

                catch (FormatException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(ResourceClientePotencial.Codigo_Error_Formato,
                        ResourceClientePotencial.Mensaje_Error_Formato, ex);
                }
                catch (ExcepcionesTangerine.ExceptionTGConBD ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                    throw ex;
                }
                catch (SqlException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                    throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }
                catch (Exception ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                }
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    ResourceClientePotencial.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return true;
            }





            public static Boolean ActivarClientePotencial(ClientePotencial ClientPot)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                List<Parametro> parameters = new List<Parametro>();
                BDConexion theConnection = new BDConexion();
                Parametro theParam = new Parametro();

                try
                {
                    //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros 
                    //reciba su stored procedure a llamar
                    //Parametro recibe (nombre del primer parametro en su stored procedure, 
                    //el tipo de dato, el valor, false)
                    theParam = new Parametro(ResourceClientePotencial.AidClientePotencial,
                        SqlDbType.Int, ClientPot.IdClientePotencial.ToString(), false);
                    parameters.Add(theParam);

                    //Se manda a ejecutar en BDConexion el stored procedure 
                    //M5_AgregarContacto y todos los parametros que recibe
                    List<Resultado> results =
                        theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_ActivarClientePotencial, parameters);

                }

                catch (ArgumentNullException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                    throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }

                catch (FormatException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(ResourceClientePotencial.Codigo_Error_Formato,
                        ResourceClientePotencial.Mensaje_Error_Formato, ex);
                }
                catch (ExcepcionesTangerine.ExceptionTGConBD ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                    throw ex;
                }
                catch (SqlException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                    throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoGeneralBD.Codigo,
                        RecursoGeneralBD.Mensaje, ex);
                }
                catch (Exception ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                    throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                }
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                    ResourceClientePotencial.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return true;
            }


            public static Boolean PromoverClientePotencial(ClientePotencial elClientePotencial)
            {
                Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceClientePotencial.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                List<Parametro> parameters = new List<Parametro>();
                BDConexion theConnection = new BDConexion();
                Parametro theParam = new Parametro();

                try
                {
                    //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                    //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                    theParam = new Parametro(ResourceClientePotencial.AidClientePotencial, SqlDbType.Int,
                    elClientePotencial.IdClientePotencial.ToString(), false);
                    parameters.Add(theParam);

                    //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                    List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceClientePotencial.SP_promoverClientePotencial, parameters);

                }
                catch (ArgumentNullException ex)
                {
                    Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                    throw new ExcepcionesTangerine.M3.NullArgumentExceptionLeads(RecursoGeneralBD.Codigo,
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
                    throw new ExcepcionesTangerine.M3.WrongFormatExceptionLeads(ResourceClientePotencial.Codigo_Error_Formato,
                        ResourceClientePotencial.Mensaje_Error_Formato, ex);
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
                    ResourceClientePotencial.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

                return true;
            }

    
    
    
    }
}
