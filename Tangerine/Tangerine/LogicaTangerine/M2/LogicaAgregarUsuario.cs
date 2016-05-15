using DatosTangerine.M2;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.M2
{
    public class LogicaAgregarUsuario
    {
        public static bool AgregarUsuario( Usuario usuario ) 
        {
            bool resultado = false;

            resultado = BDUsuario.AgregarUsuario( usuario );

            return resultado;
        }
    }
}
