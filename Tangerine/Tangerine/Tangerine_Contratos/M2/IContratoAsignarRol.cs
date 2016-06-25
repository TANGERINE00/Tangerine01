using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M2
{
    public interface IContratoAsignarRol
    {
        /// <summary>
        /// Encabezado del textBox de nombre de usuario
        /// </summary>
        string usuario
        {
            get;
            set;
        }

        /// <summary>
        /// Encabezado del comboBox de seleccion de rol
        /// </summary>
        string comboBoxRol
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
        /// Alerta rol, para excepciones
        /// </summary>
        string alertaRol
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
