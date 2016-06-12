using DatosTangerine.InterfazDAO.M7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.DAO.M7
{
    public class DaoProyectoContacto : DAOGeneral, IDaoProyectoContacto
    {
        #region IDAO Proyecto Contacto
        public bool ContactProyectoContacto(DominioTangerine.Entidad proyecto)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProyectoContacto(DominioTangerine.Entidad proyecto)
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
