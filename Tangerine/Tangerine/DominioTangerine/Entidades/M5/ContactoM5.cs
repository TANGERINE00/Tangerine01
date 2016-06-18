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
        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public ContactoM5()
        {

        }

        /// <summary>
        /// Constructor sin id de la clase
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="departamento"></param>
        /// <param name="cargo"></param>
        /// <param name="telefono"></param>
        /// <param name="correo"></param>
        /// <param name="tipoCompañia"></param>
        /// <param name="idCompañia"></param>
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

        /// <summary>
        /// Constructor con todos los atributos de la clase
        /// </summary>
        /// <param name="idContacto"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="departamento"></param>
        /// <param name="cargo"></param>
        /// <param name="telefono"></param>
        /// <param name="correo"></param>
        /// <param name="tipoCompañia"></param>
        /// <param name="idCompañia"></param>
        public ContactoM5( int idContacto, string nombre, string apellido, string departamento,
                           string cargo, string telefono, string correo, int tipoCompañia, int idCompañia )
                   : this( nombre, apellido, departamento, cargo, telefono, correo, tipoCompañia, idCompañia )
        {
            this.Id = idContacto;
        }
        #endregion
    }
}
