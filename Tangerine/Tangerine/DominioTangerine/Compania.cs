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
        }

        public Compania(Compania laCompania)
        {
            this.idCompania = laCompania.idCompania;
            this.nombreCompania = laCompania.nombreCompania;
            this.rifCompania = laCompania.rifCompania;
            this.emailCompania = laCompania.emailCompania;
            this.acronimoCompania = laCompania.acronimoCompania;
            this.fechaRegistroCompania = laCompania.fechaRegistroCompania;
        }

        #endregion
    }

}
