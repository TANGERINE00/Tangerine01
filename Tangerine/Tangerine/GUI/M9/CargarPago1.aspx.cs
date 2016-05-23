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
        #region Atributos
        LogicaM9 logica = new LogicaM9();

        public string cliente
        {
            get
            {
                return this.seccion1.Value;
            }

            set
            {
                this.seccion1.Value = value;
            }
        }

        public string numero
        {
            get
            {
                return this.seccion4.Value;
            }

            set
            {
                this.seccion4.Value = value;
            }
        }


        public string proyecto
        {
            get
            {
                return this.seccion2.Value;
            }

            set
            {
                this.seccion2.Value = value;
            }
        }

        public string monto
        {
            get
            {
                return this.seccion3.Value;
            }

            set
            {
                this.seccion3.Value = value;
            }
        }

        public string moneda
        {
            get
            {
                return this.monedaPago.Value;
            }

            set
            {
                this.monedaPago.Value = value;
            }
        }
        #endregion


        /// <summary>
        /// Metodo de carga la tabla de la ventana.
        /// </summary>
        /// recibe un solo parametro, id de la factura para consultar los detalles asociados, este parametro se recibe via URL
        /// <param name="id">Entero, representa el id de factura</param>
    
        public void llenarTablaPorID(int numeroFactura)
        {
            LogicaM8 consulta = new LogicaM8();

            Facturacion Factura = consulta.SearchFactura(numeroFactura);

            try
            {
                Compania compania = consulta.SearchCompaniaFactura(int.Parse(Factura.idCompaniaFactura.ToString()));
                cliente = compania.NombreCompania;
                proyecto = Factura.descripcionFactura ;
                monto = Factura.montoFactura.ToString() ;
                moneda = Factura.tipoMoneda;
                numero = Factura.idFactura.ToString() ;
            }
            catch
            {

            }
        }

        /// <summary>
        /// Metodo de carga de los elementos de la ventana.
        /// </summary>
        /// recibe un solo parametro, id de la compania para consultar todas las facturas asociadas, este parametro se recibe via URL
        /// recibe un solo parametro, id de la factura para consultar los detalles asociados, este parametro se recibe via URL

        protected void Page_Load(object sender, EventArgs e)
        {
            int identificador = int.Parse(Request.QueryString["id"]);
            llenarTablaPorID(identificador);

        }

        /// <summary>
        /// Metodo para tomar los valores de la vista y guardarlos en BD luego de apretar el boton agregar.
        protected void btnagregar_Click(object sender, EventArgs e)
        {
            int _idFactura = int.Parse(seccion4.Value.ToString());
            int _monto = int.Parse(seccion3.Value.ToString());
            string _moneda = monedaPago.Value.ToString();
            string _forma =  seccion5.Value.ToString();
            int _codApro = int.Parse(codAprobacion.Value);
            string _fecha = "01/08/2008";

            Pago pago = new Pago(_moneda, _monto, _forma, _codApro, DateTime.Parse(_fecha), _idFactura);

            logica.AgregarPago(pago);
            //logica.CambiarStatusFactura(pago.idFactura, 1);
            //codAprobacion.Value = _idFactura.ToString();


            Server.Transfer("SeleccionCompania.aspx", true);
        }

    }
}