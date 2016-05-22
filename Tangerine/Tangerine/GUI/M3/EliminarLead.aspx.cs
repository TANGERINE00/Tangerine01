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
    public partial class EliminarLead : System.Web.UI.Page
    {
        string _nombre = String.Empty;
        string _rif = String.Empty;
        string _email = String.Empty;
        float _presupuesto = 0;
        int _llamadas = 0;
        int _visitas = 0;
        string _potencial = String.Empty;
        string _borrado = String.Empty;
          ClientePotencial elClientePotencial = null;
          protected void Page_Load(object sender, EventArgs e)
          {


              int idClip = int.Parse(Request.QueryString["idclp"]);
              if (!IsPostBack)
              {
                  LogicaM3 clientePotencialLogic = new LogicaM3();
                  elClientePotencial = clientePotencialLogic.BuscarClientePotencial(idClip);

                  this.nombre.Value = elClientePotencial.NombreClientePotencial;
                  this.rif.Value = elClientePotencial.RifClientePotencial;
                  this.email.Value = elClientePotencial.EmailClientePotencial;
      
                  this.pres_anual.Value = elClientePotencial.PresupuestoAnual_inversion.ToString();
                  this.llamadas.Value = elClientePotencial.NumeroLlamadas.ToString();
                  this.visitas.Value = elClientePotencial.NumeroVisitas.ToString();
             

              }
          }
            
          
        protected void Eliminar_Click(object sender, EventArgs e)
        {
            //Cuidado , recordar cambiar luego del this , el id que tenga la interfaz 

            // String nombre = this.idnombre.Value;
           // int id = Int32.Parse(Request.QueryString["idEmp"]);
            int idClip = int.Parse(Request.QueryString["idclp"]);

            //LogicaEmpleado logica = new LogicaEmpleado();
            LogicaM3 logica = new LogicaM3();

            logica.BorrarNuevoclientePotencial(logica.BuscarClientePotencial(idClip));

        }
    }
}



