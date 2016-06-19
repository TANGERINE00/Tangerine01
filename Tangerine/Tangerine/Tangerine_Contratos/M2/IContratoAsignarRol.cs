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
    }
}
