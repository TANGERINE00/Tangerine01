using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M8;
using LogicaTangerine;
using DominioTangerine;
using System.Web;
using DominioTangerine.Entidades.M8;

namespace Tangerine_Presentador.M8
{
    public class PresentadorConsultaFactura
    {
        IContratoConsultarFactura vista;

        public PresentadorConsultaFactura(IContratoConsultarFactura vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método para manejar los errores y mensajes a interfaz
        /// </summary>
        public void Alerta(string msj)
        {
            if (msj == "1")
            {
                vista.alertaClase = RecursoPresentadorM8.alertaModificado;
                vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                vista.alerta = RecursoPresentadorM8.alertaHtml + RecursoPresentadorM8.MsjModificado + RecursoPresentadorM8.alertaHtmlFinal;
            }
            else
            {
                vista.alertaClase = RecursoPresentadorM8.alertaError;
                vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                vista.alerta = RecursoPresentadorM8.alertaHtml + msj + RecursoPresentadorM8.alertaHtmlFinal;
            }
        }

        public void cargarConsultarFacturas()
        {
            bool pagada = false;
            bool anulada = false;
            try
            {
                Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarTodosFactura();
                List<Entidad> listaEntidad = comando.Ejecutar();
                foreach (Facturacion laFactura in listaEntidad)
                {
                    Comando<Entidad> companiaComando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompaniaFactura(laFactura);
                    /*Entidad nombreCompania = companiaComando.Ejecutar();*/


                    vista.facturasCreadas += RecursoPresentadorM8.OpenTr;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + laFactura.Id.ToString() 
                        + RecursoPresentadorM8.CloseTd;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + laFactura.idCompaniaFactura.ToString() 
                        + RecursoPresentadorM8.CloseTd;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + laFactura.idProyectoFactura.ToString() 
                        + RecursoPresentadorM8.CloseTd;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + laFactura.descripcionFactura.ToString() 
                        + RecursoPresentadorM8.CloseTd;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + 
                        laFactura.fechaFactura.ToString(RecursoPresentadorM8.dateTipe) + RecursoPresentadorM8.CloseTd;
                    
                    //Equals cero para factura "Por Pagar"
                    if (laFactura.estatusFactura.Equals(0))
                    {
                        vista.facturasCreadas += RecursoPresentadorM8.OpenTD + RecursoPresentadorM8.porPagar 
                            + RecursoPresentadorM8.CloseTd;

                    }
                    //Equals uno para factura "Pagada"
                    else if (laFactura.estatusFactura.Equals(1))
                    {
                        pagada = true;
                        vista.facturasCreadas += RecursoPresentadorM8.OpenTD + RecursoPresentadorM8.pagada 
                            + RecursoPresentadorM8.CloseTd;
                    }
                    //Equals dos para factura "Anulada"
                    else if (laFactura.estatusFactura.Equals(2))
                    {
                        anulada = true;
                        vista.facturasCreadas += RecursoPresentadorM8.OpenTD + RecursoPresentadorM8.anulada 
                            + RecursoPresentadorM8.CloseTd;
                    }

                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + laFactura.tipoMoneda.ToString() 
                        + RecursoPresentadorM8.CloseTd;

                    //Acciones de cada contacto
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD;

                    if (pagada == true || anulada == true)
                    {
                        vista.facturasCreadas += 
                            RecursoPresentadorM8.BotonModifInhabilitado + laFactura.Id.ToString() + RecursoPresentadorM8.CloseBotonParametro 
                            + RecursoPresentadorM8.BotonAnularInhabilitado + laFactura.Id.ToString() + RecursoPresentadorM8.CloseBotonParametro 
                            + RecursoPresentadorM8.BotonPagarInhabilitado + laFactura.Id.ToString() + RecursoPresentadorM8.CloseBotonParametro 
                            + RecursoPresentadorM8.BotonFactura + laFactura.Id.ToString() + RecursoPresentadorM8.CloseBotonParametro 
                            + RecursoPresentadorM8.BotonMail + laFactura.idCompaniaFactura + RecursoPresentadorM8.CloseBotonParametro; 
                    }
                    else
                    {
                        vista.facturasCreadas += 
                            RecursoPresentadorM8.BotonModif + laFactura.Id.ToString() + RecursoPresentadorM8.CloseBotonParametro 
                            + RecursoPresentadorM8.BotonAnular + laFactura.Id.ToString() + RecursoPresentadorM8.CloseBotonParametro 
                            + RecursoPresentadorM8.BotonPagar + laFactura.Id.ToString() + RecursoPresentadorM8.CloseBotonParametro 
                            + RecursoPresentadorM8.BotonFactura + laFactura.Id.ToString() + RecursoPresentadorM8.CloseBotonParametro 
                            + RecursoPresentadorM8.BotonMail + laFactura.idCompaniaFactura + RecursoPresentadorM8.CloseBotonParametro; 
                    }
                    vista.facturasCreadas += RecursoPresentadorM8.CloseTd;
                    vista.facturasCreadas += RecursoPresentadorM8.CloseTr;
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