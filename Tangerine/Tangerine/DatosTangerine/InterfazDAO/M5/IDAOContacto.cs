using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.InterfazDAO.M5
{
    interface IDAOContacto
    {
        bool Eliminar(Entidad contacto);

        List<Entidad> ContactosPorCompania(Entidad compania);

        bool AgregarContactoAProyecto(Entidad contacto, Entidad proyecto);

        List<Entidad> ContactosPorProyecto(Entidad proyecto);

        bool EliminarContactoDeProyecto(Entidad contacto, Entidad proyecto);

        List<Entidad> ContactosNoPertenecenAProyecto(Entidad proyecto);
    }
}
