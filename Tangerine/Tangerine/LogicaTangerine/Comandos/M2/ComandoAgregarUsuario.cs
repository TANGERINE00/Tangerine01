using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.Fabrica;

namespace LogicaTangerine.Comandos.M2
{
    public class ComandoAgregarUsuario : Comando<Boolean>
    {
        /// <summary>
        /// Método para crear la instancia de la clase DaoUsuario para poder usar los respectivos métodos
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override Boolean Ejecutar()
        {
            DAOGeneral Usuario = FabricaDAOSqlServer.crearDaoUsuario();
            return true;
        }
    }
}
