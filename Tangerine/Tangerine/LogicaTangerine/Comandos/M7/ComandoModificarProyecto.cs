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

                foreach(Entidad trabajador in _trabajadores)
                {
                    Char delimiter = '-';
                    String[] substrings = ((DominioTangerine.Entidades.M7.Empleado)trabajador).Emp_p_nombre.ToString().Split(delimiter);
                    ((DominioTangerine.Entidades.M7.Empleado)trabajador).Id = int.Parse(substrings[0]);
                    IDaoProyectoEmpleado daoProyectoEmpleado2 = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyectoEmpleado();
                    Boolean agregados = daoProyectoEmpleado2.AgregarProyectoEmpleados( _proyecto, trabajador);
                }

                IDaoProyecto daoProyecto = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyecto();
                Boolean modificado = daoProyecto.Modificar(_proyecto);
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

    }
}
