using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M2;
using DatosTangerine.Fabrica;

namespace LogicaTangerine.Comandos.M2.ComandosDAORol
{
    class ComandoObtenerRolUsuarioPorNombre : Comando<DominioTangerine.Entidad>
    {
        
        public string _nombreoRol;

        /// <summary>
        /// Constructor que recibe un parametro nombre rol
        /// </summary>
        /// <param name="usuario"></param>
        public ComandoObtenerRolUsuarioPorNombre( string nombreRol )
        {
            _nombreoRol = nombreRol;
        }

        /// <summary>
        /// Método para crear la instancia de la clase DaoRol y usar el método Obtener Rol Usuario por nombre
        /// </summary>
        /// <returns>Retorna una instancia del tipo Entidad</returns>
        public override DominioTangerine.Entidad Ejecutar()
        {
            DominioTangerine.Entidad resultado;
            IDAORol rolDAO = FabricaDAOSqlServer.crearDaoRol();
            resultado = rolDAO.ObtenerRolUsuarioPorNombre(_nombreoRol);
            return resultado;
        }
    }
}
