using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M2;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using ExcepcionesTangerine;

namespace LogicaTangerine.M1
{
    public class LogicaM1
    {
        ///<sumary>
        ///Metodo que valida si alguno de los campos en la lista contiene caracter vacio 
        ///</sumary>
        ///<param name="campos">Lista de String con los campos a validar</param>
        ///<returns>true, sin ningun campo en la lista contiene caracter vacío
        ///         false, si al menos un campo contiene caracter vacío</returns>
        public bool ValidarVacio(List<String> campos)
        {
            String caracterVacio = "";

            for (int i = 0; i < campos.Count; i++)
            {
                if (campos[i].Equals(caracterVacio))
                {
                    return false;
                }
            }
            return true;
        }
        ///<sumary>
        ///Metodo que valida si el campo esta compuesto por caracteres alfanumericos, guión o guión bajo
        ///</sumary>
        ///<param name="campo">String de campo a validar</param>
        ///<returns>true, si todos los caracteres son alfanuméricos, guión o guión bajo
        ///         false, si al menos un caracter no es alfanumérico, guión o guión bajo</returns>
        public bool ValidarCaracter(String campo)
        {
            String comparar = ResourceLogicaM1.alfanumerico;
            for (int i = 0; i < campo.Length; i++)
            {
                Boolean resultado = comparar.Contains(campo[i]);
                if (resultado != true)
                    return resultado;
            }

            return true;
        }

        ///<sumary>
        ///Metodo que valida que las credenciales de inicio de sesion
        ///esten en el formato correcto y que coinciden con un Usuario dentro
        ///de la base de datos
        ///</sumary>
        ///<param name="usuario">String de nombre de Usuario</param>
        ///<param name="contrasena">String de contraseña de Usuario</param>
        ///<returns>true, si los datos estan en el formato correcto y el usuario existe</returns>
        public bool ValidarUsuario(string usuario, string contrasena)
        {
            List<String> campos = new List<String>();

            campos.Add(usuario);
            campos.Add(contrasena);

            if (ValidarVacio(campos))
            {
                if (this.ValidarCaracter(usuario) && this.ValidarCaracter(contrasena))
                {
                    if (ConsultarUsuario(usuario, contrasena))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            return false;
        }

        ///<sumary>
        ///Metodo que valida que las credenciales de login coincidan con
        ///un Usuario dentro de la base de datos
        ///</sumary>
        ///<param name="nombreUsuario">String de nombre de Usuario</param>
        ///<param name="clave">String de contraseña de Usuario</param>
        ///<returns>true, si el usuario existe</returns>
        public bool ConsultarUsuario(string nombreUsuario, string clave)
        {
            try
            {
                Usuario theUsuario = new Usuario(nombreUsuario,clave);
                theUsuario.Contrasenia = theUsuario.GetMD5(clave);
                theUsuario = BDUsuario.ObtenerDatoUsuario(theUsuario);

                if (theUsuario.Activo != null)
                {
                    string _prueba = theUsuario.Activo;
                    Util._theGlobalUser = theUsuario;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
