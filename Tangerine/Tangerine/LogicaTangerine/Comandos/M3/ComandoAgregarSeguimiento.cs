using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine;
using DatosTangerine.InterfazDAO.M3;

namespace LogicaTangerine.Comandos.M3
{
    public class ComandoAgregarSeguimiento:Comando<bool>
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="contacto"></param>
        public ComandoAgregarSeguimiento(Entidad parametro)
        {
            LaEntidad = parametro;
        }

        /// <summary>
        /// Método que ejecuta el comando para agregar un seguimiento
        /// </summary>
        public override bool Ejecutar()
        {
            Console.WriteLine("Invoco el DAO");
            return true;
        }
    }
}
