using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M4;
using DatosTangerine.M4;

namespace Tangerine.GUI.M4
{
    public partial class HabilitarCompania : System.Web.UI.Page
    {
        LogicaM4 prueba = new LogicaM4();
      
       
        

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
        public string Siglas
        {
            get
            {
                return this.Acronimo.Text;
            }

            set
            {
                this.Acronimo.Text = value;
            }
        }
        public string Telefono
        {
            get
            {
                return this.telefono.Text;
            }

            set
            {
                this.telefono.Text = value;
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
        public string Direccion
        {
            get
            {
                return this.direccion.Text;
            }

            set
            {
                this.direccion.Text = value;
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
        public string Fecha
        {
            get
            {
                return this.fecha.ToString();
            }

            set
            {
                this.fecha.Text = value;
            }
        }
        public string Habilitado
        {
            get
            {
                return this.habilitado.ToString();
            }

            set
            {
                this.habilitado.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Compania company = new Compania();
          
            List<LugarDireccion> listaLugares = prueba.getPlaces();      

            try
            {
          
            }
            catch 
            {
            }
            company = prueba.SearchCompany(int.Parse(Request.QueryString["idComp"]));
  

     
            foreach (LugarDireccion lugar in listaLugares)
            {
                
            if (lugar.LugId.Equals(company.IdLugar))
                {
                
                    
                    Name= company.NombreCompania;
                    Siglas= company.AcronimoCompania;
                    Telefono= company.TelefonoCompania;
                    RIF= company.RifCompania;
                    Correo= company.EmailCompania;
                    Fecha= company.FechaRegistroCompania.ToShortDateString();
                    Direccion = lugar.LugNombre ;
                    if (company.StatusCompania == 1)
                    {
                        Habilitado = ResourceGUIM4.habilitado + ResourceGUIM4.CloseSpanHab;
                    }
                    if (company.StatusCompania == 0)
                    {
                        Habilitado = ResourceGUIM4.inhabilitado + ResourceGUIM4.CloseSpanInhab;
                    
                    }
                }
            
         } 


        
        }
    }
}