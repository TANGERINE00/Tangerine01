using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M9;
using DominioTangerine.Entidades.M9;
using DominioTangerine;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine.Entidades.M4;
using System.Data.SqlClient;
using ExcepcionesTangerine.M9;
using ExcepcionesTangerine;

namespace DatosTangerine.DAO.M9
{
    public class DAOPago : DAOGeneral , IDAOPago
    {

        #region IDAO
        /// <summary>
        /// Metodo para Agregar un Pago a la BD
        /// </summary>
        /// <param name="pagoParam">Entidad con la informacion que se va a agregar a la BD</param>
        /// <returns>Booleano que determina si el metodo se ejecuto con exito o no</returns>
        public bool Agregar (Entidad pagoParam)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                RecursoDAOPago.MensajeInicioInfoLogger,
                                System.Reflection.MethodBase.GetCurrentMethod().Name);
           try
            {
                DominioTangerine.Entidades.M9.Pago pago = (DominioTangerine.Entidades.M9.Pago)pagoParam;
                List<Parametro> parametros = new List<Parametro>();

                Parametro parametro = new Parametro(RecursoDAOPago.ParamCod, SqlDbType.Int, pago.codPago.ToString(), 
                    false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursoDAOPago.ParamMonto, SqlDbType.Int, pago.montoPago.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursoDAOPago.ParamMoneda, SqlDbType.VarChar, pago.monedaPago, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursoDAOPago.ParamForma, SqlDbType.VarChar, pago.formaPago, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursoDAOPago.ParamIdFactura, SqlDbType.Int, pago.idFactura.ToString(), 
                    false);
                parametros.Add(parametro);

                List<Resultado> resultados = EjecutarStoredProcedure(RecursoDAOPago.AgregarPago, parametros);

                if (resultados != null)
                {
                    CargarStatus(pago.idFactura, 1);
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                               RecursoDAOPago.MensajeFinInfoLogger,
                               System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                       RecursoDAOPago.MensajeFinInfoLoggerError, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;
                }
            }
               
