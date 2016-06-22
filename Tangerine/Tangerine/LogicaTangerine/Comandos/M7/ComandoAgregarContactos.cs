using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoAgregarContactos: Comando<bool>
    {

        /// <summary>
        /// Constructor de la clase ComandoAgregarContacto.
        /// </summary>
        /// <param name="proyecto">proyecto de tipo Entidad para 
        /// obtener la lista de contactos.</param>
        public ComandoAgregarContactos(Entidad proyecto)
        {
            _laEntidad = proyecto;
        }

        /// <summary>
        /// Método override para ejecutar el comando
        /// e insertar en la Base de Datos 
        /// los contactos de un proyecto.
        /// </summary>
        /// <returns></returns>
        public override bool Ejecutar()
        {
            try
            {
                IDaoProyectoContacto daoProyectoCont = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyectoContacto();
                return daoProyectoCont.Agregar(_laEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
