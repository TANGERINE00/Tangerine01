using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DominioTangerine.Entidades.M2
{
    public class UsuarioM2 : Entidad
    {
        #region Atributos

        private string _usuario;
        private string _contrasena;
        private DateTime _fechaCreacion;
        private string _activo;
        private RolM2 _rol;
        private int _fichaEmpleado;

        #endregion  

        #region Constructores

        /// <summary>
        /// Constructor vacío de la clase UsuarioM2
        /// </summary>
        public UsuarioM2()
        {
        }

        /// <summary>
        /// Constructor de la clase Usuario con usuario y contraseña
        /// </summary>
        /// <param name="usuario">Es el nombre de usuario</param>
        /// <param name="contrasena">Es la contraseña</param>
        public UsuarioM2( string usuario , string contrasena )
        {
            _usuario = usuario;
            _contrasena = contrasena;
        }

        /// <summary>
        /// Constructor de la clase Usuario con usuario y rol
        /// </summary>
        /// <param name="usuario">Es el nombre de usuario</param>
        /// <param name="rol">Es el rol</param>
        public UsuarioM2( string usuario , RolM2 rol )
        {
            _usuario = usuario;
            _rol = rol;
        }

        /// <summary>
        /// Constructor de la clase Usuario con usuario, contraseña y activo
        /// </summary>
        /// <param name="usuario">Es el nombre de usuario</param>
        /// <param name="contrasena">Es la contraseña</param>
        /// <param name="activo">Es el estatus</param>
        public UsuarioM2( string usuario , string contrasena , string activo )
               :this( usuario , contrasena )
        {
            _activo = activo;
        }

        /// <summary>
        /// Constructor de la clase Usuario con usuario, contraseña, activo y rol
        /// </summary>
        /// <param name="usuario">Es el nombre de usuario</param>
        /// <param name="contrasena">Es la contraseña</param>
        /// <param name="activo">Es el estatus</param>
        /// <param name="rol">Es el rol</param>
        public UsuarioM2( string usuario , string contrasena , string activo , RolM2 rol )
               :this( usuario , contrasena , activo )
        {
            _rol = rol;
        }

        /// <summary>
        /// Constructor de la clase Usuario con todos sus atributos sin id
        /// </summary>
        /// <param name="usuario">Es el nombre de usuario</param>
        /// <param name="contrasena">Es la contraseña</param>
        /// <param name="fechaCreacion">Es su fecha de creacion</param>
        /// <param name="activo">Es el estatus</param>
        /// <param name="rol">Es el rol</param>
        /// <param name="fichaEmpleado">Es la ficha del empleado</param>
        public UsuarioM2( string usuario , string contrasena , DateTime fechaCreacion , string activo , RolM2 rol , int fichaEmpleado )
               :this( usuario , contrasena , activo , rol )
        {
            _fechaCreacion = fechaCreacion;
            _fichaEmpleado = fichaEmpleado;
        }

        /// <summary>
        /// Constructor de la clase Usuario con todos sus atributos y con id
        /// </summary>
        /// <param name="id">Es el id del usuario</param>
        /// <param name="usuario">Es el nombre de usuario</param>
        /// <param name="contrasena">Es la contraseña</param>
        /// <param name="fechaCreacion">Es su fecha de creacion</param>
        /// <param name="activo">Es el estatus</param>
        /// <param name="rol">Es el rol</param>
        /// <param name="fichaEmpleado">Es la ficha del empleado</param>
        public UsuarioM2( int id , string usuario , string contrasena , DateTime fechaCreacion , string activo , RolM2 rol ,
                          int fichaEmpleado )
               :this ( usuario , contrasena , activo , rol )
        {
            Id = id;
            _fechaCreacion = fechaCreacion;
            _fichaEmpleado = fichaEmpleado;
        }

        #endregion

        #region Get's y Set's

        /// <summary>
        /// Get y Set del atributo _usuario
        /// </summary>
        /// <returns>Usuario de acceso al sistema Tangerine</returns>
        public string nombreUsuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        /// <summary>
        /// Get y Set del atributo _contraseña
        /// </summary>
        /// <returns>Contraseña del usuario</returns>
        public string contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        /// <summary>
        /// Get y Set del atributo _fechaCreacion
        /// </summary>
        /// <returns>Fecha de creacion del usuario</returns>
        public DateTime fechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }

        /// <summary>
        /// Get y Set del atributo _activo
        /// </summary>
        /// <returns>Activo si el usuario se encuentra activo o Inactivo si el usuario se encuentra inactivo</returns>
        public string activo
        {
            get { return _activo; }
            set { _activo = value; }
        }

        /// <summary>
        /// Get y Set del atributo _rol
        /// </summary>
        /// <returns>Rol del usuario</returns>
        public RolM2 rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        /// <summary>
        /// Get y Set de la ficha del empleado al que pertenece este usuario
        /// </summary>
        /// <returns>Ficha del empleado asociada al usuario</returns>
        public int fichaEmpleado
        {
            get { return _fichaEmpleado; }
            set { _fichaEmpleado = value; }
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método para encriptar la contraseña del usuario, se utiliza al crear el usuario y en el login para comparar
        /// la contraseña colocada y la contraseña real
        /// </summary>
        /// <param name="contrasena">Es la contraseña que se quiere encriptar</param>
        /// <returns></returns>
        public string GetMD5( string contrasena )
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();

            ASCIIEncoding encoding = new ASCIIEncoding();

            StringBuilder sb = new StringBuilder();

            byte[] stream = md5.ComputeHash( encoding.GetBytes( contrasena ) );

            for ( int i = 0 ; i < stream.Length ; i++ )
            {
                sb.AppendFormat( "{0:x2}" , stream[i] );
            }

            return sb.ToString();
        }

        #endregion
    }
}
