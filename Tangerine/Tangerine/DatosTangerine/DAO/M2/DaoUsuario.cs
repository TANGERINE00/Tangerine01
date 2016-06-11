using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M2;
using DominioTangerine;
using DatosTangerine.M10;
using ExcepcionesTangerine;

namespace DatosTangerine.DAO.M2
{
    public class DaoUsuario : DAOGeneral, IDaoUsuarios
    {
        /// <summary>
        /// Verificar si el usuario por su ficha
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns>Si existe True, si no, False</returns>
        public bool VerificarUsuarioPorFichaEmpleado( int fichaEmpleado )
        {
            return true;
        }

        /// <summary>
        /// Verificación si un usuario existe
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <returns>Si existe True, si no, False</returns>
        public bool VerificarExistenciaDeUsuario( string nombreUsuario )
        {
            return true;
        }

        public static List<Empleado> ConsultarListaDeEmpleados()
        {
            List<Empleado> listaDeEmpleados = new List<Empleado>();
            try
            {
                //Hablar con mod10 para que cambien el metodo ListaEmpleados() de lugar.
                listaDeEmpleados = BDEmpleado.ListarEmpleados();
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro("Error al ejecutar " +
                                                                     "ConsultarListaDeEmpleados()", ex);
            }
            return listaDeEmpleados;
        }
    }
}
