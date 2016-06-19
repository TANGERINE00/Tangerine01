using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M3;
using LogicaTangerine.M3;
using DominioTangerine;
using System.Web;

namespace Tangerine_Presentador.M3
{
    public class PresentadorConsultarClientePotencial
    {
        IContratoConsultarClientePotencial vista;
        
        public PresentadorConsultarClientePotencial(IContratoConsultarClientePotencial vista)
        {
            this.vista = vista;
        }

        public void Llenar(int idCliente)
        {
            LogicaM3 prueba = new LogicaM3();
            int idClientePotencial = idCliente;
            ClientePotencial elClientePotencial = prueba.BuscarClientePotencial(idClientePotencial);
            try
            {
                vista.NombreEtiqueta.Text = elClientePotencial.NombreClientePotencial;
                vista.RIFEtiqueta.Text = elClientePotencial.RifClientePotencial;
                vista.CorreoEtiqueta.Text = elClientePotencial.EmailClientePotencial;
                vista.PresupuestoInicialEtiqueta.Text = elClientePotencial.PresupuestoAnual_inversion.ToString();
                vista.NumLlamadasEtiqueta.Text = elClientePotencial.NumeroLlamadas.ToString();
                vista.NumVisitasEtiqueta.Text = elClientePotencial.NumeroVisitas.ToString();
                if (elClientePotencial.Status == 0)
                {
                    vista.EstatusEtiqueta.Text = ResourceInterfaz.Inactivo + ResourceInterfaz.CloseSpanInact;
                }
                if (elClientePotencial.Status == 1)
                {
                    vista.EstatusEtiqueta.Text = ResourceInterfaz.Activo + ResourceInterfaz.CloseSpanAct;
                }
                if (elClientePotencial.Status == 2)
                {
                    vista.EstatusEtiqueta.Text = ResourceInterfaz.Promovido + ResourceInterfaz.CloseSpanProm;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
