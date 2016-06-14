using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine.Entidades.M2;

namespace DominioTangerine.Entidades.M1
{
    public class Cuenta : Entidad
    {
        #region atributos

        private String nombre_usuario;
        private String contrasena;
        private List<RolM2> roles;
        private string elNombreUsuario;
        private string laContrasena;
     

        #endregion

        #region propiedades

        public String Nombre_usuario
        {
            get { return nombre_usuario; }
            set { nombre_usuario = value; }
        }
        public String Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }

        public List<RolM2> Roles
        {
            get { return roles; }
            set { roles = value; }
        }
      
        #endregion

        #region constructores
        /// <summary>
        /// constructor numero 1 de cuenta el cual no recibe   parametros
        /// </summary>
        public Cuenta()
        {
            nombre_usuario = "";
            contrasena = "";
            roles = new List<RolM2>();
        }
        /// <summary>
        /// constructor numero 3 de cuenta el cual recibe mas parametros
        /// </summary>
        /// <param name="elNombreUsuario"> el nombre del usuario</param>
        /// <param name="laContrasena">la contraseña del usuario</param>
        /// <param name="listaRoles">lsita de los roles a los cuales pertenece el usuario</param>
        public Cuenta(String elNombreUsuario, String laContrasena, List<RolM2> listaRoles)
        {
            nombre_usuario = elNombreUsuario;
            contrasena = laContrasena;
            roles = listaRoles;
         
        }

        #endregion
    }
}
