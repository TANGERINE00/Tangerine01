using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M8;
using LogicaTangerine.M4;
using LogicaTangerine.M7;

namespace Tangerine.GUI.M8
{
    public partial class ConsultarFacturaM8 : System.Web.UI.Page
    {

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
            LogicaM8 prueba = new LogicaM8();
            LogicaM4 pruebaM4 = new LogicaM4();

            if (!IsPostBack)
            {
                //Aqui ejecuto el filltable de la clase creada en logica para probar la conexion a la bd
                //los parametros son tipo de empresa 1 (Compania), id de la empresa 1.
                //prueba.fillTable(1,1);
                List<Facturacion> listFactura = prueba.getFacturas();

                try
                {
                    foreach (Facturacion theFactura in listFactura)
                    {
                        factura += ResourceGUIM8.OpenTR;

                        factura += ResourceGUIM8.OpenTD + theFactura.idFactura.ToString() + ResourceGUIM8.CloseTD;
                        Compania compania = prueba.SearchCompaniaFactura(int.Parse(theFactura.idCompaniaFactura.ToString()));
                        factura += ResourceGUIM8.OpenTD + compania.NombreCompania.ToString() + ResourceGUIM8.CloseTD;
                        Proyecto proyecto = prueba.SearchProyectoFactura(int.Parse(theFactura.idProyectoFactura.ToString()));
                        factura += ResourceGUIM8.OpenTD + proyecto.Nombre.ToString() + ResourceGUIM8.CloseTD;
                        factura += ResourceGUIM8.OpenTD + theFactura.descripcionFactura.ToString() + ResourceGUIM8.CloseTD;
                        factura += ResourceGUIM8.OpenTD + theFactura.fechaFactura.ToString("dd/MM/yyyy") + ResourceGUIM8.CloseTD;
                       
                        //Equals cero para factura "Por Pagar"
                        if (theFactura.estatusFactura.Equals(0))
                        {
                            factura += ResourceGUIM8.OpenTD + ResourceGUIM8.porPagar + ResourceGUIM8.CloseTD;
                          
                        }
                        //Equals uno para factura "Pagada"
                        else if (theFactura.estatusFactura.Equals(1))
                        {
                            factura += ResourceGUIM8.OpenTD + ResourceGUIM8.pagada + ResourceGUIM8.CloseTD;
                        }
                        //Equals dos para factura "Anulada"
                        else if (theFactura.estatusFactura.Equals(2))
                        {
                            factura += ResourceGUIM8.OpenTD + ResourceGUIM8.anulada + ResourceGUIM8.CloseTD;
                        }


                        factura += ResourceGUIM8.OpenTD + theFactura.montoFactura + " $" + ResourceGUIM8.CloseTD;

                        //Acciones de cada contacto
                        factura += ResourceGUIM8.OpenTD;
                        factura += ResourceGUIM8.BotonModif + theFactura.idFactura + ResourceGUIM8.CloseBotonParametro +
                                   ResourceGUIM8.BotonInhab + theFactura.idFactura + ResourceGUIM8.CloseBotonParametro;
                        

                        factura += ResourceGUIM8.CloseTD;



                        /* factura += ResourceGUIM8.OpenTD + ResourceGUIM8.BotonInfo + ResourceGUIM8.BotonModif + 
                                    ResourceGUIM8.CloseTD;  */

                        factura += ResourceGUIM8.CloseTR;
                    }

                }
                catch (Exception ex)
                {

                }
            }

        }

        protected void busquedaNumero_Click(object sender, EventArgs e)
        {
            

        }
    }
}
