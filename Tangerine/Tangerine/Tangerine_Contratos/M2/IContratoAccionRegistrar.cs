using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M2
{
    public interface IContratoAccionRegistrar
    {
        /// <summary>
        /// Encabezado del comboBox de seleccion de rol
        /// </summary>
        string comboRol
        {
            get;
            set;
        }

        /// <summary>
        /// Encabezado del textBox de la contraseña
        /// </summary>
        string contrasena
        {
            get;
            set;
        }

        /// <summary>
        /// Encabezado del textBox del nombre de usuario
        /// </summary>
        string usuario
        {
            get;
            set;
        }
    }
}
