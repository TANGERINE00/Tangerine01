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
    public partial class AgregarPropuesta : System.Web.UI.Page, IContratoAgregarPropuesta
    {
        
        String[] _precondicion;
        PresentadorAgregarPropuesta presenter;

        public AgregarPropuesta()
        {
            presenter = new PresentadorAgregarPropuesta(this);
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                /*
                                llenarComboDuracion();
                                llenarComboTipoCosto();
                                llenarComboEstatus();
                                cargarCompañias();
                                llenarComboCuota();
                                llenarComboFpago();

                    */
            }


        }

        protected void btnagregar_Click(object sender, EventArgs e)
        {
            

 


            /*
            Propuesta propuesta = new Propuesta(_nombcodigoPropuesta, _descripcion, _Tipoduracion, _duracion, _acuerdo, _estatusW, _moneda,
                                                 _entregaCant, _fechaI, _fechaF, _costo, _idCompañia);
            LogicaPropuesta propuestaLogica = new LogicaPropuesta();
            propuestaLogica.agregar(propuesta);
          


            _precondicion = arrPrecondicion.Value.Split(';');

            for (int i = 0; i < _precondicion.Length - 1; i++)
            {
                int j = i + 1;
                string codReq = novocales + "_RF_" + j.ToString();
         //       Debug.Print(_precondicion[i]);

                Requerimiento requerimiento = new Requerimiento(codReq, _precondicion[i].ToString(), _nombcodigoPropuesta);
                LogicaRequerimiento requerimientoLogica = new LogicaRequerimiento();

                requerimientoLogica.agregar(requerimiento);

            }

              */

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
        private void cargarCompañias()
        {
            try
            {
                LogicaM4 logicaComp = new LogicaM4();
                List<Compania> companias = logicaComp.ConsultCompanies();
                ListItem itemCompa;

                this.comboCompañia.Items.Clear();
                itemCompa = new ListItem();
                itemCompa.Text = "Seleccione un Cliente";
                itemCompa.Value = "0";
                this.comboCompañia.Items.Add(itemCompa);

                foreach (Compania objetoCompa in companias)
                {
                    itemCompa = new ListItem();
                    itemCompa.Text = objetoCompa.NombreCompania;
                    itemCompa.Value = objetoCompa.IdCompania.ToString();

                    this.comboCompañia.Items.Add(itemCompa);
                }


            }
            catch (Exception e)
            {
                ///
            }

        }


        public string ComboCompania
        {
            get { return comboCompañia.SelectedItem.Text; }
            set { comboCompañia.Items.Add(value); }
        }
        public string IdCompania
        {
            get { return comboCompañia.SelectedIndex.ToString(); }
            set { }
        }
        public string Descripcion
        {
            get { return descripcion.Value; }
        }
        public string ArrPrecondicion
        {
            get { return arrPrecondicion.Value; }

        }
        public string ComboDuracion
        {
            get { return comboDuracion.SelectedItem.Text; }
            set { comboDuracion.Items.Add(value); }
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
        public string TipoCosto
        {
            get { return comboTipoCosto.SelectedItem.Text; }
            set { comboTipoCosto.Items.Add(value); }
        }

        public string TextoCosto
        {
            get { return textoCosto.Value; }
        }
        public string FormaPago
        {
            get { return formaPago.SelectedItem.Text; }
            set { formaPago.Items.Add(value); }
        }
        public string ComboCuota
        {
            get { return comboCuota.SelectedItem.Text; }
            set { comboCuota.Items.Add(value); }
        }
        public string ComboStatus
        {
            get { return comboEstatus.SelectedItem.Text; }
            set { comboEstatus.Items.Add(value); }
        }

    }
}