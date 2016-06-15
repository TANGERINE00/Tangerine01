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

        #region Get's
        /*public int IdContacto
        {
            get { return _idContacto; }
        }*/

        public string Nombre
        {
            get { return _nombre; }
        }

        public string Apellido
        {
            get { return _apellido; }
        }

        public string Telefono
        {
            get { return _telefono; }
        }

        public string Correo
        {
            get { return _correo; }
        }

        public string Departamento
        {
            get { return _departamento; }
        }

        public string Cargo
        {
            get { return _cargo; }
        }

        public int TipoCompañia
        {
            get { return _tipoCompañia; }
        }

        public int IdCompañia
        {
            get { return _idCompañia; }
        }
        #endregion

        #region Constructores
        public ContactoM5()
        {

        }

        public ContactoM5( string nombre, string apellido, string departamento,
                           string cargo, string telefono, string correo, int tipoCompañia, int idCompañia )
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

        public ContactoM5( int idContacto, string nombre, string apellido, string departamento,
                           string cargo, string telefono, string correo, int tipoCompañia, int idCompañia )
                   : this( nombre, apellido, departamento, cargo, telefono, correo, tipoCompañia, idCompañia )
        {
            this.Id = idContacto;
        }
        #endregion
    }
}
