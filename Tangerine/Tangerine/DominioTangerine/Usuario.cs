using System;

namespace DominioTangerine
{
	public class Usuario
    {
        #region Atributos

        private string _usuario;
		private string _contrasenia;
		private string _activo;
        private string _rol;
        private int _fichaEmpleado;
        private DateTime _fechaCreacion;

        #endregion  

        #region Constructores

        /// <summary>
        /// Constructor vacío de la clase Usuario
        /// </summary>
		public Usuario()
		{
		}

        /// <summary>
        /// Constructo de Usuario solo con usuario, contraseña y activo
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasenia"></param>
        public Usuario( string usuario, string contrasenia, string activo ) 
        {
            this._usuario = usuario;
            this._contrasenia = contrasenia;
            this._activo = activo;
        }

        /// <summary>
        /// Constructor de Usuario solo con usuario, contraseña, activo y rol
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="contrasenia"></param>
        /// <param name="activo"></param>
        /// <param name="rol"></param>
        public Usuario( string usuario, string contrasenia, string activo, string rol )
               : this( usuario, contrasenia, activo )
		{
			this._rol = rol;
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
        public Usuario( string usuario, string contrasenia, string activo, string rol, int fichaEmpleado, 
                        DateTime fechaCreacion ) : this( usuario, contrasenia, activo, rol )
        {
            this._fichaEmpleado = fichaEmpleado;
            this._fechaCreacion = fechaCreacion;
        }

        #endregion

        #region Get's

        /// <summary>
        /// Método que devuelve el valor del atributo usuario
        /// </summary>
        /// <returns>Usuario de acceso al sistema Tangerine</returns>
		public string GetUsuario()
		{
			return this._usuario;
		}

        /// <summary>
        /// Método que devuelve el valor del atributo contraseña
        /// </summary>
        /// <returns>Contraseña del usuario</returns>
		public string GetContrasenia()
		{
			return this._contrasenia;
		}

        /// <summary>
        /// Método que devuelve el valor del atributo activo
        /// </summary>
        /// <returns>Activo si el usuario se encuentra activa o Inactivo si el usuario se encuentra inactivo</returns>
        public string GetActivo()
        {
            return this._activo;
        }

        /// <summary>
        /// Método que devuelve el valor del atributo rol
        /// </summary>
        /// <returns>Rol del usuario</returns>
		public string GetRol()
		{
			return this._rol;
		}

        /// <summary>
        /// Método que devuelve el valor de la ficha del empleado al que pertenece este usuario
        /// </summary>
        /// <returns></returns>
        public int GetFichaEmpleado() 
        {
            return this._fichaEmpleado;
        }

        /// <summary>
        /// Método que retorna la fecha de creacion del usuario
        /// </summary>
        /// <returns></returns>
        public DateTime GetFechaCreacion() 
        {
            return this._fechaCreacion;
        }

        #endregion
    }
}