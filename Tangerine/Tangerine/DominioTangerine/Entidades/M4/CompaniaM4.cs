using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M4
{
    public class CompaniaM4 :  Entidad
    {
        #region Atributos
        private string nombreCompania;
        private string rifCompania;
        private string emailCompania;
        private string telefonoCompania;
        private string acronimoCompania;
        private DateTime fechaRegistroCompania;
        private int statusCompania;
        private int presupuestoCompania;
        private int plazoPagoCompania;
        private int idLugar;

        #endregion

        #region Get's Set's


        public string NombreCompania
        {
            get { return nombreCompania; }
           
        }

        public string RifCompania
        {
            get { return rifCompania; }
            
        }

        public string EmailCompania
        {
            get { return emailCompania; }
            
        }

        public string TelefonoCompania
        {
            get { return telefonoCompania; }
           
        }

        public string AcronimoCompania
        {
            get { return acronimoCompania; }
            
        }

        public DateTime FechaRegistroCompania
        {
            get { return fechaRegistroCompania; }
            
        }

        public int StatusCompania
        {
            get { return statusCompania; }
           
        }

        public int PresupuestoCompania
        {
            get { return presupuestoCompania; }
            
        }

        public int PlazoPagoCompania
        {
            get { return plazoPagoCompania; }
          
        }

        public int IdLugar
        {
            get { return idLugar; }
            
        }


        #endregion

        #region Constructores

        public CompaniaM4()
        {
            Id = 0;
            nombreCompania = String.Empty;
            rifCompania = String.Empty;
            emailCompania = String.Empty;
            telefonoCompania = String.Empty;
            acronimoCompania = String.Empty;
            fechaRegistroCompania = DateTime.Now;
            statusCompania = 0;
            idLugar = 0;
        }


        public CompaniaM4(int inputId, string inputNombre, string inputRif, string inputEmail, string inputTelefono,
                        string inputAcronimo, DateTime inputFechaRegistro, int inputStatus, int inputPresupuesto,
                        int inputPlazoPago, int inputIdLugar)
        {
            this.Id = inputId;
            this.nombreCompania = inputNombre;
            this.rifCompania = inputRif;
            this.emailCompania = inputEmail;
            this.telefonoCompania = inputTelefono;
            this.acronimoCompania = inputAcronimo;
            this.fechaRegistroCompania = inputFechaRegistro;
            this.statusCompania = inputStatus;
            this.presupuestoCompania = inputPresupuesto;
            this.plazoPagoCompania = inputPlazoPago;
            this.idLugar = inputIdLugar;
        }

        public CompaniaM4(string inputNombre, string inputRif, string inputEmail, string inputTelefono, string inputAcronimo,
                        DateTime inputFechaRegistro, int inputStatus, int inputPresupuesto, int inputPlazoPago, int inputIdLugar)
        {
            this.nombreCompania = inputNombre;
            this.rifCompania = inputRif;
            this.emailCompania = inputEmail;
            this.telefonoCompania = inputTelefono;
            this.acronimoCompania = inputAcronimo;
            this.fechaRegistroCompania = inputFechaRegistro;
            this.statusCompania = inputStatus;
            this.presupuestoCompania = inputPresupuesto;
            this.plazoPagoCompania = inputPlazoPago;
            this.idLugar = inputIdLugar;
        }


        /*public Compania(string inputNombre, string inputRif, string inputEmail, int inputStatus, int inputPresupuesto)
        {
            this.nombreCompania = inputNombre;
            this.rifCompania = inputRif;
            this.emailCompania = inputEmail;
            this.statusCompania = inputStatus;
            this.presupuestoCompania = inputPresupuesto;
        }*/

        #endregion
    }
}
