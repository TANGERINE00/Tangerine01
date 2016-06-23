using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine;
using ExcepcionesTangerine.M10;

namespace LogicaTangerine.Comandos.M10
{
    public class ComandoHabilitarEmpleado: Comando<bool>
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="parametro"></param>
        public ComandoHabilitarEmpleado(Entidad parametro)

        {
            LaEntidad=parametro;
        }                                                                                                              
               
        /// <summary>
        /// Metodo para ejecutar el comando
        /// </summary>
        /// <returns></returns>
        public override bool Ejecutar()
        {
            try
            {
                IDAOEmpleado daoEstatus = DatosTangerine.Fabrica.FabricaDAOSqlServer.EstatusDAOEmpleado();
                return daoEstatus.CambiarEstatus(this.LaEntidad);
            }
            catch (ModificarEstatusException e)
            {
                throw e;
            }
        }
    }
}

