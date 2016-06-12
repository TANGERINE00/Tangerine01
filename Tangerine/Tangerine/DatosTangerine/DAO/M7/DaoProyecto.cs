using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.DAO.M7
{
    public class DaoProyecto : DAOGeneral, IDaoProyecto
    {
        #region IDAO Proyecto
        public bool DeleteProyecto(Entidad proyecto)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ContactProyectoxAcuerdoPago()
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ContactProyectoPorEmpleado(Entidad empleado)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ContactProyectoPorGerente(Entidad empleado)
        {
            throw new NotImplementedException();
        }

        public Entidad ContactNombrePropuestaId(Entidad proupesta)
        {
            throw new NotImplementedException();
        }

        public int ContactMaxIdProyecto()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IDAO
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
        #endregion
    }
}
