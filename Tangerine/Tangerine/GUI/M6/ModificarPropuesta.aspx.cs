using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M6;
using LogicaTangerine.M4;
using Tangerine_Contratos.M6;
using Tangerine_Presentador.M6;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace Tangerine.GUI.M6
{
    public partial class ModificarPropuesta : System.Web.UI.Page, IContratoModificarPropuesta
    {
     

        public Propuesta Prueba;
        LogicaM4 logicacompania = new LogicaM4();
        public List<Requerimiento> req;
        public bool modi;
        string company;

         PresentadorModificarPropuesta presenter;

        public ModificarPropuesta()
        {
            this.presenter = new PresentadorModificarPropuesta(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            company = Request.QueryString.Get("id");
            presenter.llenarVista();
       //     TraerCompania(company);
       //     
       //     btn_ConsultaReq(prueba);


          //  volver.Attributes.Add("href", "ConsultarPropuesta.aspx");


/*
            if (!IsPostBack)
            {

                foreach (Requerimiento elRequerimiento in req)
                {
                    requerimiento += RecursosGUI_M6.AbrirTR;

                    requerimiento += RecursosGUI_M6.AbrirTD + elRequerimiento.CodigoRequerimiento.ToString() + RecursosGUI_M6.CerrarTD;
                    requerimiento += RecursosGUI_M6.AbrirTD + elRequerimiento.Descripcion.ToString() + RecursosGUI_M6.CerrarTD;


                    requerimiento += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.btn_Modificar + RecursosGUI_M6.CerrarTD;
                    requerimiento += RecursosGUI_M6.AbrirTD + RecursosGUI_M6.btn_eliminar + RecursosGUI_M6.CerrarTD;

                    requerimiento += RecursosGUI_M6.CerrarTR;

                }
            }
 * */

          

        }






        /// <summary>
        /// Metodo de la acción modificar de la vista de listar propuesta. 
        /// </summary>
        /// <param name="idPropuesta"></param>


     /*   public void TraerCompania(String idPropuesta)
        {

            LogicaPropuesta logicaPropuesta = new LogicaPropuesta();

            Prueba = logicaPropuesta.TraerPropuesta(idPropuesta);

            Compania lacompania = new Compania();

            lacompania = logicacompania.ConsultCompany(Int32.Parse(Prueba.IdCompañia));
            cliente_id.Value = lacompania.NombreCompania;

        } */

        /// <summary>
        /// Metodo para cargar el o los requerimientos asociados a la propuesta seleccionada en la pantalla de listar. 
        /// </summary>
        /// <param name="idPropuesta"></param>

   /*     public void btn_ConsultaReq(String idPropuesta)
        {

            LogicaRequerimiento logreq = new LogicaRequerimiento();

            req = logreq.TraerRequerimientoPropuesta(idPropuesta);

        } */
        /// <summary>
        /// Metodo para modificar el requerimiento desde el modal
        /// </summary>
        /// <param name="idRequerimiento"></param>
        /// <param name="descripcion"></param>

        /*
        public void llenarReq(String idRequerimiento, String descripcion)
        {
            Requerimiento vistaReq = new Requerimiento();
            LogicaRequerimiento logica = new LogicaRequerimiento();
            vistaReq.Descripcion = descripcion;
            vistaReq.CodigoRequerimiento = idRequerimiento;
            modi = logica.ModRequerimiento(vistaReq);

        } */
        protected void botonModificarPro_Click(object sender, EventArgs e)
        {
           /* Propuesta propuestas = new Propuesta();

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

            */
            presenter.ModificarPropuesta();

            Server.Transfer("ConsultarPropuesta.aspx", true);   
        }

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


        public string ContenedorCompania
        {
            get { return cliente_id.Value; }
            set { cliente_id.Value = value;  }
        }

        public string IdCompania {
            get { return company; }
        }
        public string Descripcion
        {
            get { return descripcion.Value; }
            set { descripcion.Value = value; }

        }
        public string TablaR
        {
            get { return tablaR.Text;}
            set { tablaR.Text = value; }

        }
        public DropDownList ComboDuracion
        {
            get { return comboDuracion; }
            set { comboDuracion = value; }
        }
        public string TextoDuracion
        {
            get { return textoDuracion.Value; }

        }
        public string DatePickerUno
        {
            get { return datepicker1.Value; }
        }
        public string DatePickerDos
        {
            get { return datepicker2.Value; }
        }
        public DropDownList TipoCosto
        {
            get { return comboTipoCosto; }
            set { comboTipoCosto = value; }
        }

        public string TextoCosto
        {
            get { return textoCosto.Value; }
        }
        public DropDownList FormaPago
        {
            get { return formaPago; }
            set { formaPago = value; }
        }
        public DropDownList ComboCuota
        {
            get { return comboCuota; }
            set { comboCuota = value; }
        }
        public DropDownList ComboStatus
        {
            get { return comboEstatus; }
            set { comboEstatus = value; }
        }




    }
}