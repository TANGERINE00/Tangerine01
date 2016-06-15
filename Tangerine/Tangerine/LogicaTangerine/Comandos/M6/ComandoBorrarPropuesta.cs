using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;

namespace LogicaTangerine.Comandos.M6
{
    public class ComandoBorrarPropuesta : Comando<bool>
    {
        public ComandoBorrarPropuesta(Entidad laPropuesta)
        {
            _laEntidad = laPropuesta;
        }

        public override bool Ejecutar()
        {
            try
            {
                IDAOPropuesta daoPropuesta = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDAOPropuesta();
                DominioTangerine.Entidades.M6.Propuesta propuesta = (DominioTangerine.Entidades.M6.Propuesta)_laEntidad;
                return daoPropuesta.BorrarPropuesta(propuesta.Nombre);
            }
            catch (Exception e)
            {
                throw e;
            }
        } 
    }
}
