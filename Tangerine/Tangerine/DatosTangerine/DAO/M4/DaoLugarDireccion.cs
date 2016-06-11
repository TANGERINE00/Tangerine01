using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M4;
using DominioTangerine.Entidades.M4;

namespace DatosTangerine.DAO.M4
{
    public class DaoLugarDireccion : DAOGeneral,IDaoLugarDireccion
    {
       public List<LugarDireccionM4> ConsultCityPlaces()
        {
            return new List<LugarDireccionM4>();
        }

       public bool Agregar(LugarDireccionM4 parametro)
       {
           throw new NotImplementedException();
       }

       public bool Modificar(LugarDireccionM4 parametro)
       {
           throw new NotImplementedException();
       }

       public LugarDireccionM4 ConsultarXId(LugarDireccionM4 parametro)
       {
           throw new NotImplementedException();
       }

       public List<LugarDireccionM4> ConsultarTodos()
       {
           throw new NotImplementedException();
       }
    }
}
