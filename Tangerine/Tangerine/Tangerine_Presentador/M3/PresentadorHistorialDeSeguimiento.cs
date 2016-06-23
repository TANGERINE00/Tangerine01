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
    public class PresentadorHistorialDeSeguimiento
    {
        IContratoHistoriaClientePotencial vista;

        public PresentadorHistorialDeSeguimiento(IContratoHistoriaClientePotencial vista)
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

                vista.NombreEtiqueta.Text = elCliente.NombreClientePotencial;
                vista.RIFEtiqueta.Text = elCliente.RifClientePotencial;
                vista.CorreoEtiqueta.Text = elCliente.EmailClientePotencial;
                vista.PresupuestoInicialEtiqueta.Text = elCliente.PresupuestoAnual_inversion.ToString();
                vista.NumLlamadasEtiqueta.Text = elCliente.NumeroLlamadas.ToString();
                vista.NumVisitasEtiqueta.Text = elCliente.NumeroVisitas.ToString();
                if (elCliente.Status == 0)
                {
                    vista.EstatusEtiqueta.Text = ResourceInterfaz.Inactivo + ResourceInterfaz.CloseSpanInact;
                }
                if (elCliente.Status == 1)
                {
                    vista.EstatusEtiqueta.Text = ResourceInterfaz.Activo + ResourceInterfaz.CloseSpanAct;
                }
                if (elCliente.Status == 2)
                {
                    vista.EstatusEtiqueta.Text = ResourceInterfaz.Promovido + ResourceInterfaz.CloseSpanProm;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerHistoricoLlamadas(int idCliente)
        {

            Entidad _entidad = DominioTangerine.Fabrica.FabricaEntidades.CrearSeguimientoXLlamada();
            _entidad.Id = idCliente;

            Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarHistoricoLlamadas(_entidad);
            List<Entidad> HistorialSeguimiento = comando.Ejecutar();

            foreach (Entidad item in HistorialSeguimiento)
            {

                DominioTangerine.Entidades.M3.SeguimientoCliente historico = (DominioTangerine.Entidades.M3.SeguimientoCliente)item;

                vista.SegumientoLLamadas.Text += ResourceInterfaz.AbrirTR;
                vista.SegumientoLLamadas.Text += ResourceInterfaz.AbrirTD + historico.FechaHistoria.ToString() +
                ResourceInterfaz.CerrarTD;

                vista.SegumientoLLamadas.Text += ResourceInterfaz.AbrirTD + historico.MotivoHistoria.ToString() +
                ResourceInterfaz.CerrarTD;

                vista.SegumientoLLamadas.Text += ResourceInterfaz.CerrarTD;
            }
        }

        public void ObtenerHistoricoVisitas(int idCliente)
        {
            Entidad _entidad = DominioTangerine.Fabrica.FabricaEntidades.CrearSeguimientoXVisitas();
            _entidad.Id = idCliente;

            Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerComandoConsultarHistoricoVisitas(_entidad);
            List<Entidad> HistorialSeguimiento = comando.Ejecutar();

            foreach (Entidad item in HistorialSeguimiento)
            {

                DominioTangerine.Entidades.M3.SeguimientoCliente historico = (DominioTangerine.Entidades.M3.SeguimientoCliente)item;

                vista.SeguimientoVisitas.Text += ResourceInterfaz.AbrirTR;
                vista.SeguimientoVisitas.Text += ResourceInterfaz.AbrirTD + historico.FechaHistoria.ToString() +
                ResourceInterfaz.CerrarTD;

                vista.SeguimientoVisitas.Text += ResourceInterfaz.AbrirTD + historico.MotivoHistoria.ToString() +
                ResourceInterfaz.CerrarTD;

                vista.SeguimientoVisitas.Text += ResourceInterfaz.CerrarTD;
            }
        }


   
    }
}
