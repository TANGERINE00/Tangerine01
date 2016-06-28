using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcepcionesTangerine;
using LogicaTangerine.Fabrica;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M2;

namespace LogicaTangerine.Comandos.M2
{
    public class ComandoCrearUsuarioDefault : Comando<String>
    {
        String _nombre, _apellido;

        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public ComandoCrearUsuarioDefault() { }

        /// <summary>
        /// Constructor que recibe los parametros nombre y apellido
        /// </summary>
        /// <param name="nombre">Es el nombre del empleado</param>
        /// <param name="apellido">Es el apellido del empleado</param>
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

                LogicaTangerine.Comando<String> commandObtenerNombre = FabricaComandos.obtenerCaracteres( _nombre , 2 );
                LogicaTangerine.Comando<String> commandObtenerApellido = FabricaComandos.obtenerCaracteres( _apellido , 4 );

                //Obtiene los 2 primeros caracteres del nombre
                usuarioNuevo = commandObtenerNombre.Ejecutar();
                //Obtiene los 4 primeros caracteres del apellido
                usuarioNuevo = usuarioNuevo + commandObtenerApellido.Ejecutar();
            }
            catch ( NullReferenceException ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                throw new ExceptionM2Tangerine( "Ingreso de un argumento con valor invalido" , ex );
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                throw new ExceptionM2Tangerine( "DS-202" , "Metodo no implementado" , ex );
            }

            return usuarioNuevo;
        }
    }
}
