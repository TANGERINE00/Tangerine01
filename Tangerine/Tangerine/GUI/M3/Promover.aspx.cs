using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M3;
using Tangerine_Contratos.M3;
using Tangerine_Presentador.M3;

namespace Tangerine.GUI.M3
{
    public partial class Promover : System.Web.UI.Page, IContratoConsultarClientePotencial
    {
        PresentadorConsultarClientePotencial presentadorMostrar;
        PresentadorPromoverClientePotencial presentadorPromover;
        int idClientePotencial;

        public Promover()
        {
            this.presentadorMostrar = new PresentadorConsultarClientePotencial(this);
            this.presentadorPromover = new PresentadorPromoverClientePotencial(this);
        }

        #region Contrato
        public Literal NombreEtiqueta
        {
            get
            {
                return this.Nombre;
            }

            set
            {
                this.Nombre = value;
            }
        }

        public Literal RIFEtiqueta
        {
            get
            {
                return this.Rif;
            }

            set
            {
                this.Rif = value;
            }
        }

        public Literal CorreoEtiqueta
        {
            get
            {
                return this.correo;
            }

            set
            {
                this.correo = value;
            }
        }

        public Literal EstatusEtiqueta
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }

        public Literal PresupuestoInicialEtiqueta
        {
            get
            {
                return this.presupuesto;
            }

            set
            {
                this.presupuesto = value;
            }
        }

        public Literal NumLlamadasEtiqueta
        {
            get
            {
                return this.llamadas;
            }

            set
            {
                this.llamadas = value;
            }
        }
        public Literal NumVisitasEtiqueta
        {
            get
            {
                return this.visitas;
            }

            set
            {
                this.visitas = value;
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            idClientePotencial = int.Parse(Request.QueryString["idclp"]);
            if (!IsPostBack)
            {
                presentadorMostrar.Llenar(idClientePotencial);
            }
            //LogicaM3 prueba = new LogicaM3();
            //int idClientePotencial = int.Parse(Request.QueryString["idclp"]);
            //if (!IsPostBack)
            //{
            //    //ClientePotencial elClientePotencial = prueba.BuscarClientePotencial(idClientePotencial);

            //    try
            //    {


            //        Name = elClientePotencial.NombreClientePotencial;
            //        RIF = elClientePotencial.RifClientePotencial;
            //        Correo = elClientePotencial.EmailClientePotencial;
            //        Presupuesto = elClientePotencial.PresupuestoAnual_inversion.ToString();
            //        Llamadas = elClientePotencial.NumeroLlamadas.ToString();
            //        Visitas = elClientePotencial.NumeroVisitas.ToString();
            //        if (elClientePotencial.Status == 0)
            //        {
            //            Status = ResourceInterfaz.Inactivo + ResourceInterfaz.CloseSpanInact;

            //        }
            //        if (elClientePotencial.Status == 1)
            //        {
            //            Status = ResourceInterfaz.Activo + ResourceInterfaz.CloseSpanAct;
            //        }
            //        if (elClientePotencial.Status == 2)
            //        {
            //            Status = ResourceInterfaz.Promovido + ResourceInterfaz.CloseSpanProm;
            //        }



            //    }
            //    catch (Exception ex)
            //    {

            //    }

            //}
        }

        protected void Promover_Click(object sender, EventArgs e)
        {
            //Cuidado , recordar cambiar luego del this , el id que tenga la interfaz 

            // String nombre = this.idnombre.Value;
            // int id = Int32.Parse(Request.QueryString["idEmp"]);
            ////int idClip = int.Parse(Request.QueryString["idclp"]);

            //LogicaEmpleado logica = new LogicaEmpleado();
            ////LogicaM3 logica = new LogicaM3();

            //logica.PromoverclientePotencial(logica.BuscarClientePotencial(idClip));
            presentadorPromover.Promover(idClientePotencial);
            Response.Redirect("Listar.aspx");

        }
    }
}