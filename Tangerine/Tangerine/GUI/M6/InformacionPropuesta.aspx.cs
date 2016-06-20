﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M6;
using LogicaTangerine.M4;
using Tangerine_Contratos.M6;
using Tangerine_Presentador.M6;
using System.Diagnostics;

namespace Tangerine.GUI.M6
{
    public partial class InformacionPropuesta : System.Web.UI.Page, IContratoInformacionPropuesta
    {
        PresentadorInformacionPropuesta presentadorInformacion;

        public InformacionPropuesta()
        {
            this.presentadorInformacion = new PresentadorInformacionPropuesta(this);
        }

        
        public Label Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            if (!IsPostBack)
            {
                presentadorInformacion.consultarPropuesta(id);
            }
        }
    }
}