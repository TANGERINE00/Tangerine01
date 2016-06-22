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

namespace Tangerine_Presentador.M4
{
    public class PresentadorAgregarCompania
    {
        IContratoAgregarCompania _vista;
        List<Entidad> Lugares;
        public PresentadorAgregarCompania(IContratoAgregarCompania vista)
        {
            this._vista = vista;
        }

        public void AgregarCompania() 
        {
            int i = 0;
            int _idLugar = 0;
            Comando<List<Entidad>> comando2 = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarLugarXNombreID();
            Lugares = comando2.Ejecutar();
            foreach (Entidad Lugar in Lugares)
            {
                DominioTangerine.Entidades.M4.LugarDireccionM4 lugar2 = (DominioTangerine.Entidades.M4.LugarDireccionM4)Lugar;
                if(i == _vista.inputDireccion1.SelectedIndex)
                    _idLugar = lugar2.LugId;
                i++;
            }

            DominioTangerine.Entidad compania = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaSinId(_vista.inputNombre1.ToString(), _vista.inputRIF1.ToString(), _vista.inputEmail1.ToString(),
                                                                                            _vista.inputTelefono1.ToString(), _vista.inputAcronimo1.ToString(), System.DateTime.Today,
                                                                                            1, int.Parse(_vista.inputPresupuesto1), int.Parse(_vista.inputPlazoPago1), _idLugar);
            Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearAgregarCompania(compania);
            comando.Ejecutar();

        }

        public void CargarLugares() {
            Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarLugarXNombreID();
            Lugares = comando.Ejecutar();
            foreach (Entidad Lugar in Lugares)
            {
                DominioTangerine.Entidades.M4.LugarDireccionM4 lugar2 = (DominioTangerine.Entidades.M4.LugarDireccionM4)Lugar;
                _vista.inputDireccion1.Items.Add(lugar2.LugNombre);
            }
            
        }
    }
}
