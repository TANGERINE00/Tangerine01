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
        
        bool AgregarEmpleado(Empleado elEmpleado);
        
        List<Empleado> ListarEmpleados();

        List<Entidad> ConsultarTodos();
        
        bool CambiarEstatus(int empleadoId);

        List<Entidad> ObtenerPaises();

        List<Entidad> ObtenerCargos();

        List<Entidad> ObtenerEstados(Entidad parametro);


    }
}
