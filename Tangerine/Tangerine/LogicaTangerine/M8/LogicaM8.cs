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

        public List<Facturacion> fillTable()
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

        public bool AddNewContact(Facturacion factura)
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

        public Facturacion SearchFactura(int idFactura)
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
    }
}
