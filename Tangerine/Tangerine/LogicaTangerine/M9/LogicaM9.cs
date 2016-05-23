using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;
using DatosTangerine.M9;


namespace LogicaTangerine.M9
{
    public class LogicaM9
    {
        public Pago elPago;

        public void init()
        {

        }

        /// <summary>
        /// Metodo para agregar un pago a una factura con status por pagar
        /// </summary>
        /// <param name="pago">Objeto de tipo Pago
        /// <returns>Retorna true o false cuando realiza el pago</returns>

        public bool AgregarPago(Pago pago)
        {
            try
            {
                return BDPagos.CargarPago(pago);
            }
            catch (ArgumentNullException ex)
            {
                throw new ExcepcionesTangerine.M4.NullArgumentException(LogicResourcesM9.Codigo,
                    LogicResourcesM9.Mensaje, ex);
            }
            catch (SqlException ex)
            {
                throw new ExcepcionesTangerine.ExceptionTGConBD(LogicResourcesM9.Codigo,
                    LogicResourcesM9.Mensaje, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
