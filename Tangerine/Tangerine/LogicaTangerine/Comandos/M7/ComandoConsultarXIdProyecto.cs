using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoConsultarXIdProyecto : Comando<Entidad>
    {
        private Entidad proyecto;

        public Entidad Proyecto
        {
            get { return proyecto; }
            set { proyecto = value; }
        }

        /// <summary>
        /// Constructor de la clase ComandoConsultarXIdProyecto
        /// </summary>
        /// <param name="proyecto"> entidad de tipo proyecto </param>
        public ComandoConsultarXIdProyecto(Entidad proyecto)
        {
            this.proyecto = proyecto;
        }

        /// <summary>
        /// Método Override para ejecutar el comando
        /// </summary>
        /// <returns>entidad tipo proyecto</returns>
        public override Entidad Ejecutar()
        {
            try
            {
                IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
                Entidad proyectoResult = daoProyecto.ConsultarXId(proyecto);
                return proyectoResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
