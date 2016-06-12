using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine.Entidades.M10;
using DominioTangerine;

namespace DatosTangerine.DAO.M10
{
    public class DAOEmpleado : DAOGeneral, IDAOEmpleado
    {



        public bool AddEmpleado(DominioTangerine.Empleado theEmpleado)
        {
            throw new NotImplementedException();
        }

        public List<DominioTangerine.Empleado> ListarEmpleados()
        {
            throw new NotImplementedException();
        }

        public DominioTangerine.Empleado GetEmployeeById(int employeeId)
        {
            throw new NotImplementedException();
        }

        public bool CambiarEstatus(int empleadoId)
        {
            throw new NotImplementedException();
        }

        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public Entidad ConsultarXId(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
