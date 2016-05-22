using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using DatosTangerine.M8;
using LogicaTangerine.M8;


namespace Tangerine.GUI.M8
{
    public partial class AnularFacturaM8 : System.Web.UI.Page
    {
        int _numeroFactura = 0;
        DateTime _fechaEmision = DateTime.Now;
        DateTime _fechaUltimoPago = DateTime.Now;
        int _montoTotal = 0;
        int _montoRestante = 0;
        string _tipoMoneda = String.Empty;
        string _descripcion = String.Empty;
        int _estatus = 0;
        int _proyectoId = 0;
        int _companiaId = 0;
        public static Facturacion theFactura = null;


        public string Numero
        {
            get
            {
                return this.NumeroFactura.Text;
            }

            set
            {
                this.NumeroFactura.Text = value;
            }
        }

        public string FechaFactura
        {
            get
            {
                return this.Fecha.Text;
            }

            set
            {
                this.Fecha.Text = value;
            }
        }

        public string CompaniaFactura
        {
            get
            {
                return this.Compania.Text;
            }

            set
            {
                this.Compania.Text = value;
            }
        }

        public string DescripcionFactura
        {
            get
            {
                return this.Descripcion.Text;
            }

            set
            {
                this.Descripcion.Text = value;
            }
        }

        public string ProyectoFactura
        {
            get
            {
                return this.Proyecto.Text;
            }

            set
            {
                this.Proyecto.Text = value;
            }
        }

        public string MontoFactura
        {
            get
            {
                return this.Monto.Text;
            }

            set
            {
                this.Monto.Text = value;
            }
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            int idFac = int.Parse(Request.QueryString["idFac"]);
            if (!IsPostBack)
            {
                LogicaM8 facturaLogic = new LogicaM8();
                theFactura = facturaLogic.SearchFactura(idFac);

                Numero = theFactura.idFactura.ToString();
                //this.textNumeroFactura_M8.Value = theFactura.idFactura.ToString();
                FechaFactura = theFactura.fechaFactura.ToString("dd/MM/yyyy");
                //this.textFecha_M8.Value = theFactura.fechaFactura.ToString("dd/MM/yyyy");
                DescripcionFactura = theFactura.descripcionFactura;
                //this.textDescripcion_M8.Value = theFactura.descripcionFactura;
                Compania compania = facturaLogic.SearchCompaniaFactura(int.Parse(theFactura.idCompaniaFactura.ToString()));
                CompaniaFactura = compania.NombreCompania;
                //this.textCliente_M8.Value = compania.NombreCompania;
                Proyecto proyecto = facturaLogic.SearchProyectoFactura(int.Parse(theFactura.idProyectoFactura.ToString()));
                ProyectoFactura = proyecto.Nombre;
                //this.textProyecto_M8.Value = proyecto.Nombre;
                MontoFactura = theFactura.montoFactura.ToString();
                //this.textMonto_M8.Value = theFactura.montoFactura.ToString();
                //this._montoRestante.Value = theFactura.montoRestanteFactura.ToString();
            }  
        }

        protected void buttonAnularFactura_Click(object sender, EventArgs e)
        {
            _numeroFactura = int.Parse(Numero);
            _montoTotal = int.Parse(MontoFactura);
            _fechaEmision = DateTime.Parse(FechaFactura);
            _fechaUltimoPago = DateTime.Now;
            _montoRestante = int.Parse(MontoFactura);
            _tipoMoneda = "Bolivares";
            _descripcion = DescripcionFactura;



            theFactura = new Facturacion(_numeroFactura, _fechaEmision, _fechaUltimoPago, _montoTotal, _montoRestante, _tipoMoneda, _descripcion, 0, 1, 1);
            LogicaM8 facturaLogic = new LogicaM8();
            facturaLogic.AnnularFactura(theFactura);
            Server.Transfer("ConsultarFacturaM8.aspx");
        }
    }
}