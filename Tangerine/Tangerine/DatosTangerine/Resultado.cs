using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine
{
    /// <summary>
    /// Clase para el manejo de los resultados de los query's de base de datos
    /// </summary>
    public class Resultado
    {

        public string etiqueta { get; set; }
        public string valor { get; set; }

        /// <summary>
        /// Constructor de Resultado, no deberia existir resultado sin estos parametros
        /// </summary>
        /// <param name="etiqueta">Etiqueta del resultado ejemplo: @Nombre</param>
        /// <param name="valor">Valor del resultado, ejemplo: Pepe</param>
        public Resultado(string etiqueta, string valor)
        {
            this.etiqueta = etiqueta;
            this.valor = valor;
        }
    }
}
