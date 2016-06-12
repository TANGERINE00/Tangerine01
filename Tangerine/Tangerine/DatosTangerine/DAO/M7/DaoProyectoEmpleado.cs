using DatosTangerine.InterfazDAO.M7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.DAO.M7
{
    public class DaoProyectoEmpleado : DAOGeneral, IDaoProyectoEmpleado
    {
        #region IDAO Proyecto Empleado
        public bool ContactProyectoEmpleado(DominioTangerine.Entidad proyecto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProyectoEmpleado(DominioTangerine.Entidad proyecto)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IDAO
        public bool Agregar(DominioTangerine.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(DominioTangerine.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public DominioTangerine.Entidad ConsultarXId(DominioTangerine.Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public List<DominioTangerine.Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
