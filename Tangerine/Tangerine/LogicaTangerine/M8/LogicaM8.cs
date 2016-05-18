using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M8;

namespace LogicaTangerine.M8
{
    public class LogicaM8
    {
        public Facturacion theFactura;
        List<Facturacion> answer;
        bool answer2;
        

        public void init()
        {

        }

        public List<Facturacion> getFacturas()
        {
            try
            {
                return BDFactura.ContactFacturas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddNewFactura( Facturacion factura )
        {
            try
            {
                return BDFactura.AddFactura(factura);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ChangeExistingFactura( Facturacion factura )
        {
            try
            {
                return BDFactura.ChangeFactura(factura);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Facturacion SearchFactura( int idFactura )
        {
            try
            {
                return BDFactura.ContactFactura(idFactura);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Compania SearchCompaniaFactura( int idCompania )
        {
            try
            {
                return BDFactura.ConsultCompany(idCompania);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Proyecto SearchProyectoFactura(int idProyecto)
        {
            try
            {
                return BDFactura.ContactProyectoFactura( idProyecto );
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Facturacion> SearchFacturasCompania(int idCompania)
        {
            try
            {
                return BDFactura.ContactFacturasCompania(idCompania);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
