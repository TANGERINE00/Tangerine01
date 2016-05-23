using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class Compania
    {
        #region Atributos

        private int idCompania;
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

        public int IdCompania
        {
            get { return idCompania; }
            set { idCompania = value; }
        }

        public string NombreCompania
        {
            get { return nombreCompania; }
            set { nombreCompania = value; }
        }

        public string RifCompania
        {
            get { return rifCompania; }
            set { rifCompania = value; }
        }

        public string EmailCompania
        {
            get { return emailCompania; }
            set { emailCompania = value; }
        }

        public string TelefonoCompania
        {
            get { return telefonoCompania; }
            set { telefonoCompania = value; }
        }

        public string AcronimoCompania
        {
            get { return acronimoCompania; }
            set { acronimoCompania = value; }
        }

        public DateTime FechaRegistroCompania
        {
            get { return fechaRegistroCompania; }
            set { fechaRegistroCompania = value; }
        }

        public int StatusCompania
        {
            get { return statusCompania; }
            set { statusCompania = value; }
        }

        public int PresupuestoCompania
        {
            get { return presupuestoCompania; }
            set { presupuestoCompania = value; }
        }

        public int PlazoPagoCompania
        {
            get { return plazoPagoCompania; }
            set { plazoPagoCompania = value; }
        }

        public int IdLugar
        {
            get { return idLugar; }
            set { idLugar = value; }
        }

        
        #endregion

        #region Constructores

        public Compania()
        {
            idCompania = 0;
            nombreCompania = String.Empty;
            rifCompania = String.Empty;
            emailCompania = String.Empty;
            telefonoCompania = String.Empty;
            acronimoCompania = String.Empty;
            fechaRegistroCompania = DateTime.Now;
            statusCompania = 0;
            idLugar = 0;
        }

    
        public Compania(int inputId, string inputNombre, string inputRif, string inputEmail, string inputTelefono,
                        string inputAcronimo, DateTime inputFechaRegistro, int inputStatus, int inputPresupuesto,
                        int inputPlazoPago, int inputIdLugar)
        {
            this.idCompania = inputId;
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

        public Compania(string inputNombre, string inputRif, string inputEmail, string inputTelefono, string inputAcronimo,
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


        public Compania(string inputNombre, string inputRif, string inputEmail, int inputStatus, int inputPresupuesto)
        {
            this.nombreCompania = inputNombre;
            this.rifCompania = inputRif;
            this.emailCompania = inputEmail;
            this.statusCompania = inputStatus;
            this.presupuestoCompania = inputPresupuesto;
        }

        #endregion
    }
}
