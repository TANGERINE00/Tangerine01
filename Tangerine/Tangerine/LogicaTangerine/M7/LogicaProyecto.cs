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
        
        /// <summary>
        /// Metodo que agrega o crea nuevos proyectos
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Empleados"></param>
        /// <param name="Contacto"></param>
        public Boolean agregarProyecto (Proyecto P, int [] Empleados )
        {

            BDProyecto Pro = new BDProyecto();
           if ( Pro.AddProyecto(P) )
           {
               return true;
           }
           else
           {
               return false; 
           }
           
        }





    }
}
