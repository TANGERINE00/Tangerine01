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
        private string acronimoCompania;
        private DateTime fechaRegistroCompania;
        private int statusCompania;
        private int idLugar;
        private int idClientePotencial;

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

        public int IdLugar
        {
            get { return idLugar; }
            set { idLugar = value; }
        }

        public int IdClientePotencial
        {
            get { return idClientePotencial; }
            set { idClientePotencial = value; }
        }

        #endregion

        #region Constructores

        public Compania()
        {
            idCompania = 0;
            nombreCompania = String.Empty;
            rifCompania = String.Empty;
            emailCompania = String.Empty;
            acronimoCompania = String.Empty;
            fechaRegistroCompania = DateTime.Now;
            statusCompania = 0;
            idLugar = 0;
            idClientePotencial = 0;
        }

        public Compania(int inputId, string inputNombre, string inputRif, string inputEmail, string inputAcronimo,
                        DateTime inputFechaRegistro, int inputStatus, int inputIdLugar, int inputIdCliente)
        {
            this.idCompania = inputId;
            this.nombreCompania = inputNombre;
            this.rifCompania = inputRif;
            this.emailCompania = inputEmail;
            this.acronimoCompania = inputAcronimo;
            this.fechaRegistroCompania = inputFechaRegistro;
            this.statusCompania = inputStatus;
            this.idLugar = inputIdLugar;
            this.idClientePotencial = inputIdCliente;
        }

        #endregion
    }

}
