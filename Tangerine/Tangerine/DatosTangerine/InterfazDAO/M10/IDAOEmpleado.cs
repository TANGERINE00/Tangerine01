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
        
        //List<Entidad> ConsultarXId(Entidad empleado);        

        List<Entidad> ConsultarTodos();
        
        bool CambiarEstatus(int empleadoId);       

    }
}
