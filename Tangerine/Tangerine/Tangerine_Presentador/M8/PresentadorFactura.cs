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
using LogicaTangerine.Fabrica;
using DominioTangerine.Fabrica;
using DominioTangerine.Entidades.M4;
using ExcepcionesTangerine;

namespace Tangerine_Presentador.M8
{
    public class PresentadorFactura
    {
        private IContratoFactura vista;
        private int idCompania;
        private int idProyecto;

        public PresentadorFactura(IContratoFactura laVista)
        {
            this.vista = laVista;
        }

        /// <summary>
        /// Método para manejar los errores y mensajes a interfaz
        /// </summary>
        public void Alerta(string msj)
        {
            vista.alertaClase = RecursoPresentadorM8.alertaError;
            vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
            vista.alerta = RecursoPresentadorM8.alertaHtml + msj + RecursoPresentadorM8.alertaHtmlFinal;
        }

        /// <summary>
        /// Método para llenar la informacion de la factura
        /// </summary>
        public void llenarModificar()
        {
            try
            {
                Facturacion _laFactura = (Facturacion)FabricaEntidades.ObtenerFacturacion();
                CompaniaM4 compania = (CompaniaM4)FabricaEntidades.CrearCompaniaVacia();
                DominioTangerine.Entidades.M7.Proyecto proyecto =
                    (DominioTangerine.Entidades.M7.Proyecto)FabricaEntidades.ObtenerProyecto();

                _laFactura.Id = int.Parse(this.vista.textNumeroFactura);

                Comando<Entidad> _elComando = FabricaComandos.CrearConsultarXIdFactura(_laFactura);
                _laFactura = (Facturacion)_elComando.Ejecutar();
                compania.Id = _laFactura.idCompaniaFactura;
                proyecto.Id = _laFactura.idProyectoFactura;


                Comando<Entidad> _elComando3 = FabricaComandos.ObtenerComandoConsultarXIdProyecto(proyecto);
                proyecto = (DominioTangerine.Entidades.M7.Proyecto)_elComando3.Ejecutar();
                Comando<Entidad> _elComando2 = FabricaComandos.CrearConsultarCompania(compania);
                compania = (CompaniaM4)_elComando2.Ejecutar();

                vista.textNumeroFactura = _laFactura.Id.ToString();
                vista.textDescripcion = _laFactura.descripcionFactura;
                vista.textCliente = compania.NombreCompania;
                vista.textProyecto = proyecto.Nombre;
                vista.textFecha = _laFactura.fechaFactura.ToString(RecursoPresentadorM8.TipoFecha);
                vista.textDireccion = compania.TelefonoCompania;
                vista.textRif = compania.RifCompania;

                if (_laFactura.tipoMoneda == RecursoPresentadorM8.dolares)
                {
                    vista.textMonto = _laFactura.montoFactura.ToString() + RecursoPresentadorM8.Dolar;
                    vista.textTipoMoneda = RecursoPresentadorM8.MontoTotal 
                        + _laFactura.montoFactura + RecursoPresentadorM8.Dolar;
                }
                if (_laFactura.tipoMoneda == RecursoPresentadorM8.euros)
                {
                    vista.textMonto = _laFactura.montoFactura.ToString() + RecursoPresentadorM8.Euro;
                    vista.textTipoMoneda = RecursoPresentadorM8.MontoTotal
                        + _laFactura.montoFactura + RecursoPresentadorM8.Euro;
                }
                if (_laFactura.tipoMoneda == RecursoPresentadorM8.bolivares)
                {
                    vista.textMonto = _laFactura.montoFactura.ToString() + RecursoPresentadorM8.BS;
                    vista.textTipoMoneda = RecursoPresentadorM8.MontoTotal
                        + _laFactura.montoFactura + RecursoPresentadorM8.BS;
                }
                idCompania = compania.Id;
                idProyecto = proyecto.Id;
            }
            catch (ExcepcionesTangerine.ExceptionsTangerine ex)
            {
                vista.alertaClase = RecursoPresentadorM8.alertaError;
                vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                vista.alerta = RecursoPresentadorM8.alertaHtml + ex.Mensaje + ex.Excepcion.InnerException.Message
                    + RecursoPresentadorM8.alertaHtmlFinal;
            }
        }

        /// <summary>
        /// Método para llenar la informacion de la factura
        /// </summary>
        public Boolean ModificarFactura()
        {
            return true;
        }

    }
}
