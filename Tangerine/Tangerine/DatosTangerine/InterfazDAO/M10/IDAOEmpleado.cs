using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;


namespace DatosTangerine.InterfazDAO.M10
{
    public interface IDAOEmpleado : IDao<Entidad, Boolean , Entidad>
    {

        bool AddEmpleado(Empleado theEmpleado);
        List<Empleado> ListarEmpleados();
        Empleado GetEmployeeById(int employeeId);
        bool CambiarEstatus(int empleadoId);


    }
}
