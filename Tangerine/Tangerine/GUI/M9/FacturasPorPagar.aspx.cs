using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine.M9;
using LogicaTangerine.M8;
using DominioTangerine;


namespace Tangerine.GUI.M9
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        LogicaM8 prueba = new LogicaM8();

        public string factura
        {
            get
            {
                return this.tabla.Text;
            }

            set
            {
                this.tabla.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            //En este try atrapo el valor del id del Contacto si existe
            //para luego ser eliminado de los contactos de la empresa
            int identificador = int.Parse(Request.QueryString["id"]);
            try
            {
                if (!IsPostBack)
                {
                    List<Facturacion> listFacturas = prueba.SearchFacturasCompania(identificador);

                    if (listFacturas.Count() < 1)
                    {
                        factura += ResourceLogicaM9.AbrirTD + "No hay facturas asociadas" + ResourceLogicaM9.CerrarTD;
                    }
                    else
                    {

                        foreach (Facturacion theFactura in listFacturas)
                        {
                            factura += ResourceLogicaM9.AbrirTR;
                            factura += ResourceLogicaM9.AbrirTD + theFactura.idFactura + ResourceLogicaM9.CerrarTD;
                            factura += ResourceLogicaM9.AbrirTD + theFactura.fechaFactura.ToShortDateString() + ResourceLogicaM9.CerrarTD;
                            factura += ResourceLogicaM9.EtiquetaPorPagar;
                            factura += ResourceLogicaM9.AbrirTD + theFactura.descripcionFactura + ResourceLogicaM9.CerrarTD;
                            factura += ResourceLogicaM9.AbrirTD + theFactura.montoFactura + " " + theFactura.tipoMoneda + ResourceLogicaM9.CerrarTD;

                            //Boton para cargar el pago
                            factura += ResourceLogicaM9.botonPagarAbrir + theFactura.idFactura + ResourceLogicaM9.botonPagarCerrar;
                        }
                    }

                }
            }
            catch (Exception ex)
            { 
            
            }

        }
    }
}