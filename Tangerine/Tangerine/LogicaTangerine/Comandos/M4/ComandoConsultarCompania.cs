using DatosTangerine.DAO;
using DatosTangerine.Fabrica;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M4;
using ExcepcionesTangerine.M4;

namespace LogicaTangerine.Comandos.M4
{
    class ComandoConsultarCompania : Comando <Entidad>
    {
        public ComandoConsultarCompania(Entidad Company)
        {
             _laEntidad = Company;
        }

       /// <summary>
       /// Comando que permite Consultar la infomacion de una compania
       /// </summary>
       /// <returns>una entidad compania </returns>
        public override Entidad Ejecutar()
        {
            try
            {
                IDaoCompania C = FabricaDAOSqlServer.crearDaoCompania();
                return C.ConsultarXId(_laEntidad);
            }
            catch (NotImplementedException e)
            {
                return null;
                throw new ExceptionM4Tangerine("DS-404", "Metodo no implementado", e);
                
            }
        }
    }
}
