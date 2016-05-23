using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M3;

namespace Tangerine.GUI.M3
{
    public partial class Promover : System.Web.UI.Page
    {
        public string Name
        {
            get
            {
                return this.Nombre.Text;
            }

            set
            {
                this.Nombre.Text = value;
            }
        }

        public string RIF
        {
            get
            {
                return this.Rif.Text;
            }

            set
            {
                this.Rif.Text = value;
            }
        }

        public string Correo
        {
            get
            {
                return this.correo.Text;
            }

            set
            {
                this.correo.Text = value;
            }
        }

        public string Status
        {
            get
            {
                return this.status.ToString();
            }

            set
            {
                this.status.Text = value;
            }
        }

        public string Presupuesto
        {
            get
            {
                return this.presupuesto.ToString();
            }

            set
            {
                this.presupuesto.Text = value;
            }
        }

        public string Llamadas
        {
            get
            {
                return this.llamadas.ToString();
            }

            set
            {
                this.llamadas.Text = value;
            }
        }
        public string Visitas
        {
            get
            {
                return this.visitas.ToString();
            }

            set
            {
                this.visitas.Text = value;
            }


        }




        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaM3 prueba = new LogicaM3();
            int idClientePotencial = int.Parse(Request.QueryString["idclp"]);
            if (!IsPostBack)
            {
                ClientePotencial elClientePotencial = prueba.BuscarClientePotencial(idClientePotencial);

                try
                {


                    Name = elClientePotencial.NombreClientePotencial;
                    RIF = elClientePotencial.RifClientePotencial;
                    Correo = elClientePotencial.EmailClientePotencial;
                    Presupuesto = elClientePotencial.PresupuestoAnual_inversion.ToString();
                    Llamadas = elClientePotencial.NumeroLlamadas.ToString();
                    Visitas = elClientePotencial.NumeroVisitas.ToString();
                    if (elClientePotencial.Status == 0)
                    {
                        Status = ResourceInterfaz.Inactivo + ResourceInterfaz.CloseSpanInact;

                    }
                    if (elClientePotencial.Status == 1)
                    {
                        Status = ResourceInterfaz.Activo + ResourceInterfaz.CloseSpanAct;
                    }
                    if (elClientePotencial.Status == 2)
                    {
                        Status = ResourceInterfaz.Promovido + ResourceInterfaz.CloseSpanProm;
                    }



                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void Promover_Click(object sender, EventArgs e)
        {
            //Cuidado , recordar cambiar luego del this , el id que tenga la interfaz 

            // String nombre = this.idnombre.Value;
            // int id = Int32.Parse(Request.QueryString["idEmp"]);
            int idClip = int.Parse(Request.QueryString["idclp"]);

            //LogicaEmpleado logica = new LogicaEmpleado();
            LogicaM3 logica = new LogicaM3();

            logica.PromoverclientePotencial(logica.BuscarClientePotencial(idClip));
            Response.Redirect("Listar.aspx");

        }
    }
}