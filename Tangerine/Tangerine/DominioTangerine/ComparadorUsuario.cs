using System;
using System.Collections;
using System.Collections.Generic;

namespace DominioTangerine
{
    public class ComparadorUsuario : IComparer<Usuario>
    {
        /// <summary>
        /// Método para comparar usuarios, se usa para ordenar un ListaUsuario
        /// </summary>
        /// <param name="usuario1"></param>
        /// <param name="usuario2"></param>
        /// <returns></returns>
        public int comparacion( Usuario usuario1, Usuario usuario2 ) 
        {
            int _resultado = usuario2.getFechaCreacion().CompareTo( usuario1.getFechaCreacion() );
            
            if( _resultado < 0 )
            {
                return -1;
            }

            return 1;
        }
    }
}
