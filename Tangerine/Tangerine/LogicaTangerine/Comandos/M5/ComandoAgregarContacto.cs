using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaTangerine.Comandos.M5
{
    public class ComandoAgregarContacto : Comando<bool>
    {
        public ComandoAgregarContacto( Entidad contacto ) 
        {
            _laEntidad = contacto;
        }

        public override bool Ejecutar()
        {
            throw new NotImplementedException();
        }
    }
}
