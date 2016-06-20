using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M8;
using LogicaTangerine;
using DominioTangerine;
using System.Web;

namespace Tangerine_Presentador.M8
{
    public class PresentadorConsultaFactura
    {
        IContratoConsultarFactura vista;

        public PresentadorConsultaFactura(IContratoConsultarFactura vista)
        {
            this.vista = vista;
        }

        public void cargarConsultarFacturas()
        {
            bool pagada = false;
            bool anulada = false;
            try
            {
                Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarTodosFactura();
                List<Entidad> listaEntidad = comando.Ejecutar();
                foreach (Entidad laFactura in listaEntidad)
                {
                    Comando<Entidad> companiaComando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompaniaFactura(laFactura);
                    /*Entidad nombreCompania = companiaComando.Ejecutar();*/


                    vista.facturasCreadas += RecursoPresentadorM8.OpenTr;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + ((DominioTangerine.Entidades.M8.Facturacion)laFactura).Id.ToString() + RecursoPresentadorM8.CloseTd;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + ((DominioTangerine.Entidades.M8.Facturacion)laFactura).idCompaniaFactura.ToString() + RecursoPresentadorM8.CloseTd;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + ((DominioTangerine.Entidades.M8.Facturacion)laFactura).idProyectoFactura.ToString() + RecursoPresentadorM8.CloseTd;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + ((DominioTangerine.Entidades.M8.Facturacion)laFactura).descripcionFactura.ToString() + RecursoPresentadorM8.CloseTd;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + ((DominioTangerine.Entidades.M8.Facturacion)laFactura).fechaFactura.ToString("dd/MM/yyyy") + RecursoPresentadorM8.CloseTd;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + ((DominioTangerine.Entidades.M8.Facturacion)laFactura).tipoMoneda.ToString() + RecursoPresentadorM8.CloseTd;
                    //Equals cero para factura "Por Pagar"
                    if (((DominioTangerine.Entidades.M8.Facturacion)laFactura).estatusFactura.Equals(0))
                    {
                        vista.facturasCreadas += RecursoPresentadorM8.OpenTD + RecursoPresentadorM8.porPagar + RecursoPresentadorM8.CloseTd;

                    }
                    //Equals uno para factura "Pagada"
                    else if (((DominioTangerine.Entidades.M8.Facturacion)laFactura).estatusFactura.Equals(1))
                    {
                        pagada = true;
                        vista.facturasCreadas += RecursoPresentadorM8.OpenTD + RecursoPresentadorM8.pagada + RecursoPresentadorM8.CloseTd;
                    }
                    //Equals dos para factura "Anulada"
                    else if (((DominioTangerine.Entidades.M8.Facturacion)laFactura).estatusFactura.Equals(2))
                    {
                        anulada = true;
                        vista.facturasCreadas += RecursoPresentadorM8.OpenTD + RecursoPresentadorM8.anulada + RecursoPresentadorM8.CloseTd;
                    }

                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + ((DominioTangerine.Entidades.M8.Facturacion)laFactura).tipoMoneda.ToString() + RecursoPresentadorM8.CloseTd;

                    //Acciones de cada contacto
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD;

                    if (pagada == true || anulada == true)
                    {
                        vista.facturasCreadas += RecursoPresentadorM8.BotonModifInhabilitado + ((DominioTangerine.Entidades.M8.Facturacion)laFactura).Id.ToString() + RecursoPresentadorM8.CloseBotonParametro +
                                   RecursoPresentadorM8.BotonAnularInhabilitado + ((DominioTangerine.Entidades.M8.Facturacion)laFactura).Id.ToString() + RecursoPresentadorM8.CloseBotonParametro +
                                   RecursoPresentadorM8.BotonPagarInhabilitado + ((DominioTangerine.Entidades.M8.Facturacion)laFactura).Id.ToString() + RecursoPresentadorM8.CloseBotonParametro;

                        vista.facturasCreadas += RecursoPresentadorM8.CloseTd;
                        vista.facturasCreadas += RecursoPresentadorM8.CloseTr;
                    }
                    else
                    {
                        vista.facturasCreadas += RecursoPresentadorM8.BotonModif + ((DominioTangerine.Entidades.M8.Facturacion)laFactura).Id.ToString() + RecursoPresentadorM8.CloseBotonParametro +
                                RecursoPresentadorM8.BotonAnular + ((DominioTangerine.Entidades.M8.Facturacion)laFactura).Id.ToString() + RecursoPresentadorM8.CloseBotonParametro +
                                RecursoPresentadorM8.BotonPagar + ((DominioTangerine.Entidades.M8.Facturacion)laFactura).Id.ToString() + RecursoPresentadorM8.CloseBotonParametro;

                        vista.facturasCreadas += RecursoPresentadorM8.CloseTd;
                        vista.facturasCreadas += RecursoPresentadorM8.CloseTr;
                    }
                    anulada = false;
                    pagada = false;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}