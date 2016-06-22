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
using DatosTangerine.M4;

using System.Data.SqlClient;
using ExcepcionesTangerine.M9;

using ExcepcionesTangerine;

namespace DatosTangerine.DAO.M9
{
    public class DAOPago : DAOGeneral , IDAOPago
    {
    
        /// <summary>
        /// Metodo para Agregar un Pago a la BD
        /// </summary>
        /// <param name="pagoParam">Entidad con la informacion que se va a agregar a la BD</param>
        /// <returns></returns>
        public bool Agregar (Entidad pagoParam)
        {

           try
            {
                DominioTangerine.Entidades.M9.Pago pago = (DominioTangerine.Entidades.M9.Pago)pagoParam;
                List<Parametro> parametros = new List<Parametro>();

                Parametro parametro = new Parametro(RecursoDAOPago.ParamCod, SqlDbType.Int, pago.codPago.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursoDAOPago.ParamMonto, SqlDbType.Int, pago.montoPago.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursoDAOPago.ParamMoneda, SqlDbType.VarChar, pago.monedaPago, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursoDAOPago.ParamForma, SqlDbType.VarChar, pago.formaPago, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursoDAOPago.ParamIdFactura, SqlDbType.Int, pago.idFactura.ToString(), false);
                parametros.Add(parametro);

                List<Resultado> resultados = EjecutarStoredProcedure(RecursoDAOPago.AgregarPago, parametros);

                if (resultados != null)
                {
                    CargarStatus(pago.idFactura, 1);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExceptionDataBaseM9Tangerine(RecursoDAOPago.CodigoErrorSQL,RecursoDAOPago.MensajeErrorSQL,ex);
            }
        }
    
        /// <summary>
        /// Metodo para cambiar el Status de la factura a pagada
        /// </summary>
        /// <param name="factura">Entero con el id de la factura que se va a cambiar el status</param>
        /// <param name="status">Entero con el valor del status (valor 1) para indicar que la factura se pago</param>
        /// <returns></returns>
        public bool CargarStatus (int factura, int status)
        {
            List<Parametro> parametros = new List<Parametro>();

            Parametro parametro = new Parametro(RecursoDAOPago.ParamIdFactura, SqlDbType.Int, factura.ToString(),false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursoDAOPago.ParamStatus, SqlDbType.Int, status.ToString(),false);
            parametros.Add(parametro);

            List<Resultado> resultados =  EjecutarStoredProcedure(RecursoDAOPago.CambiarStatus, parametros);
            if (resultados!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Entidad> ConsultarPagosCompania(Entidad parametro)
        {
            List<Parametro> parameters = new List<Parametro>();
            CompaniaM4 theCompany = (CompaniaM4)parametro;
            Parametro theParam = new Parametro();
            List<Entidad> listaPagos = new List<Entidad>();

            
            try
            {
                theParam = new Parametro(RecursoDAOPago.ParamIdCompania, SqlDbType.Int, theCompany.Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar pagos
                DataTable dt = EjecutarStoredProcedureTuplas(RecursoDAOPago.ConsultarHistoricoPagos, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int facId = int.Parse(row[RecursoDAOPago.FacIdFactura].ToString());
                    DateTime PagoFecha = DateTime.Parse(row[RecursoDAOPago.PagoFecha].ToString());
                    int PagoMonto = int.Parse(row[RecursoDAOPago.PagoMonto].ToString());
                    String PagoMoneda = row[RecursoDAOPago.PagoMoneda].ToString();

                    Entidad pago = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPago_M9(facId, PagoFecha, PagoMonto, PagoMoneda);

                    listaPagos.Add(pago);
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
                throw new ExcepcionesTangerine.M8.WrongFormatException(ResourceCompany.Codigo_Error_Formato,
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

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    
    }

}
