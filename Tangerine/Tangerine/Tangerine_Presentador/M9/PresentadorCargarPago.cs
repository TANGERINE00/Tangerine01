using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M9;
using DominioTangerine;
using LogicaTangerine;
using ExcepcionesTangerine.M9;
using System.Windows.Forms;


namespace Tangerine_Presentador.M9
{
    /// <summary>
    /// Constructor del Presentador para implementar en GUI
    /// </summary>
    /// <param name="vista">Interfaz del Contrato con firma de metodos utilizados por el Presentador</param>
    public class PresentadorCargarPago
    {
        IContratoCargarPago vista;

        public PresentadorCargarPago(IContratoCargarPago vista)
        {
            this.vista = vista;
        }
    
       /// <summary>
       /// Metodo para llenar los campos para Agregar un pago
       /// </summary>
       /// <param name="numeroFactura">Entero, representa el Id de la factura que se va a pagar</param>
   public void LlenarPorId (int numeroFactura)
        {

            try
            {
                DominioTangerine.Entidades.M8.Facturacion fact =
                    (DominioTangerine.Entidades.M8.Facturacion)DominioTangerine.Fabrica.FabricaEntidades.
                    ObtenerFacturacion();
                fact.Id = numeroFactura;

            Comando<Entidad> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarXIdFactura(fact);
            Entidad facturaPagar = comando.Ejecutar();

            DominioTangerine.Entidades.M4.CompaniaM4 compania =
                (DominioTangerine.Entidades.M4.CompaniaM4)DominioTangerine.Fabrica.FabricaEntidades.
                CrearCompaniaVacia();

            compania.Id = ((DominioTangerine.Entidades.M8.Facturacion)facturaPagar).idCompaniaFactura;

            Comando<Entidad> comandoCompania = LogicaTangerine.Fabrica.FabricaComandos.
                CrearConsultarCompania(compania);
            Entidad companiaPagar = comandoCompania.Ejecutar();


                vista.cliente = ((DominioTangerine.Entidades.M4.CompaniaM4)companiaPagar).NombreCompania;
                vista.proyecto = ((DominioTangerine.Entidades.M8.Facturacion)facturaPagar).descripcionFactura;
                vista.monto = ((DominioTangerine.Entidades.M8.Facturacion)facturaPagar).montoFactura.ToString();
                vista.moneda = ((DominioTangerine.Entidades.M8.Facturacion)facturaPagar).tipoMoneda;
                vista.numero = ((DominioTangerine.Entidades.M8.Facturacion)facturaPagar).Id.ToString();
            }
            catch (ExcepcionesTangerine.ExceptionsTangerine ex)
            {
                vista.alertaClase = RecursoPresentadorM9.alertaError;
                vista.alertaRol = RecursoPresentadorM9.tipoAlerta;
                vista.alerta = RecursoPresentadorM9.alertaHtml + ex.Mensaje + ex.Excepcion.InnerException.Message
                    + RecursoPresentadorM9.alertaHtmlFinal;

            }

        }

      /// <summary>
      /// Metodo para agregar un pago y cambiar status de una factura
      /// </summary>
       public void AgregarPago()
   {

       try
       {
           int _idFactura = int.Parse(vista.numero.ToString());
           int _monto = int.Parse(vista.monto);
           string _moneda = vista.moneda.ToString();
           string _forma = vista.formPago;
           int _codApro = int.Parse(vista.codAprob);
           DateTime _fecha = DateTime.Today;

           Entidad pago = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPago_M9(_moneda, _monto, _forma,
               _codApro, _fecha, _idFactura);

           LogicaTangerine.Comandos.M9.ComandoAgregarPago comando = LogicaTangerine.Fabrica.FabricaComandos.
               cargarPago(pago);

           comando.Ejecutar();
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
