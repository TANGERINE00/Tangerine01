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
using System.Windows.Forms;

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
            try
            {
                //Asignacion de los campos obtenidos de la Vista.
                _upperText = vista.ComboCompania.SelectedItem.Text;
                consonantes = Regex.Replace(_upperText, "(?<!^)[aeuiAEIOU ](?!$)", "").Trim().ToUpper();
                _nombcodigoPropuesta = consonantes + today.ToString("yyMMddhhmmss");
                _descripcion = vista.Descripcion;
                _Tipoduracion = vista.ComboDuracion;
                _duracion = vista.TextoDuracion;
                _fechaI = DateTime.ParseExact(vista.DatePickerUno, "M/dd/yyyy", null);

                string prueba = vista.DatePickerDos;

                _fechaF = DateTime.ParseExact(vista.DatePickerDos, "M/dd/yyyy", null);
                _moneda = vista.TipoCosto.SelectedItem.Text;
                _costo = int.Parse(vista.TextoCosto);
                _acuerdo = vista.FormaPago;
                _estatusW = vista.ComboStatus.SelectedItem.Text;
                _idCompañia = vista.IdCompania;

                if (vista.CantidadCuotas == "")
                {
                    _entregaCant = 0;
                }
                else
                {
                    _entregaCant = Int32.Parse(vista.CantidadCuotas);
                }

                //Creación del Objeto Propuesta.
                Entidad p = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta(_nombcodigoPropuesta, _descripcion,
                _Tipoduracion, _duracion, _acuerdo, _estatusW, _moneda, _entregaCant, _fechaI, _fechaF, _costo, _idCompañia);

                //Creación y Ejecución del Objeto Comando de Agregar Propuesta, se le envia por parámetro el objeto Propuesta 'p'.
                Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarPropuesta(p);
                Confirmacion = comando.Ejecutar();

                /*
                 * El atributo _precondicion recibe un arreglo de strings. ArrPrecondicion es un String que contiene todos los requerimientos
                 * agregados en la vista separados por un ';'.
                 */
                _precondicion = vista.ArrPrecondicion.Split(';');

                //Se recorre el arreglo.
                for (int i = 0; i < _precondicion.Length - 1; i++)
                {
                    int j = i + 1;
                    string codReq = consonantes + "_RF_" + j.ToString();

                    //Debug.Print(_precondicion[i]);

                    //Creación del Objeto Propuesta.
                    Entidad requerimiento = DominioTangerine.Fabrica.FabricaEntidades.ObtenerRequerimiento(
                        codReq, _precondicion[i].ToString(), _nombcodigoPropuesta);

                    //Creación y Ejecución del Objeto Comando de Agregar Propuesta, se le envia por parámetro el objeto requerimiento.
                    Comando<bool> comando2 = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarRequerimiento(requerimiento);
                    comando2.Ejecutar();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error, llene correctamente los campos", "Campos Invalidos", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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

                foreach (Entidad _compania in listaCompanias)
                {
                    if (((DominioTangerine.Entidades.M4.CompaniaM4)_compania).StatusCompania == 1)
                    {
                        itemCompa = new ListItem();
                        itemCompa.Text = ((DominioTangerine.Entidades.M4.CompaniaM4)_compania).NombreCompania;
                        itemCompa.Value = ((DominioTangerine.Entidades.M4.CompaniaM4)_compania).Id.ToString();
                        vista.ComboCompania.Items.Add(itemCompa);
                    }     
                }
            }
            catch (Exception e)
            {
                ///
            }

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
 
        public void llenarVista() 
        {
         cargarCompañias();
         llenarComboTipoCosto();
         llenarComboEstatus();
        }
    }
}