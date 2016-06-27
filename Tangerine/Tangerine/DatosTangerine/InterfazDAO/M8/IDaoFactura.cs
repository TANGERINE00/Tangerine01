using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M8
{
    public interface IDaoFactura : IDao
    {
        /// <summary>
        /// Metodo para eliminar una factura
        /// </summary>
        /// <param name="parametro">Entidad Factura</param>
        /// <returns>Retorna true cuando la factura es eliminada</returns>
        bool DeleteFactura(Entidad parametro);

        /// <summary>
        /// Metodo para anular una factura
        /// </summary>
        /// <param name="parametro">Entidad Factura</param>
        /// <returns>Retorna true cuando la factura es anulada</returns>
        bool AnnularFactura(Entidad parametro);

        /// <summary>
        /// Metodo para consultar las facturas de una compania
        /// </summary>
        /// <param name="parametro">Entidad compania</param>
        /// <returns>Retorna lista de factura</returns>
        List<Entidad> ContactFacturasCompania(Entidad parametro);

        /// <summary>
        /// Metodo para consultar las facturas pagadas de una compania
        /// </summary>
        /// <param name="parametro">Entidad compania</param>
        /// <returns>Retorna lista de factura</returns>
        List<Entidad> ContactFacturasPagadasCompania(Entidad parametro);

        /// <summary>
        /// Metodo para consultar el monto restante a pagar de una factura
        /// </summary>
        /// <param name="parametro">Entidad factura</param>
        /// <returns>double con el valor a pagar</returns>
        double ContactMontoRestanteFactura(Entidad parametro);

        /// <summary>
        /// Metodo para consultar si una factura ya existe
        /// </summary>
        /// <param name="parametro">Entidad factura</param>
        /// <returns>Retorna true si existe factura</returns>
        bool CheckExistingInvoice(Entidad parametro);
    }
}
