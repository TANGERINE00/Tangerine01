using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.InterfazDAO.M5
{
    public interface IDAOContacto : IDao
    {
        /// <summary>
        /// Firma de método Eliminar
        /// </summary>
        /// <param name="contactoEliminar"></param>
        /// <returns></returns>
        bool Eliminar( Entidad contactoEliminar );

        /// <summary>
        /// Firma de método ContactosPorCompania
        /// </summary>
        /// <param name="tipoCompania"></param>
        /// <param name="idCompania"></param>
        /// <returns></returns>
        List<Entidad> ContactosPorCompania( int tipoCompania, int idCompania );

        /// <summary>
        /// Firma de método AgregarConatactoAProyecto
        /// </summary>
        /// <param name="contactoAgregar"></param>
        /// <param name="proyectoAgregar"></param>
        /// <returns></returns>
        bool AgregarContactoAProyecto( Entidad contactoAgregar, Entidad proyectoAgregar );

        /// <summary>
        /// Firma de método ContactoPorProyecto
        /// </summary>
        /// <param name="proyecto"></param>
        /// <returns></returns>
        List<Entidad> ContactosPorProyecto( Entidad proyecto );

        /// <summary>
        /// Firma de método EliminarContactoDeProyecto
        /// </summary>
        /// <param name="contactoEliminar"></param>
        /// <param name="proyectoEliminar"></param>
        /// <returns></returns>
        bool EliminarContactoDeProyecto( Entidad contactoEliminar, Entidad proyectoEliminar );

        /// <summary>
        /// Firma de método ContactosNoPertenecenAProyecto
        /// </summary>
        /// <param name="proyecto"></param>
        /// <returns></returns>
        List<Entidad> ContactosNoPertenecenAProyecto( Entidad proyecto );
    }
}
