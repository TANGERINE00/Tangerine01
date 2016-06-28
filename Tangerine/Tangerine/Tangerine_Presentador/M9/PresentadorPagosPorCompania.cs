using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M9;
using LogicaTangerine;
using DominioTangerine;
using System.Windows.Forms;

namespace Tangerine_Presentador.M9
{
    public class PresentadorPagosPorCompania
    {
        IContratoPagosPorCompania vista;

        public PresentadorPagosPorCompania (IContratoPagosPorCompania vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Metodo para llenar la tabla de pagos realizados por una compania 
        /// </summary>
        /// <param name="idComp">Entero, representa el id de la compania que se desea saber historial de pagos</param>
        public void LlenarPagos(int idComp)
        {

           try
            {
            DominioTangerine.Entidades.M4.CompaniaM4 comp =
                (DominioTangerine.Entidades.M4.CompaniaM4)DominioTangerine.Fabrica.FabricaEntidades.
                CrearCompaniaVacia();
            comp.Id = idComp;
            Comando<List<Entidad>> comandoListaPagos =
                LogicaTangerine.Fabrica.FabricaComandos.ConsultarPagosCompania(comp);

            List<Entidad> listaP = comandoListaPagos.Ejecutar();

            


                if (listaP.Count() < 1)
                {
                    vista.pago += RecursoPresentadorM9.AbrirTD + "No hay pagos asociados" + 
                        RecursoPresentadorM9.CerrarTD;
                    vista.pago += RecursoPresentadorM9.AbrirTD + "No hay pagos asociados" + 
                        RecursoPresentadorM9.CerrarTD;
                    vista.pago += RecursoPresentadorM9.AbrirTD + "No hay pagos asociados" + 
                        RecursoPresentadorM9.CerrarTD;
                    vista.pago += RecursoPresentadorM9.AbrirTD + "No hay pagos asociados" + 
                        RecursoPresentadorM9.CerrarTD;
                    vista.pago += RecursoPresentadorM9.AbrirTD + "No hay pagos asociados" + 
                        RecursoPresentadorM9.CerrarTD;

                }
                else
                {

                    foreach (DominioTangerine.Entidades.M9.Pago elPago in listaP)
                    {

                        vista.pago += RecursoPresentadorM9.AbrirTR;
                        vista.pago += RecursoPresentadorM9.AbrirTD + elPago.idFactura + 
                            RecursoPresentadorM9.CerrarTD;
                        vista.pago += RecursoPresentadorM9.AbrirTD + elPago.fechaPago.ToShortDateString() + 
                            RecursoPresentadorM9.CerrarTD;
                        vista.pago += RecursoPresentadorM9.AbrirTD + elPago.montoPago + RecursoPresentadorM9.CerrarTD;
                        vista.pago += RecursoPresentadorM9.AbrirTD + elPago.monedaPago + RecursoPresentadorM9.CerrarTD;
                        vista.pago += RecursoPresentadorM9.AbrirTD + elPago.codPago + RecursoPresentadorM9.CerrarTD;
                        vista.pago += RecursoPresentadorM9.CloseTR;

                    }
                }


            }
           catch (ExcepcionesTangerine.ExceptionsTangerine ex)
           {
               vista.alertaClase = RecursoPresentadorM9.alertaError;
               vista.alertaRol = RecursoPresentadorM9.tipoAlerta;
               vista.alerta = RecursoPresentadorM9.alertaHtml + ex.Mensaje + ex.Excepcion.InnerException.Message
                   + RecursoPresentadorM9.alertaHtmlFinal;

           }

        }
    }
}

