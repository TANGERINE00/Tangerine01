using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO.M3
{
    public interface IDAOClientePotencial : IDao<Entidad, bool, Entidad>
    {
        bool Activar(Entidad parametro);
        bool Desactivar(Entidad parametro);
        bool Promover(Entidad parametro);
        int ConsultarIdUltimoClientePotencial();
    }
}
