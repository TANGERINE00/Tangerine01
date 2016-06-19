using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M5;
using Tangerine_Presentador.M5;
using Tangerine_Contratos;

namespace Tangerine.GUI.M5
{
    public partial class AgregarContacto : System.Web.UI.Page, Tangerine_Contratos.M5.IContratoAgregarContacto
    {
        private PresentadorAgregarContacto presentador;

        public string botonVolver
        {
            get { return this.volver.Text; }
            set { this.volver.Text = value; }
        }

        public string input_nombre
        {
            get { return this.nombre.Value; }
            set { this.nombre.Value = value; }
        }

        public string input_apellido
        {
            get { return this.apellido.Value; }
            set { this.apellido.Value = value; }
        }

        public string input_correo
        {
            get { return this.correo.Value; }
            set { this.correo.Value = value; }
        }

        public string input_departamento
        {
            get { return this.departamento.Value; }
            set { this.departamento.Value = value; }
        }

        public string input_telefono
        {
            get { return this.telefono.Value; }
            set { this.telefono.Value = value; }
        }

        public string input_cargo
        {
            get { return this.cargo.Value; }
            set { this.cargo.Value = value; }
        }

        public int GetTypeComp
        {
            get { return int.Parse(Request.QueryString[ResourceGUIM5.typeComp]); }
        }

        public int GetIdComp
        {
            get { return int.Parse(Request.QueryString[ResourceGUIM5.idComp]); }
        }

        public string CargarBotonVolver(int typeComp, int idComp)
        {
            return this.botonVolver = ResourceGUIM5.BotonVolver + typeComp + ResourceGUIM5.BotonVolver2 + idComp
                + ResourceGUIM5.BotonVolver3;
        }

        public void BotonAceptar(int typeComp, int idComp)
        {
            Server.Transfer(ResourceGUIM5.hrefConsultarContacto + typeComp + ResourceGUIM5.BotonVolver2
                + idComp + ResourceGUIM5.BotonVolver4 + ResourceGUIM5.StatusAgregado);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            presentador = new PresentadorAgregarContacto(this);
            presentador.cargar_pagina();
        }

        public void btnaceptar_Click(object sender, EventArgs e)
        {
            presentador.BtnAceptarContrato();
            Response.Redirect("../M1/DashBoard.aspx");

        }
    }
}