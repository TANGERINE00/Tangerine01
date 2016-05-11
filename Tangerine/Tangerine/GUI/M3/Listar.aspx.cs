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


/*
namespace Tangerine.GUI.M3
{
    public partial class Listar : System.Web.UI.Page

    {
        public string cliente
        {
            get
            {
                return this.tabla.Text;
            }
            set
            {
                this.tabla.Text = value;
            }
        }
     
        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaM3 prueba = new LogicaM3();
            //page load es el metodo que se ejecuta automaticamente cuando se abre una pagina
            //crear una condicion de si no es PostBack
            //si entra por primera vez no se ejecuta este metodo sino se ejecuta 
            if (!IsPostBack)
            {
               
                    //Aqui ejecuto el filltable de la clase creada en logica para probar la conexion a la bd
                    //los parametros son tipo de empresa 1 (Compania), id de la empresa 1.
                    //prueba.fillTable(1,1);
                  
       
                List<ClientePotencial> listCliente = new List<ClientePotencial>();

                    try
                    {
                        //foreach (Contacto theContact in listCliente)
                        foreach (ClientePotencial elCliente in listCliente)
                        {
                            cliente += ResourceInterfaz.AbrirTR;
                            cliente += ResourceInterfaz.AbrirTD + elCliente.IdClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                            cliente += ResourceInterfaz.AbrirTD + elCliente.NombreClientePotencial.ToString() + ResourceInterfaz.CerrarTD; ;
                            cliente += ResourceInterfaz.AbrirTD + elCliente.RifClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                            cliente += ResourceInterfaz.AbrirTD + elCliente.EmailClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                            cliente += ResourceInterfaz.AbrirTD + elCliente.PresupuestoAnual_inversion.ToString() + ResourceInterfaz.CerrarTD;
                            //Acciones de cada contacto
                            cliente += ResourceInterfaz.AbrirTD;



                              cliente += ResourceInterfaz.BotonInfo + elCliente.IdClientePotencial + ResourceInterfaz.BotonCerrar
                             + "<a style='margin-left:5px;'  class='btn btn-primary glyphicon glyphicon-search'></a>";
                          // + "<a style='margin-left:5px;' class='btn btn-danger glyphicon glyphicon-remove-circle'></a>";
                            

                            cliente += ResourceInterfaz.BotonModificar + elCliente.IdClientePotencial + ResourceInterfaz.BotonCerrar
                             + "<a style='margin-left:5px;'  class='btn btn-default glyphicon glyphicon-pencil'></a>";
                          // + "<a style='margin-left:5px;' class='btn btn-danger glyphicon glyphicon-remove-circle'></a>";
                            
                             cliente += ResourceInterfaz.BotonEliminar + elCliente.IdClientePotencial + ResourceInterfaz.BotonCerrar
                             + "<a style='margin-left:5px;'    class='btn btn-danger glyphicon glyphicon-trash'></a>";
                          // + "<a style='margin-left:5px;' class='btn btn-danger glyphicon glyphicon-remove-circle'></a>";
                                                 
                            
                            cliente += ResourceInterfaz.CerrarTD;
                            cliente += ResourceInterfaz.CerrarTR;



                                  

                        }
                    }
                    catch (Exception ex)
                    {

                    }
            }




        }



    }
}


*/






//--------------------------------------------------------------------------------

namespace Tangerine.GUI.M3
{
    public partial class Listar : System.Web.UI.Page
    {



        protected void Page_Load(object sender, EventArgs e)
        {

            //page load es el metodo que se ejecuta automaticamente cuando se abre una pagina
            //crear una condicion de si no es PostBack
            //si entra por primera vez no se ejecuta este metodo sino se ejecuta 
            if (!IsPostBack)
            {
                //crear un objeto de la capa de logica
                LogicaM3 logicalistarClientePotencial = new LogicaM3();
                //crear una lista de empleados 
                List<ClientePotencial> ListaClientepotencialLogica = new List<ClientePotencial>();
                // logica.listarEmpleado();
                ListaClientepotencialLogica = logicalistarClientePotencial.LogicalistarClientePotencial();
                //foreach es para recorrer listas y arreglos 
                llenar(ListaClientepotencialLogica); //el llamado al metodo
            }

        }





        public void llenar(List<ClientePotencial> list)
        { // metodo que se usa para recorrer la lista
            foreach (ClientePotencial item in list)
            {
                this.tabla.Text += ResourceInterfaz.AbrirTR;
                //this.tabla.Text += ResourceInterfaz.AbrirTD + item.IdClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                this.tabla.Text += ResourceInterfaz.AbrirTD + item.NombreClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                this.tabla.Text += ResourceInterfaz.AbrirTD + item.RifClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                this.tabla.Text += ResourceInterfaz.AbrirTD + item.EmailClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                this.tabla.Text += ResourceInterfaz.AbrirTD + item.PresupuestoAnual_inversion.ToString() + ResourceInterfaz.CerrarTD;
                this.tabla.Text += ResourceInterfaz.AbrirTD;
                this.tabla.Text += ResourceInterfaz.BotonInfo + item.IdClientePotencial + ResourceInterfaz.BotonCerrar;
                //this.tabla.Text += ResourceInterfaz.BotonEliminar + item.IdClientePotencial + ResourceInterfaz.BotonCerrar;
                this.tabla.Text += ResourceInterfaz.BotonModificar + item.IdClientePotencial + ResourceInterfaz.BotonCerrar;
                this.tabla.Text += ResourceInterfaz.CerrarTD;
                this.tabla.Text += ResourceInterfaz.CerrarTR;
            }




  

        }



    }
}
  
// */
