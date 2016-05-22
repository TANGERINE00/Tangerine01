using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using DatosTangerine.M3;
using LogicaTangerine.M3;
using Tangerine.GUI.M3;








//--------------------------------------------------------------------------------

namespace Tangerine.GUI.M3
{
    public partial class Listar : System.Web.UI.Page
    {
        public string ClientePotencial
        {
            get
            {
                return this.Lista.Text;
            }

            set
            {
                this.Lista.Text = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            //page load es el metodo que se ejecuta automaticamente cuando se abre una pagina
            //crear una condicion de si no es PostBack
            //si entra por primera vez no se ejecuta este metodo sino se ejecuta 
            if (!IsPostBack)
            {
                //crear un objeto de la capa de logica
                LogicaM3 logicalistarClientePotencial = new LogicaM3();
                //crear una lista de clientes potenciales
                List<ClientePotencial> ListaClientepotencialLogica = new List<ClientePotencial>();
                // llena la lista de clientes potenciales creada
                ListaClientepotencialLogica = logicalistarClientePotencial.LogicalistarClientePotencial();
                //foreach es para recorrer listas y arreglos 
                llenar(ListaClientepotencialLogica); //el llamado al metodo
            }

        }



        public void llenar(List<ClientePotencial> list)
        { // metodo que se usa para recorrer la lista
            foreach (ClientePotencial item in list)
            {
               ClientePotencial += ResourceInterfaz.AbrirTR;
               ClientePotencial += ResourceInterfaz.AbrirTD + item.NombreClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
               ClientePotencial += ResourceInterfaz.AbrirTD + item.RifClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
               ClientePotencial += ResourceInterfaz.AbrirTD + item.EmailClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
               if (item.Status == 1)
               {
                   ClientePotencial += ResourceInterfaz.AbrirTD + ResourceInterfaz.Activo + item.IdClientePotencial +
                       ResourceInterfaz.CloseSpanAct + ResourceInterfaz.CerrarTD;
               }
               if (item.Status == 0)
               {
                   ClientePotencial += ResourceInterfaz.AbrirTD + ResourceInterfaz.Inactivo + item.IdClientePotencial +
                       ResourceInterfaz.CloseSpanInact + ResourceInterfaz.CerrarTD;
               }
                if (item.Status == 2)
                {
                    ClientePotencial += ResourceInterfaz.AbrirTD + ResourceInterfaz.Promovido + item.IdClientePotencial +
                        ResourceInterfaz.CloseSpanProm + ResourceInterfaz.CerrarTD;
                }

               ClientePotencial += ResourceInterfaz.AbrirTD + item.PresupuestoAnual_inversion.ToString() + 
               ResourceInterfaz.CerrarTD;

               ClientePotencial += ResourceInterfaz.AbrirTD + ResourceInterfaz.OpenDivRow + ResourceInterfaz.BotonInfo + item.IdClientePotencial +
                   ResourceInterfaz.BotonCerrar +
                   ResourceInterfaz.BotonModificar + item.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                   ResourceInterfaz.BotonEliminar + item.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                   ResourceInterfaz.BotonActiv + item.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                   ResourceInterfaz.BotonContacto + item.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                   ResourceInterfaz.BotonPromover + item.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                   ResourceInterfaz.CloseDiv + ResourceInterfaz.CerrarTD;

               ClientePotencial += ResourceInterfaz.CerrarTR;
 


            }
        }
    }
}
  
 
