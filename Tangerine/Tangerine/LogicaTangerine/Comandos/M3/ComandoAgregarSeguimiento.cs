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
        /// <param name="parametro"></param>
        public ComandoAgregarSeguimiento(Entidad parametro)
        {
            LaEntidad = parametro;
        }

        /// <summary>
        /// Método que ejecuta el comando para agregar un seguimiento a un cliente potencial
        /// </summary>
        /// <param name="contacto"></param>
        public override bool Ejecutar()
        {
            try
            {
                IDAOClientePotencial seguimiento = DatosTangerine.Fabrica.FabricaDAOSqlServer.CrearDaoClientePotencial();
                return seguimiento.AgregarSeguimientoDeCliente(this.LaEntidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
