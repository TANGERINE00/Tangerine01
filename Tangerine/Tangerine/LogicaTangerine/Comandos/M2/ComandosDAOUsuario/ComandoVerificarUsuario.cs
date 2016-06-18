using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M2;

namespace LogicaTangerine.Comandos.M2
{
    public class ComandoVerificarUsuario : Comando<Boolean>
    {
        public int _fichaEmpleado;
 
        /// <summary>
        /// Constructor que recibe la ficha del empleado
        /// </summary>
        /// <param name="fichaEmpleado"></param>
        public ComandoVerificarUsuario( int fichaEmpleado )
        {
            _fichaEmpleado = fichaEmpleado;
        }

        /// <summary>
        /// Método para crear la instancia de la clase DaoUsuario y usar el método VerificarUsuarioPorFichaEmpleado
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override bool Ejecutar()
        {
            bool resultado;
            IDAOUsuarios UsuarioVerify = FabricaDAOSqlServer.crearDaoUsuario();
            resultado = UsuarioVerify.VerificarUsuarioPorFichaEmpleado( _fichaEmpleado );
            return resultado;
        }
    }
}
