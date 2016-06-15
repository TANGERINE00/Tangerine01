using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.InterfazDAO.M5
{
    public interface IDAOContacto : IDao<Entidad, bool, Entidad>
    {
        bool Eliminar(Entidad contacto);

        List<Entidad> ContactosPorCompania(int tipoCompania, int idCompania);

        bool AgregarContactoAProyecto(Entidad contacto, Entidad proyecto);

        List<Entidad> ContactosPorProyecto(Entidad proyecto);

        bool EliminarContactoDeProyecto(Entidad contacto, Entidad proyecto);

        List<Entidad> ContactosNoPertenecenAProyecto(Entidad proyecto);
    }
}
