using DatosTangerine.DAO.M10;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine;
using ExcepcionesTangerine.M10;
using ExcepcionesTangerine.M5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M10
{
    public class ComandoConsultarEmpleado : Comando<List<Entidad>>
    {
        private Entidad empleado;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ComandoConsultarEmpleado()
        {
            
            this.empleado = empleado;
        }

        /// <summary>
        /// Metodo para ejecutar el comando
        /// </summary>
        /// <returns></returns>
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDAOEmpleado daoEmpleado =(DatosTangerine.DAO.M10.DAOEmpleado) DatosTangerine.Fabrica.
                FabricaDAOSqlServer.ConsultarDAOEmpleado();
                return daoEmpleado.ConsultarTodos();
            }
            catch (AgregarEmpleadoException ex)
            {
                throw ex;
            }
            catch (BaseDatosException ex)
            {
                throw ex;
            }
        }
    }
}
