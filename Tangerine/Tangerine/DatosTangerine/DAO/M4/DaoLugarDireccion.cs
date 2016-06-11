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
    }
}
