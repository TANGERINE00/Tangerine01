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
   
    public class PresentadorFacturasPorPagar
    {
        IContratoFacturasPorPagar vista;

        /// <summary>
        /// Constructor del Presentador para implementar en GUI
        /// </summary>
        /// <param name="vista">Interfaz del Contrato con firma de metodos utilizados por el Presentador</param>
        public PresentadorFacturasPorPagar (IContratoFacturasPorPagar vista)
        {
            this.vista = vista;
        }
    
    /// <summary>
    /// Metodo para llenar la tabla de facturas por pagar de una compania determinada
    /// </summary>
    /// <param name="idComp">Entero, es el Id de la empresa que se desea consultar sus facturas por pagar</param>
        public void LlenarFacturas (int idComp)
        {
            //capturo el id de la compania que se esta enviando por el URL
            DominioTangerine.Entidades.M4.CompaniaM4 comp =
                (DominioTangerine.Entidades.M4.CompaniaM4)DominioTangerine.Fabrica.FabricaEntidades.
                CrearCompaniaVacia();
            comp.Id = idComp;
            Comando<List<Entidad>> comandoListaFactura =
                LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarFacturasCompania(comp);

            List<Entidad> listaF = comandoListaFactura.Ejecutar();
            try
            {          
                

                    if (listaF.Count() < 1)
                    {
                        vista.factura += RecursoPresentadorM9.AbrirTR;
                        vista.factura += RecursoPresentadorM9.AbrirTD + "No hay facturas asociadas" + 
                            RecursoPresentadorM9.CloseTD;
                        vista.factura += RecursoPresentadorM9.AbrirTD + "No hay facturas asociadas" + 
                            RecursoPresentadorM9.CloseTD;
                        vista.factura += RecursoPresentadorM9.AbrirTD + "No hay facturas asociadas" + 
                            RecursoPresentadorM9.CloseTD;
                        vista.factura += RecursoPresentadorM9.AbrirTD + "No hay facturas asociadas" + 
                            RecursoPresentadorM9.CloseTD;
                        vista.factura += RecursoPresentadorM9.AbrirTD + "No hay facturas asociadas" + 
                            RecursoPresentadorM9.CloseTD;
                        vista.factura += RecursoPresentadorM9.AbrirTD + "No hay facturas asociadas" + 
                            RecursoPresentadorM9.CloseTD;
                        vista.factura += RecursoPresentadorM9.CerrarTR;
                    }
                    else
                    {

                        foreach (DominioTangerine.Entidades.M8.Facturacion theFactura in listaF)
                        {
                            
                            vista.factura += RecursoPresentadorM9.AbrirTR;
                            vista.factura += RecursoPresentadorM9.AbrirTD + theFactura.Id + 
                                RecursoPresentadorM9.CloseTD;
                            vista.factura += RecursoPresentadorM9.AbrirTD + theFactura.fechaFactura.ToShortDateString()+
                                RecursoPresentadorM9.CloseTD;
                            vista.factura += RecursoPresentadorM9.EtiquetaPorPagar;
                            vista.factura += RecursoPresentadorM9.AbrirTD + theFactura.descripcionFactura + 
                                RecursoPresentadorM9.CloseTD;
                            vista.factura += RecursoPresentadorM9.AbrirTD + theFactura.montoFactura + " " + 
                                theFactura.tipoMoneda + RecursoPresentadorM9.CloseTD;

                            //Boton para cargar el pago de una factura especifica
                            vista.factura += RecursoPresentadorM9.botonPagarAbrir + theFactura.Id + 
                                RecursoPresentadorM9.botonPagarCerrar;
                            vista.factura += RecursoPresentadorM9.CerrarTR;
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
