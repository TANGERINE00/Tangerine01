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
    public class ComandoConsultarUltimoIDEmpleado : Comando<int>
    {
        /// <summary>
        /// Constructor vacio de la clase
        /// </summary>
        public ComandoConsultarUltimoIDEmpleado()
        {

        }

        /// <summary>
        /// Mètodo para ejecutar la logica del ComandoConsultarUltimoIDEmpleado
        /// </summary>
        /// <returns>Retorna el ID del ultimo empleado</returns>
        public override int Ejecutar()
        {
            try
            {
                int resultado;
                IDAOUsuarios LastEmployeID = FabricaDAOSqlServer.crearDaoUsuario();
                resultado = LastEmployeID.ConsultLastEmployeID();
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
