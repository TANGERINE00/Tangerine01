using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M7;
using LogicaTangerine;
using DominioTangerine;
using System.Web;
using DominioTangerine.Entidades.M7;
using DominioTangerine.Fabrica;
using LogicaTangerine.Fabrica;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Tangerine_Presentador.M7
{
    public class PresentadorAgregarProyecto
    {
        

        #region Atributos
        private IContratoAgregarProyecto _vista;
        static DominioTangerine.Entidades.M6.Propuesta propuesta;
        static Entidad entPropuesta;
        static int _idPropuesta = 0;
        static List<Entidad> listaPropuestas;
        static List<Entidad> listaContactos = new List<Entidad>();
        static List<Entidad> listaProgramadores = new List<Entidad>();
        static List<Entidad> contactos = new List<Entidad>();
        static List<Entidad> programadores = new List<Entidad>();
        static DateTime _fechaIni;
        static DateTime _fechaFin;
        static Double _costo;
        #endregion

        /// <summary>
        /// Constructor de la clase PresentadorAgregarProyecto
        /// </summary>
        /// <param name="vista">Atributo para comunicarse con la vista</param>
        public PresentadorAgregarProyecto(IContratoAgregarProyecto vista)
        {
            _vista = vista;
        }

        public bool  Validaciones()
        {
            listaProgramadores.Clear();
            listaContactos.Clear();

                     
            ///Se guarda en una lista el personal responsable seleccionado para el proyecto.
            for (int i = 0; i < _vista.inputPersonal.Items.Count; i++)
            {
                if (_vista.inputPersonal.Items[i].Selected)
                {
                    listaProgramadores.Add(programadores[i]);
                }
            }

            ///Se guarda en una lista los encargados de comunicación seleccionados para el proyecto.
            for (int i = 0; i < _vista.inputEncargado.Items.Count; i++)
            {
                if (_vista.inputEncargado.Items[i].Selected)
                {
                    listaContactos.Add(contactos[i]);
                }
            }

            if ( (listaContactos.Count == 0) || (listaProgramadores.Count == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Método que se ejecuta al hacer click en el botón
        /// agregar proyecto en la vista
        /// </summary>
        public void agregarProyecto()
        {

            if (Validaciones()) {


             _costo = Convert.ToDouble(_vista.Costo);
            ///Se crea un nuevo proyecto con la información de la vista.
            Entidad nuevoProyecto = FabricaEntidades.CrearProyectoConListas(_vista.NombreProyecto,
                                    _vista.CodigoProyecto, _fechaIni, _fechaFin, _costo, propuesta.Descripcion,
                                    "0", "En desarrollo", "", propuesta.Acuerdopago, int.Parse(propuesta.CodigoP),
                                    int.Parse(propuesta.IdCompañia), 1, listaProgramadores, listaContactos);

            ///Se crea un nuevo comando para agregar el proyecto en la base de datos y se ejecuta.
            Comando<bool> comandoBool = FabricaComandos.ObtenerComandoAgregarProyecto(nuevoProyecto);
            comandoBool.Ejecutar();
            Comando<int> comandoIdProyecto = FabricaComandos.ObtenerComandoUltimoIdProyecto();
            int idProyecto = comandoIdProyecto.Ejecutar();

            nuevoProyecto.Id = idProyecto;
            
            //Se crea un nuevo comando para agregar los empleados que trabajaran en el proyecto.
            Comando<bool> comandoEmpleados = FabricaComandos.ObtenerComandoAgregarEmpleados(nuevoProyecto);
            comandoEmpleados.Ejecutar();

            //Se crea un nuevo comando para agregar los contactos en el proyecto.
            Comando<bool> comandoContactos = FabricaComandos.ObtenerComandoAgregarContactos(nuevoProyecto);
            comandoContactos.Ejecutar();
            }

        }

        /// <summary>
        /// Método que se ejecuta al cargar la página
        /// y llena el DropDownList de la vista con todas las propuestas
        /// aprobadas que no están asociadas a un proyecto.
        /// </summary>
        public void CargarPagina()
        {
            _vista.inputPropuesta.Items.Add("Seleccione una propuesta");
            Comando<List<Entidad>> comandoLista = FabricaComandos.ComandoConsultarPropuestaXProyecto();

            listaPropuestas = comandoLista.Ejecutar();

            foreach (Entidad entidad in listaPropuestas)
            {
                DominioTangerine.Entidades.M6.Propuesta propuesta = (DominioTangerine.Entidades.M6.Propuesta)entidad;
                _vista.inputPropuesta.Items.Add(propuesta.Nombre);
            }
        }


        /// <summary>
        /// Método que se ejecuta al seleccionar una propuesta aprobada
        /// carga los gerentes, programadores y contactos de la empresa 
        /// para trabajar en el proyecto asociado a dicha propuesta.
        /// </summary>
        /// <param name="sender"></param>
        public void CargarInformacionPropuesta(object sender)
        {
            {
                ClearItems();

                _idPropuesta = ((DropDownList)sender).SelectedIndex;

                entPropuesta = listaPropuestas[_idPropuesta-1];

                propuesta = (DominioTangerine.Entidades.M6.Propuesta)entPropuesta;
 
                _vista.Costo = propuesta.Costo.ToString();

                Comando<String> comandoGenerarCodigo = FabricaComandos.ObtenerComandoGenerarCodigoProyecto(entPropuesta);
                String codigo = comandoGenerarCodigo.Ejecutar();
                _vista.CodigoProyecto = codigo;

                Entidad _compania = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaVacia();
                ((DominioTangerine.Entidades.M4.CompaniaM4)_compania).Id = Int32.Parse(propuesta.IdCompañia);
                Comando<List<Entidad>> comandoConsultarContacto = 
                                    FabricaComandos.CrearComandoConsultarContactosPorCompania(_compania, 1);
                List<Entidad> listaContacto = comandoConsultarContacto.Ejecutar();

                foreach (Entidad entidad in listaContacto)
                {
                    DominioTangerine.Entidades.M5.ContactoM5 contacto = (DominioTangerine.Entidades.M5.ContactoM5)entidad;
                    _vista.inputEncargado.Items.Add(contacto.Nombre + " " + contacto.Apellido);
                    contactos.Add(entidad);
                }

                Comando<List<Entidad>> comandoConsultarEmpleados = FabricaComandos.ConsultarEmpleados();
                List<Entidad> listaEmpleados = comandoConsultarEmpleados.Ejecutar();

                foreach (Entidad entidad in listaEmpleados)
                {
                    
                    DominioTangerine.Entidades.M10.EmpleadoM10 empleado = (DominioTangerine.Entidades.M10.EmpleadoM10)entidad;

                    if (empleado.jobs.Nombre == "Gerente")
                    {
                        _vista.inputGerente.Items.Add(empleado.emp_p_nombre + " " + empleado.emp_p_apellido);                        
                    }

                    if (empleado.jobs.Nombre == "Programador")
                    {
                        _vista.inputPersonal.Items.Add(empleado.emp_p_nombre + " " + empleado.emp_p_apellido);
                        programadores.Add(entidad);
                    }
                }

            }
        }

        private void ClearItems()
        {
            _vista.inputEncargado.Items.Clear();
            _vista.inputGerente.Items.Clear();
            _vista.inputPersonal.Items.Clear();
            listaProgramadores.Clear();
            listaContactos.Clear();
            programadores.Clear();
            contactos.Clear();

        }

        /// <summary>
        /// Método que hace visible la segunda columna del formulario
        /// para seleccionar el personal que trabajara en el proyecto
        /// y el botón de agregar proyecto.
        /// </summary>
        public void AgregarPersonal()
        {
            
            ///Se capturan los datos de la vista para crear un proyecto.
            _fechaIni = DateTime.ParseExact(_vista.FechaInicio, "dd/MM/yyyy", null);
            _fechaFin = DateTime.ParseExact(_vista.FechaFin, "dd/MM/yyyy", null);

            if (_fechaFin < _fechaIni) 
            {
                MessageBox.Show("Rango de fechas inválido", "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
            else { 
            _vista.btnAgregarPersonal.Enabled = false;
            _vista.columna2.Visible = true;
            _vista.BtnGenerar.Enabled = true;
            }
        }

       
    }


}
