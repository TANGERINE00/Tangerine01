using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine;
using DatosTangerine.InterfazDAO.M3;

namespace LogicaTangerine.Comandos.M3
{
    class ComandoAgregarClientePotencial:Comando<bool>
    {
        public ComandoAgregarClientePotencial(Entidad parametro) 
        {
            LaEntidad = parametro;
        }

        public override bool Ejecutar()
        {
            try 
            {
                IDAOClientePotencial daoClientePotencial = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
                return daoClientePotencial.Agregar(this.LaEntidad);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
