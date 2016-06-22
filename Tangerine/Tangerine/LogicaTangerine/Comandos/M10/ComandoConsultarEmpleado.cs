using DatosTangerine.DAO.M10;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine;
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

        public ComandoConsultarEmpleado()
        {
            
            this.empleado = empleado;
        }
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDAOEmpleado daoEmpleado =(DatosTangerine.DAO.M10.DAOEmpleado) DatosTangerine.Fabrica.FabricaDAOSqlServer.ConsultarDAOEmpleado();
                return daoEmpleado.ConsultarTodos();
            }
            catch (AgregarContactoException ex)
            {
                throw ex;
            }
            catch (BaseDeDatosContactoException ex)
            {
                throw ex;
            }
        }
    }
}
