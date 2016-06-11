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
        private Entidad _laEntidad;

        public Entidad LaEntidad
        {
            get { return _laEntidad; }
            set { _laEntidad = value; }
        }
        public abstract Resultado Ejecutar();
    }
}
