using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DominioTangerine
{
    public class Encriptacion
    {
        public string CrearHash(string dato)
        {
            MD5 md5 = MD5.Create();//Se instancia MD5
            byte[] md5Byte = md5.ComputeHash(Encoding.UTF8.GetBytes(dato));//Se aplica md5 al parametro de entrada
            StringBuilder cadena = new StringBuilder();
            for (int i = 0; i < md5Byte.Length; i++)
            {
                cadena.Append(md5Byte[i].ToString("x2"));
            }

            return cadena.ToString();
        }
    }
}
