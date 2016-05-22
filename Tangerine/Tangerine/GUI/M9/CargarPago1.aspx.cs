using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine.M8;
using LogicaTangerine.M9;
using LogicaTangerine.M4;
using DominioTangerine;


namespace Tangerine.GUI.M9
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        LogicaM9 logica = new LogicaM9();

        public string cliente
        {
            get
            {
                return this.seccion1.Text;
            }

            set
            {
                this.seccion1.Text = value;
            }
        }

        public string numero
        {
            get
            {
                return this.seccion4.Text;
            }

            set
            {
                this.seccion4.Text = value;
            }
        }


        public string proyecto
        {
            get
            {
                return this.seccion2.Text;
            }

            set
            {
                this.seccion2.Text = value;
            }
        }

        public string monto
        {
            get
            {
                return this.seccion3.Text;
            }

            set
            {
                this.seccion3.Text = value;
            }
        }


        public void llenarTablaPorID(int numeroFactura)
        {
            LogicaM8 consulta = new LogicaM8();

            Facturacion Factura = consulta.SearchFactura(numeroFactura);

            try
            {
                Compania compania = consulta.SearchCompaniaFactura(int.Parse(Factura.idCompaniaFactura.ToString()));
                cliente += ResourceLogicaM9.AbrirNombreCliente + compania.NombreCompania + ResourceLogicaM9.CerrarNombreCliente;
                proyecto += ResourceLogicaM9.AbrirNombreCliente + Factura.descripcionFactura + ResourceLogicaM9.CerrarNombreCliente;
                monto += ResourceLogicaM9.AbrirNombreCliente + Factura.montoFactura + " " + Factura.tipoMoneda + ResourceLogicaM9.CerrarNombreCliente;
                numero += ResourceLogicaM9.AbrirNombreCliente + Factura.idFactura + ResourceLogicaM9.CerrarNombreCliente;
            }
            catch
            {

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int identificador = int.Parse(Request.QueryString["id"]);
            llenarTablaPorID(identificador);

        }

        protected void btnagregar_Click(object sender, EventArgs e)
        {
            //int _idFactura = int.Parse(seccion4.ToString());
            int _monto = int.Parse(seccion3.ToString());
            string _forma =  seccion5.Value;
            int _codApro = int.Parse(codAprobacion.Value);
            string _fecha = "01/08/2008";
            DateTime _dt = Convert.ToDateTime(_fecha);

            Pago pago = new Pago(_monto,_forma,_codApro,_dt,1);

            logica.AgregarPago(pago);

           // Compania company = new Compania(_nombre, _rif, _email, _telefono, _acronimo, DateTime.Parse(_fecha),
             //                                   _status, _presupuesto, _plazo, _direccionId);
            //logica.AddNewCompany(company);

            Server.Transfer("SeleccionCompania.aspx", true);
        }

    }
}