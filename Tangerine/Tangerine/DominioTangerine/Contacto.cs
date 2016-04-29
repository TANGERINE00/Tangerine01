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
        private int tipoCompañia;
        private int idCompañia;

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

        public int TipoCompañia
        {
            get { return tipoCompañia; }
            set { tipoCompañia = value; }
        }

        public int IdCompañia
        {
            get { return idCompañia; }
            set { idCompañia = value; }
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
            tipoCompañia = 0;
            idCompañia = 0;
        }

        public Contacto(Contacto elContacto)
        {
            this.idContacto = elContacto.idContacto;
            this.nombre = elContacto.nombre;
            this.apellido = elContacto.apellido;
            this.telefono = elContacto.telefono;
            this.correo = elContacto.correo;
            this.departamento = elContacto.departamento;
            this.cargo = elContacto.cargo;
            this.tipoCompañia = elContacto.tipoCompañia;
            this.idCompañia = elContacto.idCompañia;
        }
        #endregion
    }
}
