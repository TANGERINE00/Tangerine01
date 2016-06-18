using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M4
{
    public interface IDaoLugarDireccion : IDao<Entidad, Boolean, Entidad>
    {

        List<Entidad> ConsultCityPlaces();

    }
}
