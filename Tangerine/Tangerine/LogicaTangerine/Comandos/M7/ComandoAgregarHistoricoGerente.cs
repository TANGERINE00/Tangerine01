using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoAgregarHistoricoGerente : Comando<bool>
    {

        private Entidad _Proyecto;


        public Entidad _proyecto
        {
            get { return _Proyecto; }
            set { _Proyecto = value; }
        }

        private Entidad _Empleado;


        public Entidad _empleado
        {
            get { return _Empleado; }
            set { _Empleado = value; }
        }

        /// <summary>
        /// Constructor de la clase ComandoAgregarHistoricoGerente.
        /// </summary>
        /// <param name="proyecto">proyecto de tipo Entidad para ejecutar dentro del comando.</param>
        public ComandoAgregarHistoricoGerente(Entidad proyecto, Entidad empleado)
        {

            _proyecto = proyecto;
            _empleado = empleado;
        }

        /// <summary>
        /// Método override para ejecutar el comando
        /// e insertar en la Base de Datos un proyecto.
        /// </summary>
        /// <returns></returns>
        public override bool Ejecutar()
        {
            try
            {
                IDaoProyectoEmpleado daoProyectoEmpleado = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyectoEmpleado();
                return daoProyectoEmpleado.AgregarHistoricoGerente(_proyecto, _empleado);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
