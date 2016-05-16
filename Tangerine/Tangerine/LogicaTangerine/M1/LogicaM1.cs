using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public bool ValidarUsuario(string usuario, string contrasena)
        {
            List<String> campos = new List<String>();
            campos.Add(usuario);
            campos.Add(contrasena);

            if (ValidarVacio(campos))
            {
                if (this.ValidarCaracter(usuario) && this.ValidarCaracter(contrasena))
                {
                    this.ConsultarUsuario(usuario, contrasena);
                    return true;
                }
                else
                    return false;
                //mensajeLogin(RecursosInterfazPresentadorM1.logCaracterInvalidos, RecursosInterfazPresentadorM1.tipoErr);
            }
            return false;
        }

        public bool ConsultarUsuario(string nombreUsuario, string clave)
        {
            try
            {
                //Bool para traer datos de usuario y comparar con contraseña
                //return BDUsuario.TraerUsuario();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
