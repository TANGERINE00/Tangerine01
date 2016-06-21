using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoAgregarProyecto : Comando<bool>
    {

        /// <summary>
        /// Constructor de la clase ComandoAgregarProyecto.
        /// </summary>
        /// <param name="proyecto">proyecto de tipo Entidad para ejecutar dentro del comando.</param>
        public ComandoAgregarProyecto(Entidad proyecto)
        {
            _laEntidad = proyecto;
        }

        /// <summary>
        /// Método override para ejecutar el comando
        /// e insertar en la Base de Datos un proyecto.
        /// </summary>
        /// <returns></returns>
        public override bool Ejecutar()
        {
            try
            {
                IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
                return daoProyecto.Agregar(_laEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
