using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine.M3;
using DominioTangerine;

namespace Tangerine.GUI.M3
{
    public partial class ActivarLead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaM3 prueba = new LogicaM3();
            int idClientePotencial = int.Parse(Request.QueryString["idclp"]);
            if (!IsPostBack)
            {
                ClientePotencial elClientePotencial = prueba.BuscarClientePotencial(idClientePotencial);

                try
                {

                    this.nombre.Value = elClientePotencial.NombreClientePotencial;
                    this.rif.Value = elClientePotencial.RifClientePotencial;
                    this.email.Value = elClientePotencial.EmailClientePotencial;
                    this.pres_anual.Value = elClientePotencial.PresupuestoAnual_inversion.ToString();
                    this.llamadas.Value = elClientePotencial.NumeroLlamadas.ToString(); ;
                    this.visitas.Value = elClientePotencial.NumeroVisitas.ToString(); ;
                    // this.potencial.Value = elClientePotencial.Potencial;
                    //this.borrado.Value = elClientePotencial.Borrado;


                }
                catch (Exception ex)
                {

                }

            }
        }

        protected void Activar_Click(object sender, EventArgs e)
        {
            //Cuidado , recordar cambiar luego del this , el id que tenga la interfaz 

            // String nombre = this.idnombre.Value;
            // int id = Int32.Parse(Request.QueryString["idEmp"]);
            int idClip = int.Parse(Request.QueryString["idclp"]);

            //LogicaEmpleado logica = new LogicaEmpleado();
            LogicaM3 logica = new LogicaM3();

            logica.ActivarclientePotencial(logica.BuscarClientePotencial(idClip));

        }

    }
}