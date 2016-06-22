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

        /// <summary>
        /// Constructor de la clase ComandoConsultarContactosXIdProyecto
        /// </summary>
        /// <param name="contacto"> entidad de tipo proyecto </param>
        public ComandoConsultarContactosXIdProyecto(Entidad contacto)
        {
            this.contacto = contacto;
        }

        /// <summary>
        /// Método Override para ejecutar el comando
        /// </summary>
        /// <returns>Lista de entidad tipo Contacto</returns>
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
