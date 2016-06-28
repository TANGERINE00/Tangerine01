using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M9;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M9
{
    public interface IDAOPago : IDao
    {
        /// <summary>
        /// Método para cargar el status de una factura
        /// </summary>
        /// <param name="factura"></param>
        /// <param name="status"></param>
        /// <returns>Devuelve un boleano al cambiar el status</returns>
        bool CargarStatus(int factura, int status);
        /// <summary>
        /// Método que consulta todos los pagos hechos por una compañia
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>Devuelve una lista de pagos</returns>
        List<Entidad> ConsultarPagosCompania(Entidad parametro);
        /// <summary>
        /// Método que elimina un pago
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns>Devuelve true si el pago fue eliminado</returns>
        bool EliminarPago(Entidad parametro);
    
    }
}
