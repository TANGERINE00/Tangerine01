using DatosTangerine.DAO.M10;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M10
{
    public class ComandoObtenerEstado : Comando<List<Entidad>>
    {
        private Entidad Lugar;


        public ComandoObtenerEstado(Entidad pais)
        {
            this.Lugar = pais;
        }

        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDAOEmpleado daoEmpleado = (DatosTangerine.DAO.M10.DAOEmpleado)DatosTangerine.Fabrica.FabricaDAOSqlServer.ObtenerIDaoEstados();
                return daoEmpleado.ObtenerEstados(Lugar);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
