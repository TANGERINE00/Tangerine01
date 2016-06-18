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

        public void Llenar(List<ClientePotencial> list)
        { // metodo que se usa para recorrer la lista
            try
            {
                foreach (ClientePotencial item in list)
                {
                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTR;
                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + item.NombreClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + item.RifClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + item.EmailClientePotencial.ToString() + ResourceInterfaz.CerrarTD;
                    if (item.Status == 1)
                    {
                        vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + ResourceInterfaz.Activo + item.IdClientePotencial +
                            ResourceInterfaz.CloseSpanAct + ResourceInterfaz.CerrarTD;
                    }
                    if (item.Status == 0)
                    {
                        vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + ResourceInterfaz.Inactivo + item.IdClientePotencial +
                            ResourceInterfaz.CloseSpanInact + ResourceInterfaz.CerrarTD;
                    }
                    if (item.Status == 2)
                    {
                        vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + ResourceInterfaz.Promovido + item.IdClientePotencial +
                            ResourceInterfaz.CloseSpanProm + ResourceInterfaz.CerrarTD;
                    }

                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + item.PresupuestoAnual_inversion.ToString() +
                    ResourceInterfaz.CerrarTD;

                    vista.ClientePotencial.Text += ResourceInterfaz.AbrirTD + ResourceInterfaz.OpenDivRow + ResourceInterfaz.BotonInfo +
                        item.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonModificar + item.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonEliminar + item.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonActiv + item.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonContacto + item.IdClientePotencial + ResourceInterfaz.BotonCerrar +
                        ResourceInterfaz.BotonPromover + item.IdClientePotencial + ResourceInterfaz.BotonCerrar +
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
