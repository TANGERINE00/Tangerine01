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
                crearCompaniaVacia();
            comp.Id = idComp;
            Comando<List<Entidad>> comandoListaPagos =
                LogicaTangerine.Fabrica.FabricaComandos.ConsultarPagosCompania(comp);

            List<Entidad> listaP = comandoListaPagos.Ejecutar();

            


                if (listaP.Count() < 1)
                {
                    vista.pago += RecursoPresentadorM9.AbrirTD + "No hay pagos asociados" + 
                        RecursoPresentadorM9.CloseTD;
                    vista.pago += RecursoPresentadorM9.AbrirTD + "No hay pagos asociados" + 
                        RecursoPresentadorM9.CloseTD;
                    vista.pago += RecursoPresentadorM9.AbrirTD + "No hay pagos asociados" + 
                        RecursoPresentadorM9.CloseTD;
                    vista.pago += RecursoPresentadorM9.AbrirTD + "No hay pagos asociados" + 
                        RecursoPresentadorM9.CloseTD;
                    vista.pago += RecursoPresentadorM9.AbrirTD + "No hay pagos asociados" + 
                        RecursoPresentadorM9.CloseTD;

                }
                else
                {

                    foreach (DominioTangerine.Entidades.M9.Pago elPago in listaP)
                    {

                        vista.pago += RecursoPresentadorM9.AbrirTR;
                        vista.pago += RecursoPresentadorM9.AbrirTD + elPago.idFactura + 
                            RecursoPresentadorM9.CloseTD;
                        vista.pago += RecursoPresentadorM9.AbrirTD + elPago.fechaPago.ToShortDateString() + 
                            RecursoPresentadorM9.CloseTD;
                        vista.pago += RecursoPresentadorM9.AbrirTD + elPago.montoPago + RecursoPresentadorM9.CloseTD;
                        vista.pago += RecursoPresentadorM9.AbrirTD + elPago.monedaPago + RecursoPresentadorM9.CloseTD;
                        vista.pago += RecursoPresentadorM9.AbrirTD + elPago.codPago + RecursoPresentadorM9.CloseTD;
                        vista.pago += RecursoPresentadorM9.CloseTR;

                    }
                }


            }
           catch (ExcepcionesTangerine.M9.NullArgumentExceptionM9Tangerine ex)
           {
               MessageBox.Show("Error, llene todos los campos", "Campos Vacios", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
           }

           catch (ExcepcionesTangerine.M9.ExceptionDataBaseM9Tangerine ex)
           {
               MessageBox.Show("Error en la conexion a la Base de Datos", "Error de Conexion",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           catch (ExcepcionesTangerine.M9.WrongFormatExceptionM9Tangerine ex)
           {
               MessageBox.Show("Error, Formato Incorrecto en Codigo de Aprobacion", "Formato Incorrecto",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
           catch (Exception ex)
           {
               MessageBox.Show("La operacion no pudo ser completada", "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
           }

        }
        }
}

