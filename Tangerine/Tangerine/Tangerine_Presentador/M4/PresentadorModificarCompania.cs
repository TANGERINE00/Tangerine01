using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using Tangerine_Contratos.M4;
using LogicaTangerine;
using DominioTangerine;
using ExcepcionesTangerine.M4;

namespace Tangerine_Presentador.M4
{
    public class PresentadorModificarCompania
    {
        IContratoAgregarCompania _vista;
        List<Entidad> Lugares;

        /// <summary>
        /// Constructor que permite inicializar la vista dentro del presentador
        /// </summary>
        public PresentadorModificarCompania(IContratoAgregarCompania vista)
        {
            this._vista = vista;
        }

        /// <summary>
        /// Metodo que permite cargar una compania en especifico por pantalla para ser modificada
        /// </summary>

        public Boolean CargarCompania(int id)
        {
            try 
            { 
                CargarLugares();
                Entidad entidad = DominioTangerine.Fabrica.FabricaEntidades.CrearEntidadCompaniaM4();
                entidad.Id = id;
                Comando<Entidad> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompania(entidad);
                entidad = comando.Ejecutar();
                Comando<List<Entidad>> comando2 = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarLugarXNombreID();
                Lugares = comando2.Ejecutar();
                for (int j = 0; j < Lugares.Count; j++)
                    if (((DominioTangerine.Entidades.M4.LugarDireccionM4)Lugares[j]).LugId == ((DominioTangerine.Entidades.M4.CompaniaM4)entidad).IdLugar)
                        _vista.inputDireccion1.SelectedValue = ((DominioTangerine.Entidades.M4.LugarDireccionM4)Lugares[j]).LugNombre;         
                _vista.inputNombre1 = ((DominioTangerine.Entidades.M4.CompaniaM4)entidad).NombreCompania;
                _vista.inputAcronimo1 = ((DominioTangerine.Entidades.M4.CompaniaM4)entidad).AcronimoCompania;
                _vista.inputRIF1 = ((DominioTangerine.Entidades.M4.CompaniaM4)entidad).RifCompania;
                _vista.inputEmail1 = ((DominioTangerine.Entidades.M4.CompaniaM4)entidad).EmailCompania;
                _vista.inputTelefono1 = ((DominioTangerine.Entidades.M4.CompaniaM4)entidad).TelefonoCompania;
                _vista.Datepicker1 = ((DominioTangerine.Entidades.M4.CompaniaM4)entidad).FechaRegistroCompania.ToShortDateString();
                _vista.inputPresupuesto1 = ((DominioTangerine.Entidades.M4.CompaniaM4)entidad).PresupuestoCompania.ToString();
                _vista.inputPlazoPago1 = ((DominioTangerine.Entidades.M4.CompaniaM4)entidad).PlazoPagoCompania.ToString();
                return true;
            }
            catch (ExceptionM4Tangerine ex)
            {
                _vista.msjError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Metodo que permite modificar la compania previamente consultada
        /// </summary>

        public Boolean ModificarCompania(int id) 
        {
            try
            {
               
                int _idLugar = 0;
                Entidad entidad = DominioTangerine.Fabrica.FabricaEntidades.CrearEntidadCompaniaM4();
                entidad.Id = id;
                Comando<Entidad> comando1 = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompania(entidad);
                entidad = comando1.Ejecutar();
                Comando<List<Entidad>> comando2 = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarLugarXNombreID();
                Lugares = comando2.Ejecutar();
                for (int j = 0; j < Lugares.Count; j++)
                    if (j == _vista.inputDireccion1.SelectedIndex)
                        _idLugar = ((DominioTangerine.Entidades.M4.LugarDireccionM4)Lugares[j]).LugId;    
                if (_vista.inputPresupuesto1.Equals(""))
                    _vista.inputPresupuesto1 = "0";
                DominioTangerine.Entidad compania = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(id,_vista.inputNombre1.ToString(), _vista.inputRIF1.ToString(), _vista.inputEmail1.ToString(),
                                                                                                _vista.inputTelefono1.ToString(), _vista.inputAcronimo1.ToString(), System.DateTime.Today,
                                                                                                ((DominioTangerine.Entidades.M4.CompaniaM4)entidad).StatusCompania, int.Parse(_vista.inputPresupuesto1),
                                                                                                int.Parse(_vista.inputPlazoPago1), _idLugar);
                Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearModificarCompania(compania);
                comando.Ejecutar();
                return true;
            }
            catch (ExceptionM4Tangerine ex)
            {
                _vista.msjError = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Metodo que permite cargar los lugares registrados dentro de la base de datos para el comboBox de lugar
        /// </summary>
        public void CargarLugares() {
            Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarLugarXNombreID();
            Lugares = comando.Ejecutar();
            foreach (Entidad Lugar in Lugares)
            {
                _vista.inputDireccion1.Items.Add(((DominioTangerine.Entidades.M4.LugarDireccionM4)Lugar).LugNombre);
            }
            
        }
    }
}
