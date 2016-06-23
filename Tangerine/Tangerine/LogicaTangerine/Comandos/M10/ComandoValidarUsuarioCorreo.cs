using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M10;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M10
{
    public class  ComandoValidarUsuarioCorreo : Comando<Entidad>
    {

        private Entidad empleado;

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public Entidad Empleado
        {
            get { return empleado; }
            set { empleado = value; }
        }

        /// <summary>
        /// Metodo para ejecutar el comando
        /// </summary>
        /// <param name="empleado"></param>
        public ComandoValidarUsuarioCorreo(Entidad empleado)
        {
            this.empleado = empleado;
        }

        public override Entidad Ejecutar()
        {
            try
            {
                IDAOEmpleado daoEmpleado = DatosTangerine.Fabrica.FabricaDAOSqlServer.ObtenerUsuarioCorreo();
                Entidad daoEmp = daoEmpleado.ObtenerUsuarioCorreo(empleado);
                return daoEmp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
