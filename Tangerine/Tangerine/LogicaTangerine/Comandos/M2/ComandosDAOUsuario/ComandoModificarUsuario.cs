using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M2;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M2;

namespace LogicaTangerine.Comandos.M2.ComandosDAOUsuario
{
    public class ComandoModificarUsuario : Comando<Boolean>
    {
        public int _fichaEmpleado;
        public string _nombreUsuario;

        /// <summary>
        /// Constructor que recibe un parametro del tipo int y otro del tipo string
        /// </summary>
        /// <param name="fichaEmpleado">Es la ficha del empleado</param>
        /// <param name="nombreUsuario">Es el nombre del usuario</param>
        public ComandoModificarUsuario( int fichaEmpleado , string nombreUsuario )
        {
            _fichaEmpleado = fichaEmpleado;
            _nombreUsuario = nombreUsuario;
        }

        /// <summary>
        /// Método para crear la instancia de la clase DaoUsuario y usar el método ModificarUsuario
        /// </summary>
        /// <returns></returns>
        public override bool Ejecutar()
        {
            try
            {
                bool resultado;
                IDAOUsuarios UsuarioModify = FabricaDAOSqlServer.crearDaoUsuario();
                resultado = UsuarioModify.ModificarUsuario( _fichaEmpleado , _nombreUsuario );
                return resultado;
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                throw new ExceptionM2Tangerine( "DS-202" , "Metodo no implementado" , ex );
            }
        }
    }
}
