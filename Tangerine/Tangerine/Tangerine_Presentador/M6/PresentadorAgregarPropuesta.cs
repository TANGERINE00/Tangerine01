using DatosTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M6;
using LogicaTangerine;
using DominioTangerine;
using DominioTangerine.Entidades.M6;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

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
        DateTime today = DateTime.Now;
        String[] _precondicion;

        public PresentadorAgregarPropuesta(IContratoAgregarPropuesta vista)
        {
            this.vista = vista;
        }
        public void agregarPropuesta()
        {
            //Asignacion de los campos obtenidos de la Vista.
            _upperText = vista.ComboCompania.SelectedItem.Text;
            consonantes = Regex.Replace(_upperText, "(?<!^)[aeuiAEIOU](?!$)", "");
            //_nombcodigoPropuesta = consonantes + today.ToString("yyMMddss");
            _nombcodigoPropuesta = today.ToString("yyMMddhhmmss");
            _descripcion = vista.Descripcion;
            _Tipoduracion = vista.ComboDuracion.SelectedItem.Text;
            _duracion = vista.ComboDuracion.SelectedItem.Text;
            _fechaI = DateTime.ParseExact(vista.DatePickerUno, "MM/dd/yyyy", null);
            _fechaF = DateTime.ParseExact(vista.DatePickerDos, "MM/dd/yyyy", null);
            _moneda = vista.TipoCosto.SelectedItem.Text;
            _costo = int.Parse(vista.TextoCosto);
            _acuerdo = vista.FormaPago.SelectedItem.Text;
            _estatusW = vista.ComboStatus.SelectedItem.Text;
            _idCompañia = vista.IdCompania;
          
            try
            {
                _entregaCant = Int32.Parse(vista.ComboCuota.SelectedItem.Text);
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
                string codReq = consonantes.Trim() + "_RF_" + j.ToString();
                
                //Debug.Print(_precondicion[i]);
                  
                //Creación del Objeto Propuesta.
                DominioTangerine.Entidades.M6.Requerimiento requerimiento = new DominioTangerine.Entidades.M6.Requerimiento(codReq, _precondicion[i].ToString(), _nombcodigoPropuesta);


                //Creación y Ejecución del Objeto Comando de Agregar Propuesta, se le envia por parámetro el objeto requerimiento.
                LogicaTangerine.Comando<bool> comando2 = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarRequerimiento(requerimiento);
                comando2.Ejecutar();
            }
        }

         public void cargarCompañias()
        {
            Comando<List<Entidad>> cmdConsultarCompania;


            try
            {
                cmdConsultarCompania = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarTodasCompania(); 
                cmdConsultarCompania.Ejecutar();
                List<Entidad> listaCompanias = cmdConsultarCompania.Ejecutar();
                ListItem itemCompa;

                vista.ComboCompania.Items.Clear();
                itemCompa = new ListItem();
                itemCompa.Text = "Seleccione un Cliente";
                itemCompa.Value = "0";
                vista.ComboCompania.Items.Add(itemCompa);

                foreach (DominioTangerine.Entidades.M4.CompaniaM4 objetoCompa in listaCompanias)
                {
                    itemCompa = new ListItem();
                    itemCompa.Text = objetoCompa.NombreCompania;
                    itemCompa.Value = objetoCompa.Id.ToString();
                    vista.ComboCompania.Items.Add(itemCompa);
                     
                }


            }
            catch (Exception e)
            {
                ///
            }

        }

        public void llenarComboDuracion()
        {
            vista.ComboDuracion.Items.Add("Meses");
            vista.ComboDuracion.Items.Add("Dias");
            vista.ComboDuracion.Items.Add("Horas");
        }
        public void llenarComboTipoCosto()
        {
         
            vista.TipoCosto.Items.Add("Bolivar");
            vista.TipoCosto.Items.Add("Dolar");
            vista.TipoCosto.Items.Add("Euro");
            vista.TipoCosto.Items.Add("Bitcoin");
        }
        public void llenarComboEstatus()
        {
            vista.ComboStatus.Items.Add("Pendiente");
            vista.ComboStatus.Items.Add("Aprobado");
            vista.ComboStatus.Items.Add("Cerrado");
        }
        public void llenarComboCuota()
        {
            vista.ComboCuota.Items.Add("");
            vista.ComboCuota.Items.Add("1");
            vista.ComboCuota.Items.Add("2");
            vista.ComboCuota.Items.Add("3");
            vista.ComboCuota.Items.Add("4");
        }

        public void llenarComboFpago()
        {
            vista.FormaPago.Items.Add("Mensual");
            vista.FormaPago.Items.Add("Por cuotas");
        }
           
        
        public void llenarVista() 
        {
         cargarCompañias();
         llenarComboDuracion();
         llenarComboTipoCosto();
         llenarComboEstatus();
         llenarComboCuota();
         llenarComboFpago();
        
        }
    }
}