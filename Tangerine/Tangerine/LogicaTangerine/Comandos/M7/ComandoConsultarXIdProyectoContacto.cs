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

        /// <summary>
        /// Constructor de la clase ComandoConsultarXIdProyectoContacto
        /// </summary>
        /// <param name="contacto"> entidad de tipo contacto </param>
        public ComandoConsultarXIdProyectoContacto(Entidad contacto)
        {
            this.contacto = contacto;
        }

        /// <summary>
        /// Método Override para ejecutar el comando
        /// </summary>
        /// <returns>entidad de tipo contacto</returns>
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
