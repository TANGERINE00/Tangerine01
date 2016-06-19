using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M4;
using LogicaTangerine;
using DominioTangerine;

namespace Tangerine_Presentador.M4
{
    public class PresentadorInformacionCompania
    {
        #region InicializarVista
        IContratoInformacionCompania _vista;
        Entidad _entidad;
        

        public PresentadorInformacionCompania(IContratoInformacionCompania vista)
        {

            this._vista = vista;


        }
        #endregion

        #region CargarInformacionCompania
        public void CargarInformacionCompania(int id) 
        {
            _entidad = DominioTangerine.Fabrica.FabricaEntidades.CrearEntidadCompaniaM4();
            _entidad.Id = id;
            Comando<Entidad> _comandoCompania = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompania(_entidad);
            Entidad _company = _comandoCompania.Ejecutar();
            Comando<Entidad> _comandoLugar = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarLugarXID(_company);
            Entidad _direccion = _comandoLugar.Ejecutar();

            try
            {

                _vista.NombreCompania.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).NombreCompania;
                _vista.Acronimo.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).AcronimoCompania;
                _vista.Direccion.Text = ((DominioTangerine.Entidades.M4.LugarDireccionM4)_direccion).LugNombre;            
                if (((DominioTangerine.Entidades.M4.CompaniaM4)_company).StatusCompania == 1)
                    _vista.Estatus.Text = "Habilitado";
                else
                    _vista.Estatus.Text = "Inhabilitado";
                _vista.Fecha.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).FechaRegistroCompania.ToString();
                _vista.PlazoDePagos.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).PlazoPagoCompania.ToString();
                _vista.RIF.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).RifCompania;
                _vista.Correo.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).EmailCompania;
                _vista.Telefono.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).TelefonoCompania;
                _vista.Presupuesto.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_company).PresupuestoCompania.ToString();

            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
        #endregion
    }
}
