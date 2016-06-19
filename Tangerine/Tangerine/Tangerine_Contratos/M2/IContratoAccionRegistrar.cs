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
        public string comboRol
        {
            get;
            set;
        }

        /// <summary>
        /// Encabezado del textBox de la contraseña
        /// </summary>
        public string contrasena
        {
            get;
            set;
        }

        /// <summary>
        /// Encabezado del textBox del nombre de usuario
        /// </summary>
        public string usuario
        {
            get;
            set;
        }
    }
}
