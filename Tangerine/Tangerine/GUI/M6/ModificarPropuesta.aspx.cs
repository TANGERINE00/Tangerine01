using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M6;
using LogicaTangerine.M4;
using System.Diagnostics;

namespace Tangerine.GUI.M6
{
    public partial class ModificarPropuesta : System.Web.UI.Page
    {
        public string requerimiento
        {
            get
            {
                return this.tablaR.Text;
            }

            set
            {
                this.tablaR.Text = value;
            }
        }



        public Propuesta Prueba;
        LogicaM4 logicacompania = new LogicaM4();
        public List<Requerimiento> req;
        public bool modi;
        string prueba;


        protected void Page_Load(object sender, EventArgs e)
        {
            prueba = Request.QueryString.Get("id");

            btn_ConsultaP(prueba);
            btn_ConsultaReq(prueba);


            volver.Attributes.Add("href", "ConsultarPropuesta.aspx");



            if (!IsPostBack)
            {
                llenarComboTipoCosto();
                llenarComboDuracion();
                llenarComboEstatus();
                llenarComboCuota();
                llenarComboFpago();



                foreach (Requerimiento elRequerimiento in req)
                {
                    requerimiento += RecursosGUI_M6.AbrirTR;

                    requerimiento += RecursosGUI_M6.AbrirTD + elRequerimiento.CodigoRequerimiento.ToString() + RecursosGUI_M6.CerrarTD;
                    requerimiento += RecursosGUI_M6.AbrirTD + elRequerimiento.Descripcion.ToString() + RecursosGUI_M6.CerrarTD;


                    requerimiento += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.btn_Modificar + RecursosGUI_M6.CerrarTD;
                    requerimiento += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.btn_eliminar + RecursosGUI_M6.CerrarTD;

                    requerimiento += RecursosGUI_M6.CerrarTR;

                }

                descripcion.Value = Prueba.Descripcion;
                textoDuracion.Value = Prueba.CantDuracion;
                comboDuracion.SelectedValue = Prueba.TipoDuracion;
                comboTipoCosto.SelectedValue = Prueba.Moneda;
                textoCosto.Value = Prueba.Costo.ToString();
                comboEstatus.SelectedValue = Prueba.Estatus;
                datepicker1.Value = Prueba.Feincio.ToString("MM/dd/yyyy");
                datepicker2.Value = Prueba.Fefinal.ToString("MM/dd/yyyy");
                formaPago.SelectedValue = Prueba.Acuerdopago;
                comboCuota.SelectedValue = Prueba.Entrega.ToString();

            }

          

        }






        /// <summary>
        /// Metodo de la acción modificar de la vista de listar propuesta. 
        /// </summary>
        /// <param name="idPropuesta"></param>


        public void btn_ConsultaP(String idPropuesta)
        {

            LogicaPropuesta logicaPropuesta = new LogicaPropuesta();

            Prueba = logicaPropuesta.TraerPropuesta(idPropuesta);

            Compania lacompania = new Compania();

            lacompania = logicacompania.ConsultCompany(Int32.Parse(Prueba.IdCompañia));
            cliente_id.Value = lacompania.NombreCompania;

        }






        /// <summary>
        /// Metodo para cargar el o los requerimientos asociados a la propuesta seleccionada en la pantalla de listar. 
        /// </summary>
        /// <param name="idPropuesta"></param>

        public void btn_ConsultaReq(String idPropuesta)
        {

            LogicaRequerimiento logreq = new LogicaRequerimiento();

            req = logreq.TraerRequerimientoPropuesta(idPropuesta);

        }



        /// <summary>
        /// Metodo para modificar el requerimiento desde el modal
        /// </summary>
        /// <param name="idRequerimiento"></param>
        /// <param name="descripcion"></param>

        public void btn_ModReq(String idRequerimiento, String descripcion)
        {
            Requerimiento vistaReq = new Requerimiento();
            LogicaRequerimiento logica = new LogicaRequerimiento();
            vistaReq.Descripcion = descripcion;
            vistaReq.CodigoRequerimiento = idRequerimiento;
            modi = logica.ModRequerimiento(vistaReq);

        }




        public void llenarComboDuracion()
        {
            comboDuracion.Items.Add("Meses");
            comboDuracion.Items.Add("Dias");
            comboDuracion.Items.Add("Horas");
        }


        public void llenarComboTipoCosto()
        {
            comboTipoCosto.Items.Add("Bolivar");
            comboTipoCosto.Items.Add("Dolar");
            comboTipoCosto.Items.Add("Euro");
            comboTipoCosto.Items.Add("Bitcoin");
        }


        public void llenarComboEstatus()
        {
            comboEstatus.Items.Add("Pendiente");
            comboEstatus.Items.Add("Aprobado");
            comboEstatus.Items.Add("Cerrado");

        }

        public void llenarComboCuota()
        {
            comboCuota.Items.Add("");
            comboCuota.Items.Add("1");
            comboCuota.Items.Add("2");
            comboCuota.Items.Add("3");
            comboCuota.Items.Add("4");

        }

        public void llenarComboFpago()
        {
            formaPago.Items.Add("Mensual");
            formaPago.Items.Add("Por cuotas");


        }

        protected void botonModificarPro_Click(object sender, EventArgs e)
        {
            Propuesta propuestas = new Propuesta();

            propuestas.Nombre = prueba;
            propuestas.Descripcion = descripcion.Value;
            propuestas.TipoDuracion = comboDuracion.SelectedValue;
            propuestas.Acuerdopago = formaPago.SelectedValue;
            propuestas.CantDuracion = comboCuota.SelectedValue;
            propuestas.Estatus = comboEstatus.SelectedValue;
            propuestas.Moneda = comboTipoCosto.SelectedValue;
            propuestas.Feincio = DateTime.ParseExact(datepicker1.Value, "MM/dd/yyyy", null);
            propuestas.Fefinal = DateTime.ParseExact(datepicker2.Value, "MM/dd/yyyy", null);
            propuestas.Costo = int.Parse(textoCosto.Value);


            LogicaPropuesta propuesta = new LogicaPropuesta();
            propuesta.ModificarPropuesta(propuestas);
            Server.Transfer("ConsultarPropuesta.aspx", true);
        }

      



    }
}