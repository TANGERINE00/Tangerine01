using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M6;
using System.Diagnostics;

namespace Tangerine.GUI.M6
{
    public partial class ModificarPropuesta : System.Web.UI.Page
    {

        public Propuesta Prueba; 


        protected void Page_Load(object sender, EventArgs e)
        {
            string prueba = Request.QueryString.Get("id");
            btn_Modifica(prueba);


            if (!IsPostBack)
            {
                llenarComboTipoCosto();
                llenarComboDuracion();
                llenarComboEstatus();
                
            }

            textoDuracion.Value = Prueba.CantDuracion;
            comboDuracion.SelectedValue = Prueba.TipoDuracion;
            comboTipoCosto.SelectedValue = Prueba.Moneda;
            textoCosto.Value = Prueba.Costo.ToString();
            comboEstatus.SelectedValue = Prueba.Estatus;

        }




        /// <summary>
        /// Metodo de la acción modificar de la vista de listar propuesta. 
        /// </summary>
        /// <param name="idPropuesta"></param>


        public void btn_Modifica(String idPropuesta)
        {

            LogicaPropuesta logicaPropuesta = new LogicaPropuesta();

            Prueba = logicaPropuesta.TraerPropuesta(idPropuesta);
           
        }






        /// <summary>
        /// Metodo para cargar el o los requerimientos asociados a la propuesta seleccionada en la pantalla de listar. 
        /// </summary>
        /// <param name="idPropuesta"></param>

        public void btn_ModificaReq(String idPropuesta) 
        {





        }











        /// <summary>
        /// Metodo para modificar la propuesta completa en BD.
        /// </summary>


        public void ModificarTotal() 
        {


        }


        public void llenarComboDuracion()
        {
            comboDuracion.Items.Add("Meses");
            comboDuracion.Items.Add("Dias");
            comboDuracion.Items.Add("Horas");
        }


        public void llenarComboTipoCosto()
        {
            comboTipoCosto.Items.Add("Bolivares");
            comboTipoCosto.Items.Add("Dolares");
            comboTipoCosto.Items.Add("Euros");
            comboTipoCosto.Items.Add("Bitcoins");
        }


        public void llenarComboEstatus()
        {
            comboEstatus.Items.Add("Pendiente");
            comboEstatus.Items.Add("Aprobado");
            comboEstatus.Items.Add("Cerrado");

        }



    }
}