           catch (ArgumentNullException ex)
           {

               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExcepcionesTangerine.M9.NullArgumentExceptionM9Tangerine(RecursoDAOPago.CodigoErrorNull,
                   RecursoDAOPago.MensajeErrorNull, ex);

           }
           catch(FormatException ex)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExcepcionesTangerine.M9.WrongFormatExceptionM9Tangerine(RecursoDAOPago.CodigoErrorFormato,
                   RecursoDAOPago.MensajeErrorFormato, ex);

           }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionDataBaseM9Tangerine(RecursoDAOPago.CodigoErrorSQL,
                    RecursoDAOPago.MensajeErrorSQL,ex);
            }
           catch (ExcepcionesTangerine.ExceptionTGConBD ex)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Codigo,
                  RecursoDAOPago.MensajeErrorSQL, ex);
           }
           catch (Exception ex)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoDAOPago.CodigoGeneral,
                   RecursoDAOPago.MensajeGeneral, ex);
           }
        }

        public List<Entidad> ConsultarTodos()
        {
            List<Parametro> parameters = new List<Parametro>();
            Parametro theParam = new Parametro();
            List<Entidad> listaPagos = new List<Entidad>();

            try
            {
                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(RecursoDAOPago.ConsultarPagos, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int facId = int.Parse(row[RecursoDAOPago.FK_Fac_id].ToString());
                    int codPago = int.Parse(row[RecursoDAOPago.PagoCod].ToString());
                    double montoPago = double.Parse(row[RecursoDAOPago.PagoMonto].ToString());
                    String monedaPago = row[RecursoDAOPago.PagoMoneda].ToString();
                    String formaPago = row[RecursoDAOPago.PagoForma].ToString();

                    //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                    Pago elPago = new Pago(codPago, montoPago, monedaPago, formaPago, facId);

                    listaPagos.Add(elPago);
                }


            }
            catch (ArgumentNullException ex)
            {

                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M9.NullArgumentExceptionM9Tangerine(RecursoDAOPago.CodigoErrorNull,
                    RecursoDAOPago.MensajeErrorNull, ex);

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M9.WrongFormatExceptionM9Tangerine(RecursoDAOPago.CodigoErrorFormato,
                    RecursoDAOPago.MensajeErrorFormato, ex);

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionDataBaseM9Tangerine(RecursoDAOPago.CodigoErrorSQL,
                    RecursoDAOPago.MensajeErrorSQL, ex);
            }
            catch (Exception ex)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoDAOPago.CodigoGeneral,
                   RecursoDAOPago.MensajeGeneral, ex);
           }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOPago.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listaPagos;
        }
       
    
        public Boolean Modificar (Entidad e)
        {
          throw new NotImplementedException();
        }

        public Entidad ConsultarXId(Entidad id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDAOPago
        /// <summary>
        /// Metodo para cambiar el Status de la factura a pagada
        /// </summary>
        /// <param name="factura">Entero con el id de la factura que se va a cambiar el status</param>
        /// <param name="status">Entero con el valor del status (valor 1) para indicar que la factura se pago</param>
        /// <returns>Booleano que determina si el metodo se ejecuto con exito o no</returns>
        public bool CargarStatus(int factura, int status)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                RecursoDAOPago.MensajeInicioInfoLogger,
                                System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                List<Parametro> parametros = new List<Parametro>();

                Parametro parametro = new Parametro(RecursoDAOPago.ParamIdFactura, SqlDbType.Int, factura.ToString(),
                    false);
                parametros.Add(parametro);
                parametro = new Parametro(RecursoDAOPago.ParamStatus, SqlDbType.Int, status.ToString(), false);
                parametros.Add(parametro);

                List<Resultado> resultados = EjecutarStoredProcedure(RecursoDAOPago.CambiarStatus, parametros);
                if (resultados != null)
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                        RecursoDAOPago.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return true;
                }
                else
                {
                    Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                      RecursoDAOPago.MensajeFinInfoLoggerError, System.Reflection.MethodBase.GetCurrentMethod().Name);
                    return false;
                }

            }
            catch (ArgumentNullException ex)
            {

                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M9.NullArgumentExceptionM9Tangerine(RecursoDAOPago.CodigoErrorNull,
                    RecursoDAOPago.MensajeErrorNull, ex);

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M9.WrongFormatExceptionM9Tangerine(RecursoDAOPago.CodigoErrorFormato,
                    RecursoDAOPago.MensajeErrorFormato, ex);

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionDataBaseM9Tangerine(RecursoDAOPago.CodigoErrorSQL,
                    RecursoDAOPago.MensajeErrorSQL, ex);
            }
            catch (Exception ex)
           {
               Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoDAOPago.CodigoGeneral,
                   RecursoDAOPago.MensajeGeneral, ex);
           }
        }
        

        /// <summary>
        /// Metodo del DAO para invocar Stored Procedure de todos los Pagos realizados por una compania
        /// </summary>
        /// <param name="parametro">Entidad, parametro con id de la compania que se va realizar la busqueda de pagos
        /// </param>
        /// <returns>Lista de Entidades con los pagos realizados por una compania</returns>
        public List<Entidad> ConsultarPagosCompania(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                                RecursoDAOPago.MensajeInicioInfoLogger,
                                System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Parametro> parameters = new List<Parametro>();
            Entidad theCompany = (DominioTangerine.Entidades.M4.CompaniaM4)parametro;
            Parametro theParam = new Parametro();
            List<Entidad> listaPagos = new List<Entidad>();


            try
            {
                theParam = new Parametro(RecursoDAOPago.ParamIdCompania, SqlDbType.Int, theCompany.Id.ToString(),
                    false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar pagos
                DataTable dt = EjecutarStoredProcedureTuplas(RecursoDAOPago.ConsultarHistoricoPagos, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int facId = int.Parse(row[RecursoDAOPago.FacIdFactura].ToString());
                    DateTime PagoFecha = DateTime.Parse(row[RecursoDAOPago.PagoFecha].ToString());
                    double PagoMonto = double.Parse(row[RecursoDAOPago.PagoMonto].ToString());
                    String PagoMoneda = row[RecursoDAOPago.PagoMoneda].ToString();
                    int PagoCodAprob = int.Parse(row[RecursoDAOPago.PagoCod].ToString());

                    Entidad pago = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPago_M9(facId, PagoFecha,
                        PagoMonto, PagoMoneda, PagoCodAprob);

                    listaPagos.Add(pago);
                }


            }
            catch (ArgumentNullException ex)
            {

                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M9.NullArgumentExceptionM9Tangerine(RecursoDAOPago.CodigoErrorNull,
                    RecursoDAOPago.MensajeErrorNull, ex);

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M9.WrongFormatExceptionM9Tangerine(RecursoDAOPago.CodigoErrorFormato,
                    RecursoDAOPago.MensajeErrorFormato, ex);

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionDataBaseM9Tangerine(RecursoDAOPago.CodigoErrorSQL,
                    RecursoDAOPago.MensajeErrorSQL, ex);
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
            RecursoDAOPago.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                      RecursoDAOPago.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return listaPagos;
        }

        /// <summary>
        /// Metodo para eliminar un pago
        /// </summary>
        /// <param name="parametro">Entidad con el pago que se va a eliminar</param>
        /// <returns>Booleano que determina si el metodo se ejecuto con exito o no</returns>
        public bool EliminarPago(Entidad parametro)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                               RecursoDAOPago.MensajeInicioInfoLogger,
                               System.Reflection.MethodBase.GetCurrentMethod().Name);
            List<Parametro> parameters = new List<Parametro>();
            DominioTangerine.Entidades.M9.Pago elPago = (DominioTangerine.Entidades.M9.Pago)parametro;
            Parametro theParam = new Parametro();

            try
            {

                theParam = new Parametro(RecursoDAOPago.ParamCod, SqlDbType.Int, elPago.codPago.ToString(), false);
                parameters.Add(theParam);

                EjecutarStoredProcedure(RecursoDAOPago.EliminarPago, parameters);

            }
            catch (ArgumentNullException ex)
            {

                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M9.NullArgumentExceptionM9Tangerine(RecursoDAOPago.CodigoErrorNull,
                    RecursoDAOPago.MensajeErrorNull, ex);

            }
            catch (FormatException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M9.WrongFormatExceptionM9Tangerine(RecursoDAOPago.CodigoErrorFormato,
                    RecursoDAOPago.MensajeErrorFormato, ex);

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionDataBaseM9Tangerine(RecursoDAOPago.CodigoErrorSQL,
                    RecursoDAOPago.MensajeErrorSQL, ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoDAOPago.CodigoGeneral,
                    RecursoDAOPago.MensajeGeneral, ex);
            }
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursoDAOPago.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            return true;
        }

        #endregion

    }

}
