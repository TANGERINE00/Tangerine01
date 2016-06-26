using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M4;
using LogicaTangerine;
using DominioTangerine;
using ExcepcionesTangerine.M4;
using ExcepcionesTangerine.M2;

namespace Tangerine_Presentador.M4
{
    public class PresentadorInformacionCompania
    {
        #region InicializarVista
        IContratoInformacionCompania _vista;
        Entidad _entidad;

        /// <summary>
        /// Constructor que permite inicializar la vista dentro del presentador
        /// </summary>

        public PresentadorInformacionCompania(IContratoInformacionCompania vista)
        {

            this._vista = vista;


        }
        #endregion

        #region CargarInformacionCompania

        /// <summary>
        /// Metodo que permite cargar toda la informacion de una compania en especifico por pantalla
        /// </summary>
        public Boolean CargarInformacionCompania(int id)
        {
            try
            {
                _entidad = DominioTangerine.Fabrica.FabricaEntidades.CrearCompaniaVacia();
                _entidad.Id = id;
                Comando<Entidad> _comandoCompania = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompania(_entidad);
                Entidad _company = _comandoCompania.Ejecutar();
                Entidad _lugar = DominioTangerine.Fabrica.FabricaEntidades.crearLugarDireccionConLugar(((DominioTangerine.Entidades.M4.CompaniaM4)_company).IdLugar, "");
                Comando<Entidad> _comandoLugar = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarLugarXID(_lugar);
                _lugar = _comandoLugar.Ejecutar();
                _vista.NombreCompania.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).NombreCompania;
                _vista.Acronimo.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).AcronimoCompania;
                _vista.Direccion.Text = ((DominioTangerine.Entidades.M4.LugarDireccionM4)_lugar).LugNombre;
                if (((DominioTangerine.Entidades.M4.CompaniaM4)_company).StatusCompania == 1)
                    _vista.Estatus.Text = RecursosPresentadorM4.habilitado2;
                else
                    _vista.Estatus.Text = RecursosPresentadorM4.inhabilitado2;
                _vista.Fecha.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).FechaRegistroCompania.ToString();
                _vista.PlazoDePagos.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).PlazoPagoCompania.ToString();
                _vista.RIF.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).RifCompania;
                _vista.Correo.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).EmailCompania;
                _vista.Telefono.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).TelefonoCompania;
                _vista.Presupuesto.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).PresupuestoCompania.ToString();
                return true;
            }
            catch (ExceptionM4Tangerine ex)
            {
                _vista.msjError = ex.Message;
                return false;
            }
            catch (ExceptionM2Tangerine ex)
            {
                _vista.msjError = ex.Message;
                return false;
            }
        }
        #endregion
    }
}
