using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M7
{
    class ComandoConsultarContactosXIdProyecto : Comando<List<Entidad>>
    {
        private Entidad contacto;

        public Entidad Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        public ComandoConsultarContactosXIdProyecto(Entidad contacto)
        {
            this.contacto = contacto;
        }

        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoProyectoContacto daoProyectoContacto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyectoContacto();
                List<Entidad> contactoResult = daoProyectoContacto.ContactCompany(Contacto);
                return contactoResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
