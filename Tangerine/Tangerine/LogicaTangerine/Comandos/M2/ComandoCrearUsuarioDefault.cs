using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesTangerine;

namespace LogicaTangerine.Comandos.M2
{
    public class ComandoCrearUsuarioDefault : Comando<String>
    {
        String _nombre, _apellido;

        public ComandoCrearUsuarioDefault() { }
        /// <summary>
        /// Constructor que recibe los parametros nombre y apellido
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        public ComandoCrearUsuarioDefault( String nombre, String apellido )
        {
            _nombre = nombre;
            _apellido = apellido;
        }

        /// <summary>
        /// Método que devuelve el usuario por defecto para un empleado
        /// </summary>
        /// <returns>Retorna el usuario por defecto</returns>
        public override string Ejecutar()
        {
            string usuarioNuevo = "";
            try
            {
                _nombre = _nombre.ToLower();
                _apellido = _apellido.ToLower();

                ComandoObtenerCaracteres commandObtenerNombre = new ComandoObtenerCaracteres(_nombre, 2);
                ComandoObtenerCaracteres commandObtenerApellido = new ComandoObtenerCaracteres(_apellido, 4);

                //Obtiene los 2 primeros caracteres del nombre
                usuarioNuevo = commandObtenerNombre.Ejecutar();
                //Obtiene los 4 primeros caracteres del apellido
                usuarioNuevo = usuarioNuevo + commandObtenerApellido.Ejecutar();
            }
            catch (NullReferenceException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro("Parametro invalido", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro("Error al ejecutar " +
                                                                     "CrearUsuarioDefault()", ex);
            }

            return usuarioNuevo;
        }
    }
}
