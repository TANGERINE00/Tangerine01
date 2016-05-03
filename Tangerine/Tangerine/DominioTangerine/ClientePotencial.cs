using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class ClientePotencial
    {

        #region Atributos

        private int idClientePotencial;
        private string nombreClientePotencial;
        private string rifClientePotencial;
        private string emailClientePotencial;
        private double presupuestoAnual_inversion;
        private int numeroLlamadas;
        private int numeroVisitas;
        private string potencial;


        #endregion

        #region Get's Set's

        public int IdClientePotencial
        {
            get { return idClientePotencial; }
            set { idClientePotencial = value; }
        }

        public string NombreClientePotencial
        {
            get { return nombreClientePotencial; }
            set { nombreClientePotencial = value; }
        }
        public string RifClientePotencial
        {
            get { return rifClientePotencial; }
            set { rifClientePotencial = value; }

        }
        public string EmailClientePotencial
        {
            get { return emailClientePotencial; }
            set { emailClientePotencial = value; }

        }
        public double PresupuestoAnual_inversion
        {
            get { return presupuestoAnual_inversion; }
            set { presupuestoAnual_inversion = value; }

        }

        public int NumeroLlamadas
        {
            get { return numeroLlamadas; }
            set { numeroLlamadas = value; }

        }
        public int NumeroVisitas
        {
            get { return numeroVisitas; }
            set { numeroVisitas = value; }

        }
        public string Potencial
        {
            get { return potencial; }
            set { potencial = value; }

        }

        #endregion

        #region Constructores
        public ClientePotencial()
        {
            idClientePotencial = 0;
            nombreClientePotencial = String.Empty;
            rifClientePotencial = String.Empty;
            emailClientePotencial = String.Empty;
            presupuestoAnual_inversion = 0;
            numeroLlamadas = 0;
            numeroVisitas = 0;
            potencial = String.Empty;

        }

        public ClientePotencial(ClientePotencial elClientePotencial)
        {
            this.idClientePotencial = elClientePotencial.idClientePotencial;
            this.nombreClientePotencial = elClientePotencial.nombreClientePotencial;
            this.rifClientePotencial = elClientePotencial.rifClientePotencial;
            this.emailClientePotencial = elClientePotencial.emailClientePotencial;
            this.presupuestoAnual_inversion = elClientePotencial.presupuestoAnual_inversion;
            this.numeroLlamadas = elClientePotencial.numeroLlamadas;
            this.numeroVisitas = elClientePotencial.numeroVisitas;
            this.potencial = elClientePotencial.potencial;
        }


        #endregion


    }
}
