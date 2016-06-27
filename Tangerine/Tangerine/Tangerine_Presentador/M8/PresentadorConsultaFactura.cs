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
using DominioTangerine.Entidades.M4;
using DominioTangerine.Entidades.M7;
using LogicaTangerine.Fabrica;
using DominioTangerine.Fabrica;

namespace Tangerine_Presentador.M8
{
    public class PresentadorConsultaFactura
    {
        IContratoConsultarFactura vista;

        /// <summary>
        /// Constructor de la clase, que recibe la vista
        /// </summary>
        /// <param name="vista"></param>
        public PresentadorConsultaFactura(IContratoConsultarFactura vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método para manejar los errores y mensajes a interfaz
        /// <param name="msj">Mensaje a mostrar a interfaz</param>
        /// Son respuestas positivas sobre acciones del usuario
        /// </summary>
        public void Alerta(string msj)
        {
            if (msj == RecursoPresentadorM8.codigoMod)
            {
                vista.alertaClase = RecursoPresentadorM8.alertaModificado;
                vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                vista.alerta = RecursoPresentadorM8.alertaHtml + RecursoPresentadorM8.MsjModificado 
                    + RecursoPresentadorM8.alertaHtmlFinal;
            }
            if (msj == RecursoPresentadorM8.codigoAnular)
            {
                vista.alertaClase = RecursoPresentadorM8.alertaModificado;
                vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                vista.alerta = RecursoPresentadorM8.alertaHtml + RecursoPresentadorM8.MsjMAnulado 
                    + RecursoPresentadorM8.alertaHtmlFinal;
            }
            if (msj == RecursoPresentadorM8.codigoCorreo)
            {
                vista.alertaClase = RecursoPresentadorM8.alertaModificado;
                vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                vista.alerta = RecursoPresentadorM8.alertaHtml + RecursoPresentadorM8.MsjCorreo 
                    + RecursoPresentadorM8.alertaHtmlFinal;
            }
        }

        /// <summary>
        /// Método para cargar la tabla con las facturas existentes
        /// </summary>
        public void cargarConsultarFacturas()
        {
            bool pagada = false;
            bool anulada = false;
            try
            {
                Comando<List<Entidad>> comando = FabricaComandos.CrearConsultarTodosFactura();
                List<Entidad> listaEntidad = comando.Ejecutar();
                CompaniaM4 _laCompania = (CompaniaM4)FabricaEntidades.CrearCompaniaVacia();
                DominioTangerine.Entidades.M7.Proyecto _elProyecto =
                    (DominioTangerine.Entidades.M7.Proyecto)FabricaEntidades.ObtenerProyecto();

                foreach (Facturacion laFactura in listaEntidad)
                {
                    _laCompania.Id = laFactura.idCompaniaFactura;
                    _elProyecto.Id = laFactura.idProyectoFactura;
                    Comando<Entidad> _comandoCompania = FabricaComandos.CrearConsultarCompania(_laCompania);
                    _laCompania = (CompaniaM4)_comandoCompania.Ejecutar();
                    Comando<Entidad> _comandoProyecto = 
                        FabricaComandos.ObtenerComandoConsultarXIdProyecto(_elProyecto);
                    _elProyecto = (DominioTangerine.Entidades.M7.Proyecto)_comandoProyecto.Ejecutar();

                    vista.facturasCreadas += RecursoPresentadorM8.OpenTr;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + laFactura.Id.ToString()
                        + RecursoPresentadorM8.CloseTd;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + _laCompania.NombreCompania
                        + RecursoPresentadorM8.CloseTd;
                    vista.facturasCreadas += RecursoPresentadorM8.OpenTD + _elProyecto.Nombre
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
                            RecursoPresentadorM8.BotonModifInhabilitado + laFactura.Id.ToString() 
                            + RecursoPresentadorM8.CloseBotonParametro
                            + RecursoPresentadorM8.BotonAnularInhabilitado + laFactura.Id.ToString() 
                            + RecursoPresentadorM8.CloseBotonParametro
                            + RecursoPresentadorM8.BotonPagarInhabilitado + laFactura.Id.ToString() 
                            + RecursoPresentadorM8.CloseBotonParametro
                            + RecursoPresentadorM8.BotonFactura + laFactura.Id.ToString() 
                            + RecursoPresentadorM8.CloseBotonParametro
                            + RecursoPresentadorM8.BotonMail + laFactura.idCompaniaFactura 
                            + RecursoPresentadorM8.CloseBotonParametro;
                    }
                    else
                    {
                        vista.facturasCreadas +=
                            RecursoPresentadorM8.BotonModif + laFactura.Id.ToString() 
                            + RecursoPresentadorM8.CloseBotonParametro
                            + RecursoPresentadorM8.BotonAnular + laFactura.Id.ToString()
                            + RecursoPresentadorM8.CloseBotonParametro
                            + RecursoPresentadorM8.BotonPagar + laFactura.Id.ToString() 
                            + RecursoPresentadorM8.CloseBotonParametro
                            + RecursoPresentadorM8.BotonFactura + laFactura.Id.ToString() 
                            + RecursoPresentadorM8.CloseBotonParametro
                            + RecursoPresentadorM8.BotonMail + laFactura.idCompaniaFactura 
                            + RecursoPresentadorM8.CloseBotonParametro;
                    }
                    vista.facturasCreadas += RecursoPresentadorM8.CloseTd;
                    vista.facturasCreadas += RecursoPresentadorM8.CloseTr;
                    anulada = false;
                    pagada = false;

                }
            }
            catch (ExcepcionesTangerine.ExceptionsTangerine ex)
            {
                vista.alertaClase = RecursoPresentadorM8.alertaError;
                vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                vista.alerta = RecursoPresentadorM8.alertaHtml + ex.Mensaje + ex.Excepcion.InnerException.Message
                    + RecursoPresentadorM8.alertaHtmlFinal;
            }
        }
    }
}