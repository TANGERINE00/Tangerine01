using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine.M7;
using LogicaTangerine.M5;
using Tangerine_Presentador.M7;
using Tangerine_Contratos.M7;
using LogicaTangerine.M10;


namespace Tangerine.GUI.M7
{
    public partial class modificarProyecto : System.Web.UI.Page, IContratoModificarProyecto
    {

        PresentadorModificarProyecto presentador;

        public modificarProyecto()
        {
            this.presentador = new PresentadorModificarProyecto(this);
        }

        #region Contrato

        TextBox IContratoModificarProyecto.inputPropuesta
        {
            get
            {
                return inputPropuesta;
            }
            set
            {
                inputPropuesta = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputNombreProyecto
        {
            get
            {
                return textInputNombreProyecto;
            }
            set
            {
                textInputNombreProyecto = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputCodigo
        {
            get
            {
                return textInputCodigo;
            }
            set
            {
                textInputCodigo = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputFechaInicio
        {
            get
            {
                return textInputFechaInicio;
            }
            set
            {
                textInputFechaInicio = value;
            }
        }

        Calendar IContratoModificarProyecto.textInputFechaEstimada
        {
            get
            {
                return textInputFechaEstimada; ;
            }
            set
            {
                textInputFechaEstimada = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputCosto
        {
            get
            {
                return textInputCosto;
            }
            set
            {
                textInputCosto = value;
            }
        }

        TextBox IContratoModificarProyecto.textInputPorcentaje
        {
            get
            {
                return textInputPorcentaje;
            }
            set
            {
                textInputPorcentaje = value;
            }
        }

        DropDownList IContratoModificarProyecto.inputGerente
        {
            get
            {
                return inputGerente;
            }
            set
            {
                inputGerente = value;
            }
        }

        DropDownList IContratoModificarProyecto.inputEstatus
        {
            get 
            {
                return inputEstatus;
            }
            set
            {
                inputEstatus = value;
            }
        }

        TextBox IContratoModificarProyecto.text10
        {
            get
            {
                return text10;
            }
            set
            {
                text10 = value;
            }
        }

        ListBox IContratoModificarProyecto.imputEncargado
        {
            get
            {
                return inputEncargado;
            }
            set
            {
                inputEncargado = value;
            }
        }

        ListBox IContratoModificarProyecto.inputPersonal
        {
            get
            {
                return inputPersonal;
            }
            set
            {
                inputPersonal = value;
            }
        }

        TextBox IContratoModificarProyecto.idPropuesta
        {
            get
            {
                return idPropuesta;
            }
            set
            {
                idPropuesta = value;
            }
        }

        TextBox IContratoModificarProyecto.idProyecto
        {
            get
            {
                return idProyecto;
            }
            set
            {
                idProyecto = value;
            }
       }

        ListBox IContratoModificarProyecto.GerentesPasados
        {
            get
            {
                return GerentesPasados;
            }
            set
            {
                GerentesPasados = value;
            }
        }

        ListBox IContratoModificarProyecto.inputPersonalNoActivo
        {
            get
            {
                return inputPersonalNoActivo;
            }
            set
            {
                inputPersonalNoActivo = value;
            }
        }

        TextBox IContratoModificarProyecto.acuerdoPago
        {
            get
            {
                return acuerdoPago;
            }
            set
            {
                acuerdoPago = value;

            }
        }

        TextBox IContratoModificarProyecto.idCompania
        {
            get
            {
                return idCompania;
            }
            set
            {
                idCompania = value;
            }
        }

        TextBox IContratoModificarProyecto.descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                descripcion = value;
            }
        }

        public string alerta
        {
            set { alert.InnerHtml = value; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int Proyectoid = int.Parse(Request.QueryString["idCont"]);

            if (!IsPostBack)
            {
                presentador.CargarProyecto(Proyectoid);
            }
        }

        protected void Modificar_Datos(object sender, EventArgs e)
        {
            bool resultado = presentador.EventoClick_Modificar();
            if (resultado.Equals(true))
            {
                //Response.Redirect(M10_RecursosInterfaz.ListaAsistenciaModificada);
            }
            else if (resultado.Equals(false))
            {
                //Response.Redirect(M10_RecursosInterfaz.ListaAsistenciaNoModificada);
            }
        }

        protected void bIzquierdo_Click(object sender, EventArgs e)
        {
            presentador.MoverIzquierda();
        }

        protected void bDerecho_Click(object sender, EventArgs e)
        {
            presentador.MoverDerecha();
        }

    }
}