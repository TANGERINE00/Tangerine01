using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M3;
using LogicaTangerine;
using DominioTangerine;
using System.Web;

namespace Tangerine_Presentador.M3
{
    public class PresentadorModificarClientePotencial
    {
        IContratoModificarClientePotencial vista;

        public PresentadorModificarClientePotencial(IContratoModificarClientePotencial vista)
        {
            this.vista = vista;
        }

        public void Llenar(int idCliente)
        {
            Entidad _entidad = DominioTangerine.Fabrica.FabricaEntidades.ObtenerClientePotencial();
            _entidad.Id = idCliente;

            Comando<Entidad> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarClientePotencial(_entidad);
            Entidad elClientePotencial = comando.Ejecutar();
            try
            {
                DominioTangerine.Entidades.M3.ClientePotencial elCliente = (DominioTangerine.Entidades.M3.ClientePotencial)elClientePotencial;

                vista.NombreEtiqueta = elCliente.NombreClientePotencial;
                vista.RifEtiqueta = elCliente.RifClientePotencial;
                vista.CorreoElectronico = elCliente.EmailClientePotencial;
                vista.PresupuestoInversion = elCliente.PresupuestoAnual_inversion;
                vista.NumeroLlamadas = elCliente.NumeroLlamadas;
                vista.NumeroVisitas = elCliente.NumeroVisitas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarClientePotencial(int idCliente)
        {
            Entidad _entidad = DominioTangerine.Fabrica.FabricaEntidades.CrearClientePotencial(idCliente,vista.NombreEtiqueta,
                                                                                               vista.RifEtiqueta,vista.CorreoElectronico,
                                                                                               vista.PresupuestoInversion, 
                                                                                               vista.NumeroLlamadas,vista.NumeroVisitas);
            Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoModificarClientePotencial(_entidad);

            vista.AccionSobreBd= comando.Ejecutar() ? true : false;
        }


    }
}
