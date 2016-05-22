using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;
using DatosTangerine.M6;
using DatosTangerine.M4;
using ExcepcionesTangerine;


namespace DatosTangerine.M9
{
    public class BDPagos
    {
        
        Parametro theParam = new Parametro();

        //public static bool CargarPago(int idFactura, DateTime fechaPago, int numeroConfirmacion)

        public static bool CargarPago(Pago NuevoPago)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)

                theParam = new Parametro(ResourcePagos.ParamMoneda, SqlDbType.VarChar, NuevoPago.monedaPago, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourcePagos.ParamMonto, SqlDbType.Int, NuevoPago.montoPago.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourcePagos.ParamForma, SqlDbType.VarChar, NuevoPago.formaPago, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourcePagos.ParamCod, SqlDbType.Int, NuevoPago.codPago.ToString(), false);
                parameters.Add(theParam);

                //theParam = new Parametro(ResourcePagos.ParamFecha, SqlDbType.Date, NuevoPago.fechaPago.ToString(), false);
                //parameters.Add(theParam);

                theParam = new Parametro(ResourcePagos.ParamIdFactura, SqlDbType.Int, NuevoPago.idFactura.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M9_agregar_pago y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourcePagos.AgregarPago, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }


        /// <summary>
        /// Método para consultar el último id de compañía en la base de datos.
        /// </summary>
        /// <returns>Último id de compania registrada.</returns>
        public static int ultimoIdPago()
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            ResourceCompany.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
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
            catch (ArgumentNullException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M4.NullArgumentException(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
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
            return mayorId;
        }


        public static bool CargarStatus(int factura, int status)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)

                theParam = new Parametro(ResourcePagos.ParamIdFactura, SqlDbType.Int, factura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourcePagos.ParamStatus, SqlDbType.Int, status.ToString(), false);
                parameters.Add(theParam);

                
                //Se manda a ejecutar en BDConexion el stored procedure M9_agregar_pago y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourcePagos.CambiarStatus, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

    }

    
}
