using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
    public class Contacto
    {
        #region Atributos

        private int idContacto;
        private String nombre;
        private String apellido;
        private String telefono;
        private String correo;
        private String departamento;
        private String cargo;

        
       
        #endregion

        #region Get's Set's
        public int IdContacto
        {
            get { return idContacto; }
            set { idContacto = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public String Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public String Correo
        {
            get { return correo; }
            set { correo = value; }
        }
        
        public String Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        public String Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }

        
        #endregion

        #region Constructores
        public Contacto()
        {
            idContacto = 0;
            nombre = String.Empty;
            apellido = String.Empty;
            telefono = String.Empty;
            correo = String.Empty;
            departamento = String.Empty;
            cargo = String.Empty;
        }

        public Contacto(int inputId, String inputNombre, String inputApellido, String inputTelefono, String inputCorreo, String inputDepartamento, String inputCargo)
        {
            this.idContacto = inputId;
            this.nombre = inputNombre;
            this.apellido = inputApellido;
            this.telefono = inputTelefono;
            this.correo = inputCorreo;
            this.departamento = inputDepartamento;
            this.cargo = inputCargo;
        }
        #endregion
    }
}
