using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;
using DatosTangerine.M4;
using DatosTangerine.M7;
using ExcepcionesTangerine;

namespace DatosTangerine.M8
{
    public class BDFactura
    {
        BDConexion theConnection;
        List<Parametro> parameters;
        Parametro theParam = new Parametro();

        /// <summary>
        /// Metodo para agregar una factura nuevo en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Facturacion para agregar en bd</param>
        /// <returns>true si fue agregado</returns>
        public static bool AddFactura(Facturacion theFactura)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamFecha_Emision, SqlDbType.DateTime, theFactura.fechaFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamFecha_Ultimo_Pago, SqlDbType.DateTime, theFactura.fechaUltimoPagoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Total, SqlDbType.Int, theFactura.montoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Restante, SqlDbType.Int, theFactura.montoRestanteFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamTipo_Moneda, SqlDbType.VarChar, theFactura.tipoMoneda, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamDescripcion, SqlDbType.VarChar, theFactura.descripcionFactura, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamEstatus, SqlDbType.Int, theFactura.estatusFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int, theFactura.idProyectoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdCompania, SqlDbType.Int, theFactura.idCompaniaFactura.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M8_AgregarFactura y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceFactura.AddNewFactura, parameters);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(RecursoGeneralBD.Codigo,
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
                throw new ExcepcionesTangerine.M4.WrongFormatException(ResourceCompany.Codigo_Error_Formato,
                     ResourceCompany.Mensaje_Error_Formato, ex);
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
            ResourceCompany.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }


