using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoConsultarXIdProyectoContacto : Comando<Entidad>
    {
        private Entidad contacto;

        public Entidad Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        public ComandoConsultarXIdProyectoContacto(Entidad contacto)
        {
            this.contacto = contacto;
        }

        public override Entidad Ejecutar()
        {
            try
            {
                IDaoProyectoContacto daoProyectoContacto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyectoContacto();
                Entidad contactoResult = daoProyectoContacto.ConsultarXId(Contacto);
                return contactoResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
