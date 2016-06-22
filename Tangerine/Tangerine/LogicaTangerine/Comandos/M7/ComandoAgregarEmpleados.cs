using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M7;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M7
{
    public class ComandoAgregarEmpleados : Comando<bool>
    {

        /// <summary>
        /// Constructor de la clase ComandoAgregarEmpleados.
        /// </summary>
        /// <param name="proyecto">proyecto de tipo Entidad para
        /// insertar la lista de empleados.</param>
        public ComandoAgregarEmpleados(Entidad proyecto)
        {
            _laEntidad = proyecto;
        }

        /// <summary>
        /// Método override para ejecutar el comando
        /// e insertar en la Base de Datos 
        /// los empleados de un proyecto.
        /// </summary>
        /// <returns></returns>
        public override bool Ejecutar()
        {
            try
            {
                IDaoProyectoEmpleado daoProyectoEmp = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObetenerDaoProyectoEmpleado();
                return daoProyectoEmp.Agregar(_laEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
