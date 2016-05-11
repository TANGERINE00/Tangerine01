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
        BDFactura bdFactura = new BDFactura();

        public void init()
        {

        }

        public List<Facturacion> fillTable()
        {
            try
            {
                return bdFactura.ContactFacturas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddNewContact(Facturacion factura)
        {
            try
            {
                return bdFactura.AddFactura(factura);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Facturacion SearchFactura(int idFactura)
        {
            try
            {
                return bdFactura.ContactFactura(idFactura);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
