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
        public ComandoAgregarSeguimiento(Entidad parametro)
        {
            LaEntidad = parametro;
        }

        public override bool Ejecutar()
        {
            Console.WriteLine("Invoco el DAO");
            return true;
        }
    }
}
