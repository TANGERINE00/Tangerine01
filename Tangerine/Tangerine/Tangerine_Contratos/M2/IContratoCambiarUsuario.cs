using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M2
{
    public interface IContratoCambiarUsuario
    {
        /// <summary>
        /// Encabezado del textBox para la ficha del empleado
        /// </summary>
        string fichaEmpleado
        {
            get;
            set;
        }

        /// <summary>
        /// Encabezado del textbox para el nombre del usuario
        /// </summary>
        string nombreUsuario
        {
            get;
            set;
        }

        /// <summary>
        /// Clase de alerta, para excepciones
        /// </summary>
        string alertaClase
        {
            set;
        }

        /// <summary>
        /// Alerta usuario, para excepciones
        /// </summary>
        string alertaUsuario
        {
            set;
        }

        /// <summary>
        /// Alerta, para excepciones
        /// </summary>
        string alerta
        {
            set;
        }
    }
}
