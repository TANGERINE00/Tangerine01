using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M5
{
    public class ContactoM5 : Entidad
    {
        #region Atributos

        private int _idContacto;
        private string _nombre;
        private string _apellido;
        private string _telefono;
        private string _correo;
        private string _departamento;
        private string _cargo;
        private int _tipoCompañia;
        private int _idCompañia;

        #endregion

        #region Get's Set's
        public int IdContacto
        {
            get { return _idContacto; }
            set { _idContacto = value; }
        }

        public String Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public String Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public String Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        public String Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        public String Departamento
        {
            get { return _departamento; }
            set { _departamento = value; }
        }

        public String Cargo
        {
            get { return _cargo; }
            set { _cargo = value; }
        }

        public int TipoCompañia
        {
            get { return _tipoCompañia; }
            set { _tipoCompañia = value; }
        }

        public int IdCompañia
        {
            get { return _idCompañia; }
            set { _idCompañia = value; }
        }

        #endregion

        #region Constructores
        public ContactoM5()
        {

        }

        public ContactoM5(string nombre, string apellido, string departamento,
            string cargo, string telefono, string correo, int tipoCompañia, int idCompañia)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._telefono = telefono;
            this._correo = correo;
            this._departamento = departamento;
            this._cargo = cargo;
            this._tipoCompañia = tipoCompañia;
            this._idCompañia = idCompañia;
        }

        public ContactoM5(int idContacto, string nombre, string apellido, string departamento,
            string cargo, string telefono, string correo, int tipoCompañia, int idCompañia)
            : this(nombre, apellido,
                   departamento, cargo,
                   telefono, correo,
                   tipoCompañia,
                   idCompañia)
        {
            this._idContacto = idContacto;
        }
        #endregion
    }
}
