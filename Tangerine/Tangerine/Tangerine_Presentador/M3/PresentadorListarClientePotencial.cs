using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M3;
using LogicaTangerine;
using DominioTangerine;
using System.Web;
using ExcepcionesTangerine;

namespace Tangerine_Presentador.M3
{
    public class PresentadorListarClientePotencial
    {
        IContratoListarClientePotencial vista;

        /// <summary>
        /// Constructor d la clase presentador 
        /// </summary>
        /// <param name="vista"></param>
        /// <returns></returns>
        public PresentadorListarClientePotencial(IContratoListarClientePotencial vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método que instancia y ejecuta el comando para consultar a todos los clientes potenciales
        /// </summary>
        /// <returns></returns>
        public void Llenar()
        {
            try
            {
                Comando<List<Entidad>> comando = 
                    LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarTodosClientePotencial();
                List<Entidad> list = comando.Ejecutar();
                foreach (Entidad item in list)
                {
                    DominioTangerine.Entidades.M3.ClientePotencial elCliente = (DominioTangerine.Entidades.M3.ClientePotencial)item;

                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTR;

                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + 
                        elCliente.NombreClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + 
                        elCliente.RifClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + 
                        elCliente.EmailClientePotencial.ToString() + ResourceInterfaz.CerrarTD;

                    if (elCliente.Status == 1)
                    {
                        vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + 
                            ResourceInterfaz.Activo + elCliente.IdClientePotencial +
                            ResourceInterfaz.CloseSpanAct + ResourceInterfaz.CerrarTD;
                    }
                    if (elCliente.Status == 0)
                    {
                        vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + 
                            ResourceInterfaz.Inactivo + elCliente.IdClientePotencial +
                            ResourceInterfaz.CloseSpanInact + ResourceInterfaz.CerrarTD;
                    }
                    if (elCliente.Status == 2)
                    {
                        vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + 
                            ResourceInterfaz.Promovido + elCliente.IdClientePotencial +
                            ResourceInterfaz.CloseSpanProm + ResourceInterfaz.CerrarTD;
                    }

                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + 
                        elCliente.PresupuestoAnual_inversion.ToString() +
                        ResourceInterfaz.CerrarTD;

                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + 
                        ResourceInterfaz.OpenDivRow + ResourceInterfaz.BotonInfo +
                        elCliente.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonModificar + elCliente.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonEliminar + elCliente.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonActiv + elCliente.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonContacto + elCliente.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonPromover + elCliente.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonSeguimiento+elCliente.IdClientePotencial+ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonAgregar+elCliente.IdClientePotencial+ResourceInterfaz.BotonCerrar+
                        ResourceInterfaz.CloseDiv + ResourceInterfaz.CerrarTD;

                    vista.ClientePotencial.Text += ResourceInterfaz.CerrarTR;


                }

            }
            catch(ExceptionTGConBD ex)
            {
                throw new ExceptionsTangerine("Dal-01", "Error con conexion", ex);
            }
        }
    }
}
