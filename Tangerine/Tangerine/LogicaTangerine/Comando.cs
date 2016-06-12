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
       protected Entidad _laEntidad;

       public Comando() { }

       public Comando(Entidad Entidad) {
          this._laEntidad = Entidad;
       
       }
       


        public Entidad LaEntidad
        {
            get { return _laEntidad; }
            set { _laEntidad = value; }
        }
        public abstract Resultado Ejecutar();
    }
}
