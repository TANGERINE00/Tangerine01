using DatosTangerine.InterfazDAO.M5;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.DAO.M5
{
    class DAOContacto : DAOGeneral, IDAOContacto
    {
        public bool Agregar(Entidad contacto)
        {
            return true;
        }

        public bool Eliminar(Entidad contacto)
        {
            return true;
        }

        public bool Modificar(Entidad contacto)
        {
            return true;
        }

        public Entidad ConsultarXId(Entidad contacto)
        {
            return contacto;
        }

        public List<Entidad> ContactosPorCompania(Entidad compania)
        {
            return new List<Entidad>();
        }

        public bool AgregarContactoAProyecto(Entidad contacto, Entidad proyecto)
        {
            return true;
        }

        public List<Entidad> ContactosPorProyecto(Entidad proyecto)
        {
            return new List<Entidad>();
        }

        public bool EliminarContactoDeProyecto(Entidad contacto, Entidad proyecto)
        {
            return true;
        }

        public List<Entidad> ContactosNoPertenecenAProyecto(Entidad proyecto)
        {
            return new List<Entidad>();
        }
    }
}
