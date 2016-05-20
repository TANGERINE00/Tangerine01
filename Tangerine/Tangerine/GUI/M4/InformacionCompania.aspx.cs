using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M4;

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
        protected void Page_Load(object sender, EventArgs e)
        {
           Compania company = new Compania();
           int idComp=0;
            try
            {
                idComp =int.Parse(Request.QueryString["idComp"]);
            }
            catch 
            {
            }
            
            company = prueba.SearchCompany(2);
            Name= company.NombreCompania;
            Siglas= company.AcronimoCompania;
            Telefono= company.TelefonoCompania;
            RIF= company.RifCompania;
            Correo= company.EmailCompania;
            Fecha= company.FechaRegistroCompania.ToString();
            Direccion = company.IdLugar.ToString();
        
        
        }
    }
}