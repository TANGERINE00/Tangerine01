using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;

namespace DatosTangerine.InterfazDAO
{
    public interface IDao
    {
        bool Agregar(DominioTangerine.Entidad parametro);
        bool Modificar(DominioTangerine.Entidad parametro);
        DominioTangerine.Entidad ConsultarXId(DominioTangerine.Entidad parametro);
        List<Entidad> ConsultarTodos();  
    }
}
