using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M7;

namespace LogicaTangerine.M7
{
    class LogicaProyecto
    {
        BDProyecto _Pro = new BDProyecto();

        /// <summary>
        /// Metodo que agrega o crea nuevos proyectos
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Empleados"></param>
        /// <param name="Contacto"></param>
        public Boolean agregarProyecto(Proyecto P, int[] Empleados, int[] Contacto)
        {
            if (_Pro.AddProyecto(P))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Metodo para Modificar un Proyecto
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Empleados"></param>
        /// <param name="Contacto"></param>
        /// <returns></returns>
        public Boolean modificarProyecto(Proyecto P, int[] Empleados, int[] Contacto)
        {

            if (_Pro.ChangeProyecto(P))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Metodo para consultar todos los proyectos
        /// </summary>
        /// <returns></returns>
        public List<Proyecto> consultarProyectos() {
            List<Proyecto> pros =  new List<Proyecto>();
            return pros;
        }

    }

}