using DatosTangerine;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M6;
using LogicaTangerine;
using DominioTangerine.Entidades.M6;
using System.Text.RegularExpressions;

namespace Tangerine_Presentador.M6
{

    public class PresentadorAgregarPropuesta
    {
        IContratoAgregarPropuesta vista;
        Boolean Confirmacion;
        String consonantes;

        string _nombcodigoPropuesta = String.Empty;
        string _idCompañia = String.Empty;
        string _nombrecompañia = String.Empty;
        string _descripcion = String.Empty;
        string _Tipoduracion = String.Empty;
        string _duracion = String.Empty;
        string _upperText = String.Empty;
        DateTime _fechaI;
        DateTime _fechaF;
        string _moneda = String.Empty;
        int _costo = 0;
        string _acuerdo = String.Empty;
        int _entregaCant = 0;
        string _fdepago = String.Empty;
        string _estatusW;
        DateTime today = DateTime.Today;
        String[] _precondicion;

        public PresentadorAgregarPropuesta(IContratoAgregarPropuesta vista)
        {
            this.vista = vista;
        }
        public void agregarPropuesta()
        {
            _upperText = vista.ComboCompania.ToUpper();
            consonantes = Regex.Replace(_upperText, "(?<!^)[aeuiAEIOU](?!$)", "");
            _nombcodigoPropuesta = consonantes + today.ToString("yyMMdd");
            _descripcion = vista.Descripcion;
            _Tipoduracion = vista.ComboDuracion;
            _duracion = vista.ComboDuracion;
            _fechaI = DateTime.ParseExact(vista.DatePickerUno, "MM/dd/yyyy", null);
            _fechaF = DateTime.ParseExact(vista.DatePickerDos, "MM/dd/yyyy", null);
            _moneda = vista.TipoCosto;
            _costo = int.Parse(vista.TextoCosto);
            _acuerdo = vista.FormaPago;
            _estatusW = vista.ComboStatus;
            _idCompañia = vista.IdCompania;
            try
            {
                _entregaCant = Int32.Parse(vista.ComboCuota);
            }
            catch (Exception)
            {
                _entregaCant = 0;
            }
            DominioTangerine.Entidades.M6.Propuesta p = new DominioTangerine.Entidades.M6.Propuesta(_nombcodigoPropuesta, _descripcion, _Tipoduracion, _duracion, _acuerdo, _estatusW, _moneda,
                                                 _entregaCant, _fechaI, _fechaF, _costo, _idCompañia);
            LogicaTangerine.Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarPropuesta(p);
            Confirmacion = comando.Ejecutar();
        }
    }
}