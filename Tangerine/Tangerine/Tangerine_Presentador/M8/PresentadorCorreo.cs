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

        public void correofactura()
        {
            try
            {
                Facturacion _laFactura = (Facturacion)FabricaEntidades.ObtenerFacturacion();
                CompaniaM4 compania = (CompaniaM4)FabricaEntidades.CrearEntidadCompaniaM4();
                DominioTangerine.Entidades.M7.Proyecto proyecto =
                    (DominioTangerine.Entidades.M7.Proyecto)FabricaEntidades.ObtenerProyecto();
                Comando<Entidad> _elComando = FabricaComandos.CrearConsultarXIdFactura(_laFactura);
                _laFactura = (Facturacion)_elComando.Ejecutar();

                _laFactura.Id = int.Parse(this.vista.numero);
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
