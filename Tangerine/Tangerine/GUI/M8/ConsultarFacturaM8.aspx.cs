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

        /// <summary>
        /// Metodo para llenar la tabla de consulta con todos los registro de factura de la base de datos
        /// </summary>
        public void llenarTabla()
        {

            //LogicaM8 prueba = new LogicaM8();
            LogicaM4 pruebaM4 = new LogicaM4();
            //List<Facturacion> listFactura = prueba.getFacturas();
            bool pagada = false;
            bool anulada = false;

            try
            {
                //foreach (Facturacion theFactura in listFactura)
                //{
                //    factura += ResourceGUIM8.OpenTR;

                //    factura += ResourceGUIM8.OpenTD + theFactura.idFactura.ToString() + ResourceGUIM8.CloseTD;
                //    Compania compania = prueba.SearchCompaniaFactura(int.Parse(theFactura.idCompaniaFactura.ToString()));
                //    factura += ResourceGUIM8.OpenTD + compania.NombreCompania.ToString() + ResourceGUIM8.CloseTD;
                //    Proyecto proyecto = prueba.SearchProyectoFactura(int.Parse(theFactura.idProyectoFactura.ToString()));
                //    factura += ResourceGUIM8.OpenTD + proyecto.Nombre.ToString() + ResourceGUIM8.CloseTD;
                //    factura += ResourceGUIM8.OpenTD + theFactura.descripcionFactura.ToString() + ResourceGUIM8.CloseTD;
                //    factura += ResourceGUIM8.OpenTD + theFactura.fechaFactura.ToString("dd/MM/yyyy") + ResourceGUIM8.CloseTD;

                //    //Equals cero para factura "Por Pagar"
                //    if (theFactura.estatusFactura.Equals(0))
                //    {
                //        factura += ResourceGUIM8.OpenTD + ResourceGUIM8.porPagar + ResourceGUIM8.CloseTD;

                //    }
                //    //Equals uno para factura "Pagada"
                //    else if (theFactura.estatusFactura.Equals(1))
                //    {
                //        pagada = true;
                //        factura += ResourceGUIM8.OpenTD + ResourceGUIM8.pagada + ResourceGUIM8.CloseTD;
                //    }
                //    //Equals dos para factura "Anulada"
                //    else if (theFactura.estatusFactura.Equals(2))
                //    {
                //        anulada = true;
                //        factura += ResourceGUIM8.OpenTD + ResourceGUIM8.anulada + ResourceGUIM8.CloseTD;
                //    }


                //    factura += ResourceGUIM8.OpenTD + theFactura.montoFactura + " "+ theFactura.tipoMoneda + ResourceGUIM8.CloseTD;

                //    //Acciones de cada contacto
                //    factura += ResourceGUIM8.OpenTD;

                //    if (pagada == true || anulada == true)
                //    {
                //        factura += ResourceGUIM8.BotonModifInhabilitado + theFactura.idFactura + ResourceGUIM8.CloseBotonParametro +
                //                   ResourceGUIM8.BotonAnularInhabilitado + theFactura.idFactura + ResourceGUIM8.CloseBotonParametro +
                //                   ResourceGUIM8.BotonPagarInhabilitado + theFactura.idFactura + ResourceGUIM8.CloseBotonParametro +
                //                    ResourceGUIM8.BotonMail + theFactura.idCompaniaFactura + ResourceGUIM8.CloseBotonParametro;

                //        factura += ResourceGUIM8.CloseTD;
                //        factura += ResourceGUIM8.CloseTR;
                //    }
                //    else
                //    {
                //        factura += ResourceGUIM8.BotonModif + theFactura.idFactura + ResourceGUIM8.CloseBotonParametro +
                //                ResourceGUIM8.BotonAnular + theFactura.idFactura + ResourceGUIM8.CloseBotonParametro +
                //                ResourceGUIM8.BotonPagar + theFactura.idFactura + ResourceGUIM8.CloseBotonParametro +
                //                ResourceGUIM8.BotonMail + theFactura.idCompaniaFactura + ResourceGUIM8.CloseBotonParametro;
                       
                //        factura += ResourceGUIM8.CloseTD;
                //        factura += ResourceGUIM8.CloseTR;
                //    }
                //    anulada = false;
                //    pagada = false;
                //}

            }
            catch (Exception ex)
            {

            }

        }

        /// <summary>
        /// Metodo para llenar la tabla de consulta a traves de la busqueda individual de factura de la base de datos
        /// </summary>
        /// <param name="numeroFactura"></param>
        public void llenarTablaPorID(int numeroFactura)
        {
            //LogicaM8 consulta = new LogicaM8();
            textBuscarId.Value = null;
            bool pagada = false;
            bool anulada = false;

            //Facturacion Factura = consulta.SearchFactura(numeroFactura);

            try
            {
                //factura += ResourceGUIM8.OpenTR;

                //factura += ResourceGUIM8.OpenTD + Factura.idFactura.ToString() + ResourceGUIM8.CloseTD;
                //Compania compania = consulta.SearchCompaniaFactura(int.Parse(Factura.idCompaniaFactura.ToString()));
                //factura += ResourceGUIM8.OpenTD + compania.NombreCompania.ToString() + ResourceGUIM8.CloseTD;
                //Proyecto proyecto = consulta.SearchProyectoFactura(int.Parse(Factura.idProyectoFactura.ToString()));
                //factura += ResourceGUIM8.OpenTD + proyecto.Nombre.ToString() + ResourceGUIM8.CloseTD;
                //factura += ResourceGUIM8.OpenTD + Factura.descripcionFactura.ToString() + ResourceGUIM8.CloseTD;
                //factura += ResourceGUIM8.OpenTD + Factura.fechaFactura.ToString("dd/MM/yyyy") + ResourceGUIM8.CloseTD;

                ////Equals cero para factura "Por Pagar"
                //if (Factura.estatusFactura.Equals(0))
                //{
                //    factura += ResourceGUIM8.OpenTD + ResourceGUIM8.porPagar + ResourceGUIM8.CloseTD;
                //}
                ////Equals uno para factura "Pagada"
                //else if (Factura.estatusFactura.Equals(1))
                //{
                //    pagada = true;
                //    factura += ResourceGUIM8.OpenTD + ResourceGUIM8.pagada + ResourceGUIM8.CloseTD;
                //}
                ////Equals dos para factura "Anulada"
                //else if (Factura.estatusFactura.Equals(2))
                //{
                //    anulada = true;
                //    factura += ResourceGUIM8.OpenTD + ResourceGUIM8.anulada + ResourceGUIM8.CloseTD;
                //}

                //factura += ResourceGUIM8.OpenTD + Factura.montoFactura + " " + Factura.tipoMoneda + ResourceGUIM8.CloseTD;

                //factura += ResourceGUIM8.OpenTD;
                ////Acciones de cada contacto

                //if (pagada == true || anulada == true)
                //{
                //    factura += ResourceGUIM8.BotonModifInhabilitado + Factura.idFactura + ResourceGUIM8.CloseBotonParametro +
                //               ResourceGUIM8.BotonAnularInhabilitado + Factura.idFactura + ResourceGUIM8.CloseBotonParametro +
                //               ResourceGUIM8.BotonPagarInhabilitado + Factura.idFactura + ResourceGUIM8.CloseBotonParametro +
                //               ResourceGUIM8.BotonMail + Factura.idCompaniaFactura + ResourceGUIM8.CloseBotonParametro;

                //    factura += ResourceGUIM8.CloseTD;
                //    factura += ResourceGUIM8.CloseTR;
                //}
                //else
                //{
                //    factura += ResourceGUIM8.BotonModif + Factura.idFactura + ResourceGUIM8.CloseBotonParametro +
                //            ResourceGUIM8.BotonAnular + Factura.idFactura + ResourceGUIM8.CloseBotonParametro +
                //            ResourceGUIM8.BotonPagar + Factura.idFactura + ResourceGUIM8.CloseBotonParametro +
                //            ResourceGUIM8.BotonMail + Factura.idCompaniaFactura + ResourceGUIM8.CloseBotonParametro;

                //    factura += ResourceGUIM8.CloseTD;
                //    factura += ResourceGUIM8.CloseTR;
                //}
                //anulada = false;
                //pagada = false;

            }
            catch (Exception ex)
            {

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    llenarTabla();
                }
                catch (Exception ex)
                {

                }
            }

        }

        /// <summary>
        /// Evento del boton de buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void busquedaNumero_Click(object sender, EventArgs e)
        {

            Boolean resultado = textBuscarId.Value.Equals("");

            if (resultado)
            {

                tabla.Text = null; //Aqui se limpia la tabla
                try
                {
                    llenarTabla();
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                tabla.Text = null; //Aqui se limpia la tabla
                int numeroFactura = int.Parse(textBuscarId.Value);
                try
                {
                    llenarTablaPorID(numeroFactura);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
