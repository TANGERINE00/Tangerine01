using DatosTangerine;
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

    // Este método agrega tanto Propuestas como sus requerimientos asociados.
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
            //Asignacion de los campos obtenidos de la Vista.
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


            //Creación del Objeto Propuesta.
            DominioTangerine.Entidades.M6.Propuesta p = new DominioTangerine.Entidades.M6.Propuesta(_nombcodigoPropuesta, _descripcion,
            _Tipoduracion, _duracion, _acuerdo, _estatusW, _moneda,_entregaCant, _fechaI, _fechaF, _costo, _idCompañia);
           
            //Creación y Ejecución del Objeto Comando de Agregar Propuesta, se le envia por parámetro el objeto Propuesta 'p'.
            LogicaTangerine.Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarPropuesta(p);
            Confirmacion = comando.Ejecutar();
        
            //El atributo _precondicion recibe un arreglo de strings. ArrPrecondicion es un String que contiene todos los requerimientos
            // agregados en la vista separados por un ';'.
            _precondicion = vista.ArrPrecondicion.Split(';');


            //Se recorre el arreglo.
            for (int i = 0; i < _precondicion.Length - 1; i++)
            {
                int j = i + 1;
                string codReq = consonantes + "_RF_" + j.ToString();
                
                //Debug.Print(_precondicion[i]);
                  
                //Creación del Objeto Propuesta.
                Requerimiento requerimiento = new Requerimiento(codReq, _precondicion[i].ToString(), _nombcodigoPropuesta);


                //Creación y Ejecución del Objeto Comando de Agregar Propuesta, se le envia por parámetro el objeto requerimiento.
                LogicaTangerine.Comando<bool> comando2 = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarRequerimiento(requerimiento);
                comando2.Ejecutar();
            }
        }
    }
}