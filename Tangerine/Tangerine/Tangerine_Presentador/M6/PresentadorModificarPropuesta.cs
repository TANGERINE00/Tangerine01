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
using System.Diagnostics;


namespace Tangerine_Presentador.M6
{
   public class PresentadorModificarPropuesta
    {
        IContratoModificarPropuesta vista;

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
        Boolean Confirmacion;
        DominioTangerine.Entidades.M6.Propuesta lapropuesta;
        public List<DominioTangerine.Entidades.M6.Requerimiento> req;
       string requerimiento;
        
        
        public PresentadorModificarPropuesta (IContratoModificarPropuesta vista)
        {
            this.vista = vista;  
        }

        public void ModificarPropuesta()
        {

            _nombcodigoPropuesta = vista.ContenedorCompania;
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
            _Tipoduracion, _duracion, _acuerdo, _estatusW, _moneda, _entregaCant, _fechaI, _fechaF, _costo, _idCompañia);

            //Creación y Ejecución del Objeto Comando de Modificar Propuesta, se le envia por parámetro el objeto Propuesta 'p'.
            LogicaTangerine.Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoModificarPropuesta(p);
            Confirmacion = comando.Ejecutar();
          //  ModificarRequerimiento();
        }
        
        private void llenarComboDuracion()
        {
            vista.ComboDuracion.Items.Add("Meses");
            vista.ComboDuracion.Items.Add("Dias");
            vista.ComboDuracion.Items.Add("Horas");
        }


        private void llenarComboTipoCosto()
        {
            vista.TipoCosto.Items.Add("Bolivar");
            vista.TipoCosto.Items.Add("Dolar");
            vista.TipoCosto.Items.Add("Euro");
            vista.TipoCosto.Items.Add("Bitcoin");
        }


        private void llenarComboEstatus()
        {
            vista.ComboStatus.Items.Add("Pendiente");
            vista.ComboStatus.Items.Add("Aprobado");
            vista.ComboStatus.Items.Add("Cerrado");

        }

        private void llenarComboCuota()
        {
            vista.ComboCuota.Items.Add("");
            vista.ComboCuota.Items.Add("1");
            vista.ComboCuota.Items.Add("2");
            vista.ComboCuota.Items.Add("3");
            vista.ComboCuota.Items.Add("4");

        }

        private void llenarComboFpago()
        {
            vista.FormaPago.Items.Add("Mensual");
            vista.FormaPago.Items.Add("Por cuotas");


        }
        public void imprimirRequerimientos(Entidad _propuesta)
        {
            List<Entidad> _requerimientos;
            Comando<List<Entidad>> cmdConsultarRequerimientos = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarRequerimientoXPropuesta(_propuesta);

            _requerimientos = cmdConsultarRequerimientos.Ejecutar();

            foreach (Entidad _elRequerimiento in _requerimientos)
            {
                
                vista.Requerimientos.Text += RecursosPresentadorPropuesta.AbrirTR;

                vista.Requerimientos.Text += RecursosPresentadorPropuesta.AbrirTD + ((DominioTangerine.Entidades.M6.Requerimiento)_elRequerimiento).CodigoRequerimiento.ToString() + RecursosPresentadorPropuesta.CerrarTD;
                vista.Requerimientos.Text += RecursosPresentadorPropuesta.AbrirTD + ((DominioTangerine.Entidades.M6.Requerimiento)_elRequerimiento).Descripcion.ToString() + RecursosPresentadorPropuesta.CerrarTD;

                vista.Requerimientos.Text += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.btn_Modificar + RecursosPresentadorPropuesta.CerrarTD;
                vista.Requerimientos.Text += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.btn_eliminar + RecursosPresentadorPropuesta.CerrarTD;

                vista.Requerimientos.Text += RecursosPresentadorPropuesta.CerrarTR;
            }
        }


       public void ModificarRequerimiento(String idRequerimiento, String descripcion, String idPropuesta)
        {
            DominioTangerine.Entidades.M6.Requerimiento elRequerimiento = new DominioTangerine.Entidades.M6.Requerimiento(idRequerimiento,descripcion,idPropuesta);
           
            elRequerimiento.Id = int.Parse(idRequerimiento);
       
           //Creación y Ejecución del Objeto Comando de Modificar Requerimiento, se le envia por parámetro el objeto Propuesta 'p'.
            LogicaTangerine.Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoModificarRequerimiento(elRequerimiento);
            Confirmacion = comando.Ejecutar();
        
        }

       public void llenarDatosPropuesta(Entidad propuesta)
       {
           vista.Descripcion = ((DominioTangerine.Entidades.M6.Propuesta)propuesta).Descripcion;
           
           vista.ComboDuracion.Text = ((DominioTangerine.Entidades.M6.Propuesta)propuesta).TipoDuracion;
           vista.TextoDuracion = ((DominioTangerine.Entidades.M6.Propuesta)propuesta).CantDuracion;

           vista.TipoCosto.Text = ((DominioTangerine.Entidades.M6.Propuesta)propuesta).Moneda;
           vista.TextoCosto = (((DominioTangerine.Entidades.M6.Propuesta)propuesta).Costo).ToString() ;

           vista.FormaPago.Text =  ((DominioTangerine.Entidades.M6.Propuesta)propuesta).Acuerdopago;
           vista.DatePickerUno = (((DominioTangerine.Entidades.M6.Propuesta)propuesta).Feincio).ToString();
           vista.DatePickerDos = (((DominioTangerine.Entidades.M6.Propuesta)propuesta).Fefinal).ToString();
       }

           public void TraerCompania(String idPropuesta)
        {
            //Creo una propuesta
            Entidad propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta(idPropuesta, _descripcion,
            _Tipoduracion, _duracion, _acuerdo, _estatusW, _moneda, _entregaCant, _fechaI, _fechaF, _costo, _idCompañia);
            LogicaTangerine.Comando<Entidad> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarXIdPropuesta(propuesta);
            //Consulto la propuesta
            propuesta = (DominioTangerine.Entidades.M6.Propuesta)comando.Ejecutar();
           
            Entidad compañia = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(int.Parse(((DominioTangerine.Entidades.M6.Propuesta)propuesta).IdCompañia), null, null, null, null, null, DateTime.Now, 0, 0, 0, 0);
            //Consulto la compañia de esa propuesta
            comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompania(compañia);
            compañia = comando.Ejecutar();
            //Extraigo el nombre de la compañia y lleno el contenedor
            vista.ContenedorCompania = ((DominioTangerine.Entidades.M4.CompaniaM4)compañia).NombreCompania;
            imprimirRequerimientos(propuesta);
            
            /* Logica Vieja   
          * LogicaPropuesta logicaPropuesta = new LogicaPropuesta();

            Prueba = logicaPropuesta.TraerPropuesta(idPropuesta);

          /*  Compania lacompania = new Compania();

            lacompania = logicacompania.ConsultCompany(Int32.Parse(Prueba.IdCompañia));
            vista.ContenedorCompania = lacompania.NombreCompania;
            */
        }

        public void llenarVista() {

            TraerCompania(vista.IdCompania);
            llenarComboDuracion();
            llenarComboTipoCosto();
            llenarComboEstatus();
            llenarComboCuota();
            llenarComboFpago();

        }
    }
}
