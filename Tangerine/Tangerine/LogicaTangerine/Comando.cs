using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace LogicaTangerine
{
    public abstract class Comando<Resultado>
    {
        private Entidad laEntidad;

        public Entidad LaEntidad
        {
            get { return laEntidad; }
            set { laEntidad = value; }
        }
        public abstract Resultado Ejecutar();
    }
}
