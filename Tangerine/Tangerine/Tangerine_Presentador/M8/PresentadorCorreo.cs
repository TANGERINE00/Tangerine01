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
    public class PresentadorCorreo
    {
        IContratoCorreo vista;

        public PresentadorCorreo(IContratoCorreo vista)
        {
            this.vista = vista;
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

        public void correofactura()
        {
            try
            {
                Facturacion _laFactura = (Facturacion)FabricaEntidades.ObtenerFacturacion();
                CompaniaM4 compania = (CompaniaM4)FabricaEntidades.CrearCompaniaVacia();
                DominioTangerine.Entidades.M7.Proyecto proyecto =
                    (DominioTangerine.Entidades.M7.Proyecto)FabricaEntidades.ObtenerProyecto();

                _laFactura.Id = int.Parse(this.vista.numero);



                Comando<Entidad> _elComando = FabricaComandos.CrearConsultarXIdFactura(_laFactura);
                _laFactura = (Facturacion)_elComando.Ejecutar();

                //_laFactura.Id = int.Parse(this.vista.numero);

                compania.Id = _laFactura.idCompaniaFactura;
                proyecto.Id = _laFactura.idProyectoFactura;

                Comando<Entidad> _elComando2 = FabricaComandos.CrearConsultarCompania(compania);
                compania = (CompaniaM4)_elComando2.Ejecutar();

                Comando<Entidad> _elComando3 = FabricaComandos.ObtenerComandoConsultarXIdProyecto(proyecto);
                proyecto = (DominioTangerine.Entidades.M7.Proyecto)_elComando3.Ejecutar();



                vista.destinatario = compania.EmailCompania;
                vista.asunto = RecursoPresentadorM8.recordatorio + proyecto.Nombre + RecursoPresentadorM8.punto;
                vista.mensaje = RecursoPresentadorM8.saludos + compania.NombreCompania + RecursoPresentadorM8.blank +
                                RecursoPresentadorM8.recordar + _laFactura.montoFactura.ToString() + " " + _laFactura.tipoMoneda +
                                RecursoPresentadorM8.punto;
                vista.adjunto = String.Empty;



            }
            catch (ExcepcionesTangerine.ExceptionsTangerine ex)
            {
                vista.alertaClase = RecursoPresentadorM8.alertaError;
                vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                vista.alerta = RecursoPresentadorM8.alertaHtml + ex.Mensaje + ex.Excepcion.InnerException.Message
                    + RecursoPresentadorM8.alertaHtmlFinal;
            }
        }

        public bool enviarCorreo()
        {
            try
            {
                DatosCorreo _datosCorreo =
                        (DatosCorreo)FabricaEntidades.ObtenerDatosCorreo(vista.asunto, vista.destinatario, vista.mensaje);

                if (vista.adjunto != String.Empty)
                {
                    _datosCorreo.adjunto = RecursoPresentadorM8.rutaFacturas + vista.adjunto;
                }

                Comando<bool> _comandoCorreo = FabricaComandos.CrearComandoEnviarCorreoGmail(_datosCorreo);

                return _comandoCorreo.Ejecutar(); ;
            }
            catch (ExcepcionesTangerine.ExceptionsTangerine ex)
            {
                vista.alertaClase = RecursoPresentadorM8.alertaError;
                vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                vista.alerta = RecursoPresentadorM8.alertaHtml + ex.Mensaje + ex.Excepcion.InnerException.Message
                    + RecursoPresentadorM8.alertaHtmlFinal;
                return false;
            }
        }
    }
}
