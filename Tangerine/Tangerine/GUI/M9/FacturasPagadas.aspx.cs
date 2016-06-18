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
    public partial class WebForm6 : System.Web.UI.Page
    {

        //LogicaM8 prueba = new LogicaM8();

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

        /// <summary>
        /// Metodo de carga de los elementos de la ventana.
        /// </summary>
        /// recibe un solo parametro, id de la compania para consultar todas las facturas asociadas, este parametro se recibe via URL
        /// <param name="id">Entero, representa el id de la empresa seleccionada</param>
        protected void Page_Load(object sender, EventArgs e)
        {

            //capturo el id de la compania que se esta enviando por el URL
            int identificador = int.Parse(Request.QueryString["id"]);
            try
            {
                if (!IsPostBack)
                {
                    ////con el id capturado utilizao el metodo SearchFacturas para mostrar todas las facturas asociadas a esa compania
                    //List<Facturacion> listFacturas = prueba.SearchFacturasPagadasCompania(identificador);

                    //if (listFacturas.Count() < 1)
                    //{
                    //   // factura += ResourceLogicaM9.AbrirTD + "No hay facturas asociadas" + ResourceLogicaM9.CerrarTD;
                    //}
                    //else
                    //{

                    //    foreach (Facturacion theFactura in listFacturas)
                    //    {
                    //        factura += ResourceLogicaM9.AbrirTR;
                    //        factura += ResourceLogicaM9.AbrirTD + theFactura.idFactura + ResourceLogicaM9.CerrarTD;
                    //        factura += ResourceLogicaM9.AbrirTD + theFactura.fechaFactura.ToShortDateString() + ResourceLogicaM9.CerrarTD;
                    //        factura += ResourceLogicaM9.EtiquetaPagada;
                    //        factura += ResourceLogicaM9.AbrirTD + theFactura.descripcionFactura + ResourceLogicaM9.CerrarTD;
                    //        factura += ResourceLogicaM9.AbrirTD + theFactura.montoFactura + " " + theFactura.tipoMoneda + ResourceLogicaM9.CerrarTD;

                    //        //Boton para cargar el pago de una factura especifica
                    //        factura += ResourceLogicaM9.botonPagarAbrir + theFactura.idFactura + ResourceLogicaM9.botonPagarCerrar;
                    //    }
                    //}

                }
            }
            catch (Exception ex)
            { 
            
            }

        }
    }
}