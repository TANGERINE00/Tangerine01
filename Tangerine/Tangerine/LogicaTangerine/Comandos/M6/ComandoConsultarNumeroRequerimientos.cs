using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    public class ComandoConsultarNumeroRequerimientos : Comando<int>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ComandoConsultarNumeroRequerimientos()
        {
        }

        /// <summary>
        /// Método para utilizar el metodo ConsultarNumeroRequerimientos en capa de datos.
        /// </summary>
        /// <returns>Retorna numero de requerimientos registrados</returns>
        public override int Ejecutar()
        {
            try
            {
                IDAORequerimiento daoRequerimiento = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAORequerimiento();
                return daoRequerimiento.ConsultarNumeroRequerimientos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}