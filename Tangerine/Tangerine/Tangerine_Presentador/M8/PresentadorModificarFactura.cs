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

namespace Tangerine_Presentador.M8
{
    public class PresentadorModificarFactura
    {
        IContratoModificarFactura vista;

        public PresentadorModificarFactura(IContratoModificarFactura vista)
        {
            this.vista = vista;
        }

        /// <summary>
        /// Método para llenar la informacion de la organizacion
        /// </summary>
        public void llenarModificar()
        {
            Facturacion _laFactura = (Facturacion)FabricaEntidades.ObtenerFacturacion();
            CompaniaM4 compania = (CompaniaM4)FabricaEntidades.CrearEntidadCompaniaM4();
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
            vista.textFecha = _laFactura.fechaFactura.ToString("dd/MM/yyyy");
            vista.textDescripcion = _laFactura.descripcionFactura;
            vista.textCliente = compania.NombreCompania;
            vista.textProyecto = proyecto.Nombre;
            vista.textMonto = _laFactura.montoFactura.ToString();
            //_tipoMoneda = _laFactura.tipoMoneda;
            //vista.textTipoMoneda = _tipoMoneda;
            //_montoRestante = int.Parse(_laFactura.montoRestanteFactura.ToString());

        }
    }
}
