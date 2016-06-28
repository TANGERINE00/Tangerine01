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
    public class PresentadorGenerarFactura
    {
        IContratoGenerarFactura vista;

        public PresentadorGenerarFactura(IContratoGenerarFactura vista)
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

        /// <summary>
        /// Método para llenar los elementos de la factura 
        /// </summary>
        public void llenarGenerar()
        {
            try
            {
                CompaniaM4 compania = (CompaniaM4)FabricaEntidades.CrearCompaniaVacia();

                DominioTangerine.Entidades.M7.Proyecto proyecto =
                    (DominioTangerine.Entidades.M7.Proyecto)FabricaEntidades.ObtenerProyecto();

                compania.Id = int.Parse(this.vista.compania);
                proyecto.Id = int.Parse(this.vista.proyecto);

                Comando<Entidad> elComandoproyecto = FabricaComandos.ObtenerComandoConsultarXIdProyecto(proyecto);
                proyecto = (DominioTangerine.Entidades.M7.Proyecto)elComandoproyecto.Ejecutar();

                Comando<Entidad> elComandocompania = FabricaComandos.CrearConsultarCompania(compania);
                compania = (CompaniaM4)elComandocompania.Ejecutar();

                vista.compania = compania.NombreCompania;
                vista.proyecto = proyecto.Nombre;
                vista.fecha = DateTime.Now.ToString(RecursoPresentadorM8.dateTipe);
                vista.monto = this.vista.monto;
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
        /// Método para llenar los generar la factura 
        /// </summary>
        public void GenerarFactura()
        {
            try
            {
                Facturacion lafactura = (Facturacion)FabricaEntidades.ObtenerFacturacion();
                lafactura.descripcionFactura = vista.descripcion;
                lafactura.idCompaniaFactura = int.Parse(this.vista.compania);
                lafactura.idProyectoFactura = int.Parse(this.vista.proyecto);
                lafactura.fechaFactura = Convert.ToDateTime(this.vista.fecha);
                lafactura.tipoMoneda = this.vista.moneda;
                lafactura.montoFactura = int.Parse(this.vista.monto);
                //lafactura.tipoMoneda;
                Comando<bool> comandoGenerar = FabricaComandos.CrearAgregarFactura(lafactura);
                comandoGenerar.Ejecutar();
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
        /// Método para llenar los generar la factura 
        /// </summary>
        public int UltimaFactura()
        {
            try
            {
                Comando<List<Entidad>> _comandoList;
                Facturacion _laFactura;
                List<Entidad> _listaFactura;

                _comandoList = FabricaComandos.CrearConsultarTodosFactura();
                _listaFactura = _comandoList.Ejecutar();
                _laFactura = (Facturacion)_listaFactura[_listaFactura.Count - 1];
                return _laFactura.Id;
            }
            catch (ExcepcionesTangerine.ExceptionsTangerine ex)
            {
                vista.alertaClase = RecursoPresentadorM8.alertaError;
                vista.alertaRol = RecursoPresentadorM8.tipoAlerta;
                vista.alerta = RecursoPresentadorM8.alertaHtml + ex.Mensaje + ex.Excepcion.InnerException.Message
                    + RecursoPresentadorM8.alertaHtmlFinal;
                return 0;
            }
        }
    }
}
