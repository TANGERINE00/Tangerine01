using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M7
{
    class ComandoConsultarEmpleadosXIdProyecto : Comando<List<Entidad>>
    {

        private Entidad _proyecto;

        public Entidad contacto
        {
            get { return _proyecto; }
            set { _proyecto = value; }
        }

        /// <summary>
        /// Constructor de la clase ComandoConsultarContactosXIdProyecto
        /// </summary>
        /// <param name="contacto"> entidad de tipo proyecto </param>
        public ComandoConsultarEmpleadosXIdProyecto(Entidad _proyecto)
        {
            this._proyecto = _proyecto;
        }

        /// <summary>
        /// Método Override para ejecutar el comando
        /// </summary>
        /// <returns>Lista de entidad tipo Contacto</returns>
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoProyectoEmpleado daoProyectoEmpleado = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyectoEmpleado();
                List<Entidad> contactoResult = daoProyectoEmpleado.ObtenerListaEmpleados(_proyecto);
                return contactoResult;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
