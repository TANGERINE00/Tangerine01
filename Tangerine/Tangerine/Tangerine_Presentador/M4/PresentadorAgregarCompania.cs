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
    public class PresentadorAgregarCompania
    {
        IContratoAgregarCompania _vista;
        List<Entidad> Lugares;

        /// <summary>
        /// Constructor que permite inicializar la vista dentro del presentador
        /// </summary>
        public PresentadorAgregarCompania(IContratoAgregarCompania vista)
        {
            this._vista = vista;
        }


        /// <summary>
        /// Metodo que permite agregar una compania con los datos ingresados por pantalla
        /// </summary>
        public Boolean AgregarCompania() 
        {
            try
            {
                int _idLugar = 0;
                Comando<List<Entidad>> comando2 = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarLugarXNombreID();
                Lugares = comando2.Ejecutar();
                if (_vista.inputPresupuesto1.Equals(""))
                    _vista.inputPresupuesto1 = "0";
                for (int j = 0; j < Lugares.Count; j++)
                    if (j==_vista.inputDireccion1.SelectedIndex)
                        _idLugar = ((DominioTangerine.Entidades.M4.LugarDireccionM4)Lugares[j]).LugId;         
                DominioTangerine.Entidad compania = DominioTangerine.Fabrica.FabricaEntidades.CrearCompaniaSinId(_vista.inputNombre1.ToString(), _vista.inputRIF1.ToString(), _vista.inputEmail1.ToString(),
                                                                                                _vista.inputTelefono1.ToString(), _vista.inputAcronimo1.ToString(), System.DateTime.Today,
                                                                                                1, int.Parse(_vista.inputPresupuesto1), int.Parse(_vista.inputPlazoPago1), _idLugar);
                Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearAgregarCompania(compania);
                return comando.Ejecutar();  
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
            try
            {
                Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarLugarXNombreID();
                Lugares = comando.Ejecutar();
                foreach (Entidad Lugar in Lugares)
                {
                    _vista.inputDireccion1.Items.Add(((DominioTangerine.Entidades.M4.LugarDireccionM4)Lugar).LugNombre);
                }
            }
            catch (ExceptionM4Tangerine ex) 
            {
                _vista.msjError = ex.Message;
            }
        }
    }
}
