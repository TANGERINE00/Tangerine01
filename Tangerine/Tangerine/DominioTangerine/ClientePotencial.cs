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
        private float presupuestoAnual_inversion;
        private int numeroLlamadas;
        private int numeroVisitas;
        private int status;


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
        public float PresupuestoAnual_inversion
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

        public int Status
        {
            get { return status; }
            set { status = value;  }


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
            status = 0;
        }
       //con todos los atributos inclyendo el id
        public ClientePotencial(int inputId, string inputNombre, string inputRif, string inputEmail, float inputPresupuesto,
            int inputNumerollamadas, int inputNumeroVisitas, int inputStatus)
        {
            this.idClientePotencial = inputId;
            this.nombreClientePotencial = inputNombre;
            this.rifClientePotencial = inputRif;
            this.emailClientePotencial = inputEmail;
            this.presupuestoAnual_inversion = inputPresupuesto;
            this.numeroLlamadas = inputNumerollamadas;
            this.numeroVisitas = inputNumeroVisitas;
            this.status = inputStatus;
        }
//con todos los atributos sin incluir el id
        public ClientePotencial( string inputNombre, string inputRif, string inputEmail, float inputPresupuesto,
          int inputNumerollamadas, int inputNumeroVisitas, int inputStatus)
        {
            
            this.nombreClientePotencial = inputNombre;
            this.rifClientePotencial = inputRif;
            this.emailClientePotencial = inputEmail;
            this.presupuestoAnual_inversion = inputPresupuesto;
            this.numeroLlamadas = inputNumerollamadas;
            this.numeroVisitas = inputNumeroVisitas;
            this.status = inputStatus;
        }


        //para el agregar
        public ClientePotencial(string inputNombre, string inputRif, string inputEmail, float inputPresupuesto,
            int inputStatus)
        {

            this.nombreClientePotencial = inputNombre;
            this.rifClientePotencial = inputRif;
            this.emailClientePotencial = inputEmail;
            this.presupuestoAnual_inversion = inputPresupuesto;
            this.status = inputStatus;
      
        }
   
     


        //para el modificar y el consultar final
        public ClientePotencial (int inputId,string inputNombre, string inputRif, string inputEmail, float inputPresupuesto,
            int inputNumerollamadas, int inputNumeroVisitas)
        {
            this.idClientePotencial = inputId;
            this.nombreClientePotencial = inputNombre;
            this.rifClientePotencial = inputRif;
            this.emailClientePotencial = inputEmail;
            this.presupuestoAnual_inversion = inputPresupuesto;
             this.numeroLlamadas = inputNumerollamadas;
            this.numeroVisitas = inputNumeroVisitas;
        }


        #endregion



    }
}

