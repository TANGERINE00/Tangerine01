using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoModificarProyecto : Comando<Boolean>
    {
        private Entidad _propuesta;
        private Entidad _proyecto;
        private List<Entidad> _trabajadores;

        public ComandoModificarProyecto(Entidad propuesta, Entidad proyecto, List<Entidad> trabajadores)
        {
             this._propuesta = propuesta;
             this._proyecto = proyecto;
             this._trabajadores = trabajadores;
        }

        public override Boolean Ejecutar()
        {
            try
            {
                IDaoProyectoEmpleado daoProyectoEmpleado = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyectoEmpleado();
                Boolean eliminados = daoProyectoEmpleado.DeleteProyectoEmpleado(_proyecto);

                IDaoProyectoEmpleado daoProyectoEmpleado2 = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyectoEmpleado();
                //Boolean agregados = daoProyectoEmpleado2.AgregarEmpleados(_trabajadores);

                
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

    }
}
