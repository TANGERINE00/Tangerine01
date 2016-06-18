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
    public class PresentadorListarLeads
    {
        IContratoListarLeads vista;

        public PresentadorListarLeads(IContratoListarLeads vista)
        {
            this.vista = vista;
        }

        public void Llenar()
        {
            try
            {
                Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarTodosLeads();
                List<Entidad> list = comando.Ejecutar();
                foreach (Entidad item in list)
                {
                    DominioTangerine.Entidades.M3.ClientePotencial elLead = (DominioTangerine.Entidades.M3.ClientePotencial)item;

                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTR;
                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + elLead.NombreClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + elLead.RifClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + elLead.EmailClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                    if (elLead.Status == 1)
                    {
                        vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + ResourceInterfaz.Activo + elLead.IdClientePotencial +
                            ResourceInterfaz.CloseSpanAct + ResourceInterfaz.CerrarTD;
                    }
                    if (elLead.Status == 0)
                    {
                        vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + ResourceInterfaz.Inactivo + elLead.IdClientePotencial +
                            ResourceInterfaz.CloseSpanInact + ResourceInterfaz.CerrarTD;
                    }
                    if (elLead.Status == 2)
                    {
                        vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + ResourceInterfaz.Promovido + elLead.IdClientePotencial +
                            ResourceInterfaz.CloseSpanProm + ResourceInterfaz.CerrarTD;
                    }

                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + elLead.PresupuestoAnual_inversion.ToString() +
                    ResourceInterfaz.CerrarTD;

                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + ResourceInterfaz.OpenDivRow + ResourceInterfaz.BotonInfo +
                        elLead.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonModificar + elLead.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonEliminar + elLead.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonActiv + elLead.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonContacto + elLead.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonPromover + elLead.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.CloseDiv + ResourceInterfaz.CerrarTD;

                    vista.ClientePotencial.Text += ResourceInterfaz.CerrarTR;


                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
