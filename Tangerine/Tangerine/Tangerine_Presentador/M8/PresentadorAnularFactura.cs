﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M8;
using LogicaTangerine;
using DominioTangerine;
using DominioTangerine.Entidades.M8;
using DominioTangerine.Fabrica;
using LogicaTangerine.Fabrica;
using System.Web;

namespace Tangerine_Presentador.M8
{
    public class PresentadorAnularFactura
    {
        IContratoAnularFactura vista;

        /// <summary>
        /// Constructor de la clase, que recibe la vista
        /// </summary>
        /// <param name="vista"></param>
        public PresentadorAnularFactura(IContratoAnularFactura vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Metodo para cargar los datos de la factura a UI
        /// </summary>
        public void cargarFactura()
        {
            try
            {
                Facturacion lafactura = (Facturacion)FabricaEntidades.ObtenerFacturacion();
                lafactura.Id = int.Parse(this.vista.numero);

                Comando<Entidad> comando = FabricaComandos.CrearConsultarXIdFactura(lafactura);
                lafactura = (Facturacion)comando.Ejecutar();

                vista.numero = this.vista.numero;
                vista.fecha = lafactura.fechaFactura.ToString(RecursoPresentadorM8.dateTipe);
                vista.compania = lafactura.idCompaniaFactura.ToString();
                vista.proyecto = lafactura.idProyectoFactura.ToString();
                vista.descripcion = lafactura.descripcionFactura;
                vista.monto = lafactura.montoFactura.ToString();
                vista.moneda = lafactura.tipoMoneda;
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
        /// Metodo para anular la factura
        /// </summary>
        public Boolean anularFactura()
        {
            try
            {
                Facturacion lafactura = (Facturacion)FabricaEntidades.ObtenerFacturacion();
                lafactura.Id = int.Parse(this.vista.numero);
                Comando<bool> comandoAnular = FabricaComandos.CrearAnularFactura(lafactura);
                return comandoAnular.Ejecutar();
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
