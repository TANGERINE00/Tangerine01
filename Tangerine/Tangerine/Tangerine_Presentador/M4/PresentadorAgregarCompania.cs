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
        public PresentadorAgregarCompania(IContratoAgregarCompania vista)
        {
            this._vista = vista;
        }

        public void AgregarCompania() 
        {
            
            string _nombre = _vista.inputNombre1;
            string _acronimo = _vista.inputAcronimo1;
            string _rif = _vista.inputRIF1;
            string _email = _vista.inputEmail1;
            string _telefono = _vista.inputTelefono1;
            string _fecha = _vista.Datepicker1;

            //Por defecto se crea la compania HABILITADA.
            int _status = 1;

            int _presupuesto = int.Parse(_vista.inputPresupuesto1);
            int _plazo = int.Parse(_vista.inputPlazoPago1);
           
           // int _direccionId = logica.MatchIdLugar(_vista.inputDireccion1);

            /*Compania company = new Compania(_nombre, _rif, _email, _telefono, _acronimo,
                                            DateTime.ParseExact(_fecha, "MM/dd/yyyy", null), _status, _presupuesto,
                                            _plazo, _direccionId);*/
           // logica.AddNewCompany(company);       
        }

        public void CargarLugares() {
            Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarLugar();
            List<Entidad> Lugares = comando.Ejecutar();
            DropDownList Lugares2 = new DropDownList();
            foreach (Entidad Lugar in Lugares)
            {
                Lugares2.Items.Add(((DominioTangerine.Entidades.M4.LugarDireccionM4)Lugar).LugNombre);
            }
            _vista.inputDireccion1 = Lugares2;
        }
    }
}