        /// <summary>
        /// Metodo para eliminar un factura de la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Facturacion a eliminar en bd</param>
        /// <returns>true si fue eliminado</returns>
        public static bool DeleteFactura(Facturacion theFactura)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int, theFactura.idFactura.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M8_AgregarFactura y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceFactura.DeleteFactura, parameters);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(RecursoGeneralBD.Codigo,
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
                throw new ExcepcionesTangerine.M4.WrongFormatException(ResourceCompany.Codigo_Error_Formato,
                     ResourceCompany.Mensaje_Error_Formato, ex);
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
            ResourceCompany.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }


        /// <summary>
        /// Metodo para anular una factura de la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Facturacion a eliminar en bd</param>
        /// <returns>true si fue anulada</returns>
        public static bool AnnularFactura(Facturacion theFactura)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int, theFactura.idFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamFecha_Emision, SqlDbType.DateTime, theFactura.fechaFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamFecha_Ultimo_Pago, SqlDbType.DateTime, theFactura.fechaUltimoPagoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Total, SqlDbType.Int, theFactura.montoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Restante, SqlDbType.Int, theFactura.montoRestanteFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamTipo_Moneda, SqlDbType.VarChar, theFactura.tipoMoneda, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamDescripcion, SqlDbType.VarChar, theFactura.descripcionFactura, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamEstatus, SqlDbType.Int, theFactura.estatusFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int, theFactura.idProyectoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdCompania, SqlDbType.Int, theFactura.idCompaniaFactura.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M8_AnnularFactura y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceFactura.AnnularFactura, parameters);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(RecursoGeneralBD.Codigo,
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
                throw new ExcepcionesTangerine.M4.WrongFormatException(ResourceCompany.Codigo_Error_Formato,
                     ResourceCompany.Mensaje_Error_Formato, ex);
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
            ResourceCompany.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }


        /// <summary>
        /// Metodo para modificar un factura en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Facturacion para modificar en bd</param>
        /// <returns>true si fue modificado</returns>
        public static bool ChangeFactura(Facturacion theFactura)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int, theFactura.idFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamFecha_Emision, SqlDbType.DateTime, theFactura.fechaFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamFecha_Ultimo_Pago, SqlDbType.DateTime, theFactura.fechaUltimoPagoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Total, SqlDbType.Int, theFactura.montoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Restante, SqlDbType.Int, theFactura.montoRestanteFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamTipo_Moneda, SqlDbType.VarChar, theFactura.tipoMoneda, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamDescripcion, SqlDbType.VarChar, theFactura.descripcionFactura, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamEstatus, SqlDbType.Int, theFactura.estatusFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int, theFactura.idProyectoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdCompania, SqlDbType.Int, theFactura.idCompaniaFactura.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M8_ModificarFactura y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceFactura.ChangeFactura, parameters);

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(RecursoGeneralBD.Codigo,
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
                throw new ExcepcionesTangerine.M4.WrongFormatException(ResourceCompany.Codigo_Error_Formato,
                     ResourceCompany.Mensaje_Error_Formato, ex);
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
            ResourceCompany.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }


        /// <summary>
        /// Funcion que permite obtener los datos de una factura en especifico
        /// </summary>
        /// <param name="idFactura"></param>
        /// <returns>Retorna la factura en cuestion</returns>
        public static Facturacion ContactFactura(int idFactura)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            Facturacion theFactura = new Facturacion();

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int, idFactura.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceFactura.ContactFactura, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];

                int facId = int.Parse(row[ResourceFactura.FacIdFactura].ToString());
                DateTime facFecha = DateTime.Parse(row[ResourceFactura.FacFechaEmision].ToString());
                DateTime facFechaUltimoPago = DateTime.Parse(row[ResourceFactura.FacFechaUltimoPago].ToString());
                double facMonto = double.Parse(row[ResourceFactura.FacMontoTotal].ToString());
                double facMontoRestante = double.Parse(row[ResourceFactura.FacMontoRestante].ToString());
                String facTipoMoneda = row[ResourceFactura.FacTipoMoneda].ToString();
                String facDescripcion = row[ResourceFactura.FacDescripcion].ToString();
                int facEstatus = int.Parse(row[ResourceFactura.FacEstatus].ToString());
                int facIdProyecto = int.Parse(row[ResourceFactura.FacIdProyecto].ToString());
                int facIdCompania = int.Parse(row[ResourceFactura.FacIdCompania].ToString());

                //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                Facturacion theFacturabeta = new Facturacion(facId, facFecha, facFechaUltimoPago, facMonto, facMontoRestante, facTipoMoneda, facDescripcion,
                                                    facEstatus, facIdProyecto, facIdCompania);

                theFactura = theFacturabeta;

            }catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(RecursoGeneralBD.Codigo,
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
                throw new ExcepcionesTangerine.M4.WrongFormatException(ResourceCompany.Codigo_Error_Formato,
                     ResourceCompany.Mensaje_Error_Formato, ex);
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
            ResourceCompany.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            
            return theFactura;
        }

        /// <summary>
        /// Funcion que permite buscar todas las facturas en la base de datos
        /// </summary>
        /// <returns>Retorna la lista con todas las facturas</returns>
        public static List<Facturacion> ContactFacturas()
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<Facturacion> listFactura = new List<Facturacion>();

            try
            {
                theConnection.Conectar();


                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceFactura.ConsultFacturas, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int facId = int.Parse(row[ResourceFactura.FacIdFactura].ToString());
                    DateTime facFecha = DateTime.Parse(row[ResourceFactura.FacFechaEmision].ToString());
                    DateTime facFechaUltimoPago = DateTime.Parse(row[ResourceFactura.FacFechaUltimoPago].ToString());
                    double facMonto = double.Parse(row[ResourceFactura.FacMontoTotal].ToString());
                    double facMontoRestante = double.Parse(row[ResourceFactura.FacMontoRestante].ToString());
                    String facTipoMoneda = row[ResourceFactura.FacTipoMoneda].ToString();
                    String facDescripcion = row[ResourceFactura.FacDescripcion].ToString();
                    int facEstatus = int.Parse(row[ResourceFactura.FacEstatus].ToString());
                    int facIdProyecto = int.Parse(row[ResourceFactura.FacIdProyecto].ToString());
                    int facIdCompania = int.Parse(row[ResourceFactura.FacIdCompania].ToString());

                    //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                    Facturacion theFactura = new Facturacion(facId, facFecha, facFechaUltimoPago, facMonto, facMontoRestante, facTipoMoneda, facDescripcion,
                                                        facEstatus, facIdProyecto, facIdCompania);
                    listFactura.Add(theFactura);

                }


            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(RecursoGeneralBD.Codigo,
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
                throw new ExcepcionesTangerine.M4.WrongFormatException(ResourceCompany.Codigo_Error_Formato,
                     ResourceCompany.Mensaje_Error_Formato, ex);
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
            ResourceCompany.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
         
            return listFactura;
        }

        /// <summary>
        /// Metodo que permite buscar si ya existe una factura para una fecha, proyecto y compañia dada
        /// </summary>
        /// <param name="fechaEmision"></param>
        /// <param name="idProyecto"></param>
        /// <param name="idCompania"></param>
        /// <returns>Retorna un valor booleano para saber si ya existe la factura especifica</returns>
        public static bool CheckExistingInvoice(DateTime fechaEmision, int idProyecto, int idCompania)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            bool resultado = false;

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceFactura.ParamFecha_Emision, SqlDbType.Date, fechaEmision.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int, idProyecto.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdCompania, SqlDbType.Int, idCompania.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceFactura.VerifyExistingInvoice, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    resultado = true;
                }
            }
            
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(RecursoGeneralBD.Codigo,
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
                throw new ExcepcionesTangerine.M4.WrongFormatException(ResourceCompany.Codigo_Error_Formato,
                     ResourceCompany.Mensaje_Error_Formato, ex);
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
            ResourceCompany.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
         
            return resultado;
        }

        /// <summary>
        /// Funcion que permite buscar todas las facturas asociadas a una compañia
        /// </summary>
        /// <returns>Retorna la lista con todas las facturas</returns>
        public static List<Facturacion> ContactFacturasCompania( int idCompania )
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<Facturacion> listFactura = new List<Facturacion>();

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceFactura.ParamIdCompania, SqlDbType.Int, idCompania.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceFactura.ContactFacturasCompania, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int facId = int.Parse(row[ResourceFactura.FacIdFactura].ToString());
                    DateTime facFecha = DateTime.Parse(row[ResourceFactura.FacFechaEmision].ToString());
                    DateTime facFechaUltimoPago = DateTime.Parse(row[ResourceFactura.FacFechaUltimoPago].ToString());
                    double facMonto = double.Parse(row[ResourceFactura.FacMontoTotal].ToString());
                    double facMontoRestante = double.Parse(row[ResourceFactura.FacMontoRestante].ToString());
                    String facTipoMoneda = row[ResourceFactura.FacTipoMoneda].ToString();
                    String facDescripcion = row[ResourceFactura.FacDescripcion].ToString();
                    int facEstatus = int.Parse(row[ResourceFactura.FacEstatus].ToString());
                    int facIdProyecto = int.Parse(row[ResourceFactura.FacIdProyecto].ToString());
                    int facIdCompania = int.Parse(row[ResourceFactura.FacIdCompania].ToString());

                    Facturacion theFactura = new Facturacion(facId, facFecha, facFechaUltimoPago, facMonto, facMontoRestante, facTipoMoneda, facDescripcion,
                                                        facEstatus, facIdProyecto, facIdCompania);
                    listFactura.Add(theFactura);

                }


            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(RecursoGeneralBD.Codigo,
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
                throw new ExcepcionesTangerine.M4.WrongFormatException(ResourceCompany.Codigo_Error_Formato,
                     ResourceCompany.Mensaje_Error_Formato, ex);
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
            ResourceCompany.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
         
            return listFactura;
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
                int comIdPlace = int.Parse(row[ResourceCompany.ComIdPlace].ToString());

                //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                Compania theCompanybeta = new Compania(comId, comName, comRif, comEmail, comTelephone, comAcronym, 
                                                    comRegisterDate, comStatus, 1, 1, comIdPlace);

                theCompany = theCompanybeta;
            
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(RecursoGeneralBD.Codigo,
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
                throw new ExcepcionesTangerine.M4.WrongFormatException(ResourceCompany.Codigo_Error_Formato,
                     ResourceCompany.Mensaje_Error_Formato, ex);
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
            ResourceCompany.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
         

            return theCompany;
        }

        /// <summary>
        /// Metodo para consultar un Proyecto específico que pertenecen a la base de datos.
        /// Recibe UN parametro: idProyecto que es el numero de Proyecto del mismo.
        ///                     
        /// </summary>
        /// <returns>Un objeto de tipo Proyecto</returns>
        public static Proyecto ContactProyectoFactura(int idProyecto)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();
            Proyecto TheProyecto = new Proyecto();

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceFactura.ParamId_Proyecto, SqlDbType.Int, idProyecto.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceFactura.ContactProyecto, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];

                
                int proyId = int.Parse(row[ResourceProyecto.ProyIdProyecto].ToString());
                string proyNombre = row[ResourceProyecto.ProyNombre].ToString();
                string proyCodigo = row[ResourceProyecto.ProyCodigo].ToString();
                DateTime proyFechaInicio = DateTime.Parse(row[ResourceProyecto.ProyFechaInicio].ToString());
                DateTime proyFechaEstFin = DateTime.Parse(row[ResourceProyecto.ProyFechaEstFin].ToString());
                double proyCosto = double.Parse(row[ResourceProyecto.ProyCosto].ToString());
                String proyDescripcion = row[ResourceProyecto.ProyDescripcion].ToString();
                String proyRealizacion = row[ResourceProyecto.ProyRealizacion].ToString();
                String proyEstatus = row[ResourceProyecto.ProyEstatus].ToString();
                String proyRazon = row[ResourceProyecto.ProyRazon].ToString();
                String proyAcuerdoPago = row[ResourceProyecto.ProyAcuerdoPago].ToString();
                int proyIdPropuesta = int.Parse(row[ResourceProyecto.ProyIdPropuesta].ToString());
                int proyIdResponsable = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());
                int proyIdGerente = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());

                //Creo un objeto de tipo Proyecto con los datos de la fila y lo guardo. 
                Proyecto theProyectobeta = new Proyecto(proyId, proyNombre, proyCodigo, proyFechaInicio, proyFechaEstFin,
                                                    proyCosto, proyDescripcion, proyRealizacion, proyEstatus, proyRazon,
                                                    proyAcuerdoPago, proyIdPropuesta, proyIdResponsable, proyIdGerente);

                TheProyecto = theProyectobeta;

            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(RecursoGeneralBD.Codigo,
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
                throw new ExcepcionesTangerine.M4.WrongFormatException(ResourceCompany.Codigo_Error_Formato,
                     ResourceCompany.Mensaje_Error_Formato, ex);
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
            ResourceCompany.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
         
            return TheProyecto;
        }

        /// <summary>
        /// Metodo para consultar el monto restante de una factura por id
        /// </summary>
        /// <param name="idFactura"></param>
        /// <returns>Devuelve el monto restante de una factura por id</returns>
        public static double ContactMontoRestanteFactura(int idFactura)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();
            double montoRestante = 0;

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int, idFactura.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar el monto restante de la factura
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceFactura.ConsultMontoRestanteFactura, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];

                montoRestante = double.Parse(row[ResourceFactura.FacMontoRestante].ToString());
 
            }
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M8.NullArgumentException(RecursoGeneralBD.Codigo,
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
                throw new ExcepcionesTangerine.M4.WrongFormatException(ResourceCompany.Codigo_Error_Formato,
                     ResourceCompany.Mensaje_Error_Formato, ex);
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
            ResourceCompany.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
         

            return montoRestante;
        }
    }
}
