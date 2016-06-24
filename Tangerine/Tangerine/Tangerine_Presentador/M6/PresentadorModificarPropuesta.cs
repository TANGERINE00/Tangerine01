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
using System.Windows.Forms;


namespace Tangerine_Presentador.M6
{
    public class PresentadorModificarPropuesta
    {
        IContratoModificarPropuesta vista;

        #region Atributos
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
        public List<DominioTangerine.Entidades.M6.Requerimiento> req;
        #endregion

        public PresentadorModificarPropuesta(IContratoModificarPropuesta vista)
        {
            this.vista = vista;
        }


        public void ModificarPropuesta()
        {

            try
            {
                _nombcodigoPropuesta = vista.IdPropuesta;
                _descripcion = vista.Descripcion;
                _Tipoduracion = vista.ComboDuracion;
                _duracion = vista.TextoDuracion;
                _fechaI = DateTime.ParseExact(vista.DatePickerUno, "M/dd/yyyy", null);
                _fechaF = DateTime.ParseExact(vista.DatePickerDos, "M/dd/yyyy", null);
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
                Entidad p = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta(_nombcodigoPropuesta, _descripcion,
                     _Tipoduracion, _duracion, _acuerdo, _estatusW, _moneda, _entregaCant, _fechaI, _fechaF, _costo, _idCompañia);

                //Creación y Ejecución del Objeto Comando de Modificar Propuesta, se le envia por parámetro el objeto Propuesta 'p'.
                Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoModificarPropuesta(p);
                comando.Ejecutar();

                //  ModificarRequerimiento();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en campos de insercion, por favor realice el registro de nuevo.", "Campos Invalidos", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            
        }


        public void llenarDatosPropuesta(Entidad propuesta)
        {
            String[] arreglo;

            vista.Descripcion = ((DominioTangerine.Entidades.M6.Propuesta)propuesta).Descripcion;

            vista.ComboDuracion = ((DominioTangerine.Entidades.M6.Propuesta)propuesta).TipoDuracion;
            
            vista.TextoDuracion = ((DominioTangerine.Entidades.M6.Propuesta)propuesta).CantDuracion;

            vista.TipoCosto = ((DominioTangerine.Entidades.M6.Propuesta)propuesta).Moneda;
            
            vista.TextoCosto = (((DominioTangerine.Entidades.M6.Propuesta)propuesta).Costo).ToString();

            vista.FormaPago = ((DominioTangerine.Entidades.M6.Propuesta)propuesta).Acuerdopago;
            
            arreglo = ((((DominioTangerine.Entidades.M6.Propuesta)propuesta).Feincio).ToString()).Split(' ');
            vista.DatePickerUno = arreglo[0];
            
            arreglo = ((((DominioTangerine.Entidades.M6.Propuesta)propuesta).Fefinal).ToString()).Split(' ');
            vista.DatePickerDos = arreglo[0];

            vista.ComboStatus = ((DominioTangerine.Entidades.M6.Propuesta)propuesta).Estatus;

            vista.ComboCuota = ((DominioTangerine.Entidades.M6.Propuesta)propuesta).Entrega.ToString();
            
            _idCompañia = vista.IdCompania;
        }


        public void imprimirRequerimientos(Entidad _propuesta)
        {
            List<Entidad> _requerimientos;
            Comando<List<Entidad>> cmdConsultarRequerimientos = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarRequerimientoXPropuesta(_propuesta);

            try
            {
                _requerimientos = cmdConsultarRequerimientos.Ejecutar();

                foreach (Entidad _elRequerimiento in _requerimientos)
                {
                    vista.Requerimientos.Text += RecursosPresentadorPropuesta.AbrirTR;

                    vista.Requerimientos.Text += RecursosPresentadorPropuesta.AbrirTD +
                        ((DominioTangerine.Entidades.M6.Requerimiento)_elRequerimiento).CodigoRequerimiento.ToString() +
                        RecursosPresentadorPropuesta.CerrarTD;

                    vista.Requerimientos.Text += RecursosPresentadorPropuesta.AbrirTD +
                        ((DominioTangerine.Entidades.M6.Requerimiento)_elRequerimiento).Descripcion.ToString() +
                        RecursosPresentadorPropuesta.CerrarTD;


                    vista.Requerimientos.Text += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.btn_OModificar +
                       ((DominioTangerine.Entidades.M6.Requerimiento)_elRequerimiento).CodigoRequerimiento.ToString() + RecursosPresentadorPropuesta.intermedioBoton+
                        ((DominioTangerine.Entidades.M6.Requerimiento)_elRequerimiento).CodigoPropuesta.ToString() + RecursosPresentadorPropuesta.botonCerra + 
                        RecursosPresentadorPropuesta.CerrarTD;
                   
                    vista.Requerimientos.Text += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.btn_Oeliminar +
                        RecursosPresentadorPropuesta.botonCerra + RecursosPresentadorPropuesta.CerrarTD; ;

                    vista.Requerimientos.Text += RecursosPresentadorPropuesta.CerrarTR;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error carga de datos, por favor realice el registro de nuevo.", "Error de pagina", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            
        }


        public void ModificarRequerimiento(String idRequerimiento, String descripcion, String idPropuesta)
        {
            try
            {
                DominioTangerine.Entidades.M6.Requerimiento elRequerimiento = new DominioTangerine.Entidades.M6.Requerimiento(idRequerimiento, descripcion, idPropuesta);

                elRequerimiento.Id = int.Parse(idRequerimiento);

                //Creación y Ejecución del Objeto Comando de Modificar Requerimiento, se le envia por parámetro el objeto Propuesta 'p'.
                Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoModificarRequerimiento(elRequerimiento);
                comando.Ejecutar();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error de ejecucion, por favor realice el registro de nuevo.", "Error de pagina", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            

        }


        public void TraerCompania(String idPropuesta)
        {
            try
            {
                //Creo una propuesta
                Entidad propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta(
                    idPropuesta, null, null, null, null, null, null, 0, DateTime.Now, DateTime.Now, 0, null);

                Comando<Entidad> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarXIdPropuesta(propuesta);

                //Consulto la propuesta
                propuesta = comando.Ejecutar();

                Entidad compañia = DominioTangerine.Fabrica.FabricaEntidades.CrearEntidadCompaniaM4Llena(int.Parse(((DominioTangerine.Entidades.M6.Propuesta)propuesta).IdCompañia),
                    null, null, null, null, null, DateTime.Now, 0, 0, 0, 0);

                //Consulto la compañia de esa propuesta
                comando = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompania(compañia);
                compañia = comando.Ejecutar();

                //Extraigo el nombre de la compañia y lleno el contenedor
                vista.ContenedorCompania = ((DominioTangerine.Entidades.M4.CompaniaM4)compañia).NombreCompania;

                imprimirRequerimientos(propuesta);
                llenarDatosPropuesta(propuesta);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error carga de datos, por favor realice el registro de nuevo.", "Error de pagina", MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
            
        }


        public void llenarVista()
        {
            TraerCompania(vista.IdPropuesta);
        }
    
    }
}
