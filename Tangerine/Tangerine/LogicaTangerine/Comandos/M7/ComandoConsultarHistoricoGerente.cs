using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoConsultarHistoricoGerente : Comando<List<Entidad>>
    {

        private Entidad _proyecto;


        public Entidad _Proyecto
        {
            get { return _proyecto; }
            set { _proyecto = value; }
        }

        /// <summary>
        /// Constructor de la clase ComandoAgregarProyecto.
        /// </summary>
        /// <param name="proyecto">proyecto de tipo Entidad para ejecutar dentro del comando.</param>
        public ComandoConsultarHistoricoGerente(Entidad proyecto)
        {
            _Proyecto = proyecto;
            
        }

        /// <summary>
        /// Método override para ejecutar el comando
        /// e insertar en la Base de Datos un proyecto.
        /// </summary>
        /// <returns></returns>
        public override List<Entidad> Ejecutar()
        {
            try
            {
                IDaoProyectoEmpleado daoProyectoEmpleado = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyectoEmpleado();
                List<Entidad> gerentes = daoProyectoEmpleado.ConsultarHistoricoGerente(_Proyecto);
                return gerentes;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
