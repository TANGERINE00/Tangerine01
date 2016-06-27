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
    public class PresentadorSeleccionCompania
    {

        IContratoSeleccionCompania vista;
        private int estado = 0;
        /// <summary>
        /// Constructor del Presentador para implementar en GUI
        /// </summary>
        /// <param name="vista">Interfaz del Contrato con firma de metodos utilizados por el Presentador</param>
        public PresentadorSeleccionCompania (IContratoSeleccionCompania vista)
        {

            this.vista = vista;

        }
        public void Alerta(string msj, int tipoMensaje)
        {
            if (tipoMensaje == 1)
            {
                vista.alertaClase = RecursoPresentadorM9.AlertSuccess;
                vista.alertaRol = RecursoPresentadorM9.tipoAlerta;
                vista.alerta = RecursoPresentadorM9.AlertOpen + msj + RecursoPresentadorM9.AlertClose;
       
            }
            else if (tipoMensaje == 2)
            {
                vista.alertaClase = RecursoPresentadorM9.AlertDanger;
                vista.alertaRol = RecursoPresentadorM9.tipoAlerta;
                vista.alerta = RecursoPresentadorM9.AlertOpen + msj + RecursoPresentadorM9.AlertClose;

            }
         }
 

        public void estadoActual()
        {
            switch(estado)
            {
                case 1:
                Alerta(RecursoPresentadorM9.PagoAgregado, int.Parse(RecursoPresentadorM9.StatusAgregado));
                break;
                case 2:
                Alerta("Error al agregar pago", 2);
                break;


            }
        }
    
        /// <summary>
        /// Metodo para llenar tabla con todas las companias registradas en el sistema
        /// </summary>
        public void LlenarCompanias ()
        {
            Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarTodasCompania();

            List<Entidad> ListComp = comando.Ejecutar();

            try
                {
                    foreach (Entidad theCompany in ListComp)
                    {
                        vista.company += RecursoPresentadorM9.OpenTR;

                        vista.company += RecursoPresentadorM9.AbrirTD + 
                            ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).NombreCompania + 
                            RecursoPresentadorM9.CerrarTD;
                        vista.company += RecursoPresentadorM9.AbrirTD + 
                            ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).AcronimoCompania.ToString() + 
                            RecursoPresentadorM9.CerrarTD;
                        vista.company += RecursoPresentadorM9.AbrirTD + 
                            ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).RifCompania + 
                            RecursoPresentadorM9.CerrarTD;
                        vista.company += RecursoPresentadorM9.AbrirTD + 
                            ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).FechaRegistroCompania.ToShortDateString() + 
                            RecursoPresentadorM9.CerrarTD;
                        if (((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).StatusCompania.Equals(1))
                        {
                            vista.company += RecursoPresentadorM9.AbrirTD + RecursoPresentadorM9.habilitado + 
                                RecursoPresentadorM9.CerrarTD;
                        }
                        else if (((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).StatusCompania.Equals(0))
                        {
                            vista.company += RecursoPresentadorM9.AbrirTD + RecursoPresentadorM9.inhabilitado + 
                                RecursoPresentadorM9.CerrarTD;
                        }

                        //Boton para cargar las facturas asociadas a cada compañia
                            vista.company += RecursoPresentadorM9.boton + 
                                ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).Id + 
                                RecursoPresentadorM9.boton_cerrar_id;

                        //Boton para cargar los pagos asociadas a cada compañia
                            vista.company += RecursoPresentadorM9.BotonPagos + 
                                ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).Id +
                                RecursoPresentadorM9.boton_cerrar_id;
                            vista.company += RecursoPresentadorM9.CerrarTR;
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
    
    public void CargarPagina ()
        {
            estado = vista.StatusAccion();
            estadoActual();
            LlenarCompanias();


        }
    
    
    
    
    
    
    }
}
