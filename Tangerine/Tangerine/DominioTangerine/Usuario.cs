using System;
using System.Security.Cryptography;
using System.Text;

namespace DominioTangerine
{
	public class Usuario
    {
        #region Atributos

        private string _usuario;
		private string _contrasenia;
		private string _activo;
        private Rol _rol;
        private int _fichaEmpleado;
        private DateTime _fechaCreacion;

        #endregion  

        #region Constructores

        /// <summary>
        /// Constructor vac�o de la clase Usuario
        /// </summary>
		public Usuario()
		{
		}

        /// <summary>
        /// Constructor de Usuario solo con usuario, contrase�a
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasenia"></param>
        public Usuario( string usuario, string contrasenia )
        {
            _usuario = usuario;
            _contrasenia = contrasenia;
        }

        /// <summary>
        /// Constructor de Usuario solo con usuario y rol
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="rol"></param>
        public Usuario( string usuario, Rol rol) 
        {
            _usuario = usuario;
            _rol = rol;
        }

        /// <summary>
        /// Constructor de Usuario solo con usuario, contrase�a y activo
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasenia"></param>
        /// <param name="activo"></param>
        public Usuario( string usuario, string contrasenia, string activo ) 
               : this( usuario, contrasenia )
        {
            _activo = activo;
        }

        /// <summary>
        /// Constructor de Usuario solo con usuario, contrase�a, activo y rol
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasenia"></param>
        /// <param name="activo"></param>
        /// <param name="rol"></param>
        public Usuario( string usuario, string contrasenia, string activo, Rol rol )
               : this( usuario, contrasenia, activo )
		{
			_rol = rol;
		}

        /// <summary>
        /// Constructor de Usuario con todos sus atributos
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasenia"></param>
        /// <param name="activo"></param>
        /// <param name="rol"></param>
        /// <param name="fichaEmpleado"></param>
        /// <param name="fechaCreacion"></param>
        public Usuario( string usuario, string contrasenia, string activo, Rol rol, int fichaEmpleado, 
                        DateTime fechaCreacion ) : this( usuario, contrasenia, activo, rol )
        {
            _fichaEmpleado = fichaEmpleado;
            _fechaCreacion = fechaCreacion;
        }

        #endregion

        #region Get's y Set's

        /// <summary>
        /// Get y Set del atributo usuario
        /// </summary>
        /// <returns>Usuario de acceso al sistema Tangerine</returns>
		public string NombreUsuario
		{
            get { return _usuario; }
            set { _usuario = value; }
		}

        /// <summary>
        /// Get y Set del atributo contrase�a
        /// </summary>
        /// <returns>Contrase�a del usuario</returns>
		public string Contrasenia
		{
			get { return _contrasenia; }
            set { _contrasenia = value; }
		}

        /// <summary>
        /// Get y Set del atributo activo
        /// </summary>
        /// <returns>Activo si el usuario se encuentra activa o Inactivo si el usuario se encuentra inactivo</returns>
        public string 
            Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        /// <summary>
        /// Get y Set del atributo rol
        /// </summary>
        /// <returns>Rol del usuario</returns>
		public Rol Rol
		{
            get { return _rol; }
            set { _rol = value; }
		}

        /// <summary>
        /// Get y Set de la ficha del empleado al que pertenece este usuario
        /// </summary>
        /// <returns></returns>
        public int FichaEmpleado 
        {
            get { return _fichaEmpleado; }
            set { _fichaEmpleado = value; }
        }

        /// <summary>
        /// Get y Set de la fecha de creacion del usuario
        /// </summary>
        /// <returns></returns>
        public DateTime FechaCreacion 
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        #endregion

        #region M�todos

        /// <summary>
        /// M�todo para encriptar la contrase�a del usuario,se utiliza al crear el usuario y en el login para comparar
        /// la contrase�a colocada y la contrase�a real
        /// </summary>
        /// <param name="contrasenia"></param>
        /// <returns></returns>
        public string GetMD5( string contrasenia )
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();

            ASCIIEncoding encoding = new ASCIIEncoding();

            StringBuilder sb = new StringBuilder();

            byte[] stream = md5.ComputeHash( encoding.GetBytes( contrasenia ) );

            for ( int i = 0; i < stream.Length; i++ )
            {
                sb.AppendFormat( "{0:x2}", stream[ i ] );
            }

            return sb.ToString();
        }

        #endregion
    }
}

