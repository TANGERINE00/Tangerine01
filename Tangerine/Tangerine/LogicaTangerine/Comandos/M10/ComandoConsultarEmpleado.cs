using DatosTangerine.DAO.M10;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine;
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

        public ComandoConsultarEmpleado()
        {
            // TODO: Complete member initialization
            this.empleado = empleado;
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDAOEmpleado daoEmpleado =(DatosTangerine.DAO.M10.DAOEmpleado) DatosTangerine.Fabrica.FabricaDAOSqlServer.ConsultarDAOEmpleado();
               // List<Entidad> empleados = daoEmpleado.ConsultarTodos();
                return daoEmpleado.ConsultarTodos();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
