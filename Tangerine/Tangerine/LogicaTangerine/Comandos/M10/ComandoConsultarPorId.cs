using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine;
using ExcepcionesTangerine.M10;

namespace LogicaTangerine.Comandos.M10
{
    public class ComandoConsultarPorId : Comando<Entidad>
    {
        private Entidad empleado;

        public Entidad Empleado
        {
            get { return empleado; }
            set { empleado = value; }
        }

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="empleado"></param>
        public ComandoConsultarPorId(Entidad empleado)
        {
            this.empleado = empleado;
        }

        /// <summary>
        /// Metodo para ejecutar el comando
        /// </summary>
        /// <returns></returns>
        public override Entidad Ejecutar()
        {
            try
            {
                IDAOEmpleado daoEmpleado = DatosTangerine.Fabrica.FabricaDAOSqlServer.ConsultarDAOEmpleadoId();
                Entidad daoEmp = daoEmpleado.ConsultarXId(empleado);
                return daoEmp;
            }
            catch (ConsultarEmpleadoException e)
            {
                throw e;
            }
        }
    }
}
