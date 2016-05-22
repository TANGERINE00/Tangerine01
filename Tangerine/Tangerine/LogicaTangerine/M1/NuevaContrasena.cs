using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LogicaTangerine.M1
{
    class NuevaContrasena
    {
        public string NuevaContrasenaGenerar()
        {
            string nueva;
            char[] caracteres = {
                    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
                    'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 
                    'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 
                    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 
                    '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_'
            };
            char[] identificador = new char[10];
            byte[] numeroAleatorio = new byte[10];

            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            rngCsp.GetBytes(numeroAleatorio);
            for (int idx = 0; idx < identificador.Length; idx++)
            {
                int pos = numeroAleatorio[idx] % caracteres.Length;
                identificador[idx] = caracteres[pos];
            }

            return nueva = new string(identificador);
        }
    }
}
