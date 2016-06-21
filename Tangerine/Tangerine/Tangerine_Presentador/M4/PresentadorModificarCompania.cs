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
    public class PresentadorModificarCompania
    {
        IContratoAgregarCompania _vista;
        List<Entidad> Lugares;
        public PresentadorModificarCompania(IContratoAgregarCompania vista)
        {
            this._vista = vista;
        }

        public void CargarCompania(int id)
        {
            CargarLugares();
            Entidad entidad = DominioTangerine.Fabrica.FabricaEntidades.CrearEntidadCompaniaM4();
            entidad.Id = id;
            Comando<Entidad> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompania(entidad);
            entidad = comando.Ejecutar();
            DominioTangerine.Entidades.M4.CompaniaM4 Parametros = (DominioTangerine.Entidades.M4.CompaniaM4)entidad;
            int i = 0;
            Comando<List<Entidad>> comando2 = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarLugarXNombreID();
            Lugares = comando2.Ejecutar();
            foreach (Entidad Lugar in Lugares)
            {
                DominioTangerine.Entidades.M4.LugarDireccionM4 lugar2 = (DominioTangerine.Entidades.M4.LugarDireccionM4)Lugar;
                if (lugar2.LugNombre.Equals(_vista.inputDireccion1.Items[i].Text))
                    _vista.inputDireccion1.SelectedIndex = i;
                i++;
            }
            _vista.inputNombre1 = Parametros.NombreCompania;
            _vista.inputAcronimo1 = Parametros.AcronimoCompania;
            _vista.inputRIF1 = Parametros.RifCompania;
            _vista.inputEmail1 = Parametros.EmailCompania;
            _vista.inputTelefono1 = Parametros.TelefonoCompania;
            _vista.Datepicker1 = Parametros.FechaRegistroCompania.ToShortDateString();
            _vista.inputPresupuesto1 = Parametros.PresupuestoCompania.ToString();
            _vista.inputPlazoPago1 = Parametros.PlazoPagoCompania.ToString();
        }

        public void ModificarCompania(int id) 
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

            DominioTangerine.Entidad compania = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(id,_vista.inputNombre1.ToString(), _vista.inputRIF1.ToString(), _vista.inputEmail1.ToString(),
                                                                                            _vista.inputTelefono1.ToString(), _vista.inputAcronimo1.ToString(), System.DateTime.Today,
                                                                                            1, int.Parse(_vista.inputPresupuesto1), int.Parse(_vista.inputPlazoPago1), _idLugar);
            Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearModificarCompania(compania);
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
