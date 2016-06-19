using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;

using LogicaTangerine.M3;


namespace Tangerine.GUI.M3
{
    public partial class ModificarLead : System.Web.UI.Page
    {
        string _nombre = String.Empty;
        string _rif = String.Empty;
       string _email = String.Empty;
       float _presupuesto = 0;
        int _llamadas = 0;
        int _visitas = 0;

        ClientePotencial elClientePotencial = null;
        protected void Page_Load(object sender, EventArgs e)
        {
             int idClip = int.Parse(Request.QueryString["idclp"]);
              if (!IsPostBack)
              {
                  LogicaM3 clientePotencialLogic = new LogicaM3();
                  elClientePotencial = clientePotencialLogic.BuscarClientePotencial(idClip);
                  //elClientePotencial = clientePotencialLogic.ModificarNuevoclientePotencial(idClip);

                // elClientePotencial = clientePotencialLogic.ModificarNuevoclientePotencial(elClientePotencial);


                  this.nombre.Value = elClientePotencial.NombreClientePotencial;
                  this.rif.Value = elClientePotencial.RifClientePotencial;
                  this.email.Value = elClientePotencial.EmailClientePotencial;

                  this.presupuesto.Value = elClientePotencial.PresupuestoAnual_inversion.ToString();
                  this.llamadas.Value = elClientePotencial.NumeroLlamadas.ToString();
                  this.visitas.Value = elClientePotencial.NumeroVisitas.ToString();
                      
              }
          }


        protected void Modificar_Click(object sender, EventArgs e)
        {
            //Cuidado , recordar cambiar luego del this , el id que tenga la interfaz 

            // String nombre = this.idnombre.Value;

            int idClip = int.Parse(Request.QueryString["idclp"]);


            String nombre = this.nombre.Value;
            String rif = this.rif.Value;
            String email = this.email.Value;

            float presupuesto = float.Parse(this.presupuesto.Value.ToString());
            int llamadas = int.Parse(this.llamadas.Value.ToString());
            int visitas = int.Parse(this.visitas.Value.ToString());
            ClientePotencial nuevoCliente = new ClientePotencial(idClip,nombre,rif,email,presupuesto,llamadas,visitas);

            LogicaM3 logica = new LogicaM3();
            //logica.ModificarNuevoclientePotencial(logica.BuscarClientePotencial(idClip));
            logica.ModificarNuevoclientePotencial( nuevoCliente );
            Response.Redirect("Listar.aspx");


           
   
        }
    
    
    
    
    }
    
}