using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M1;
using LogicaTangerine.Comandos.M10;
using DominioTangerine;
using LogicaTangerine;
using System.Globalization;
using DominioTangerine.Entidades.M10;
using ExcepcionesTangerine.M10;
using System.Web;
namespace Tangerine_Presentador.M10
{
    public class PresentadorCrearEmpleado
    {
        private string active = "Activo";
        private IContratoCrearEmpleado Vista;
        Boolean Confirmacion;



        private List<DominioTangerine.Entidades.M10.LugarDireccion> NuevaDireccion()
        {
            List<DominioTangerine.Entidades.M10.LugarDireccion> direccion = new List<DominioTangerine.Entidades.M10.LugarDireccion>();

            direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion(Vista.IcomboPais.SelectedItem.Text.ToString(), "Pais"));
            direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion(Vista.IcomboEstado.SelectedItem.Text.ToString(), "Estado"));
            direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion(Vista.ItextCityAddress, "Ciudad"));
            direccion.Add(new DominioTangerine.Entidades.M10.LugarDireccion(Vista.ItextAddresEspecific, "Direccion"));

            return direccion;
        }
        public PresentadorCrearEmpleado(IContratoCrearEmpleado Vista)
        {
            this.Vista = Vista;
        }

        /// <summary>
        /// Metodo para llenar combo del genero del empleado a agregar
        /// </summary>
        public void LlenarComboEmpleado()
        {
            Vista.IcomboGenero.Items.Insert(0, "Seleccione un Genero");
            Vista.IcomboGenero.Items.Insert(1, "Femenino");
            Vista.IcomboGenero.Items.Insert(2, "Masculino");
            
        }

        /// <summary>
        /// Metodo para llenar combo del nivel de estudio del empleado
        /// </summary>
        public void LlenarComboNivelEstudio()
        {
            Vista.IcomboNivelEstudio.Items.Insert(0, "Seleccione un Nivel");
            Vista.IcomboNivelEstudio.Items.Insert(1, "Bachiller");
            Vista.IcomboNivelEstudio.Items.Insert(2, "Técnico Superior Incompleto");
            Vista.IcomboNivelEstudio.Items.Insert(3, "Técnico Superior");
            Vista.IcomboNivelEstudio.Items.Insert(4, "Universitario Incompleto");
            Vista.IcomboNivelEstudio.Items.Insert(2, "Título Universitario");
        }

        /// <summary>
        /// Metodo para llenar un cargo con los atributos de la vista
        /// </summary>
        /// <returns></returns>
        private CargoM10 jobForEmployee()
        {
            return new CargoM10(Vista.IcomboCargo.SelectedItem.Text.ToString(),
                       DateTime.ParseExact(Vista.ItextDateEmployee, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                       Vista.ItextJobMode, Double.Parse(Vista.ItextSalaryJob));
        }

        /// <summary>
        /// Metodo para obtener pais
        /// </summary>
        public void ObtenerPaises()
        {
            LogicaTangerine.Comandos.M10.ComandoObtenerPais comando =
            (LogicaTangerine.Comandos.M10.ComandoObtenerPais)LogicaTangerine.Fabrica.FabricaComandos.
            ObtenerFabricaPaises();

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("0", "Seleccione un país");

            List<Entidad> listaLugar = comando.Ejecutar();

            foreach (Entidad row in listaLugar)
            {
                DominioTangerine.Entidades.M10.LugarDireccion Pais = (DominioTangerine.Entidades.M10.LugarDireccion)row;
                options.Add(Pais.Id.ToString(), Pais.LugNombre);

            }

            Vista.IcomboPais.DataSource = options;
            Vista.IcomboPais.DataTextField = "value";
            Vista.IcomboPais.DataValueField = "key";
            Vista.IcomboPais.DataBind();
        }

        /// <summary>
        /// Metodo para obtener cargos a asignar al empleado que se esta agregando
        /// </summary>
        public void ObtenerCargos()
        {
            LogicaTangerine.Comandos.M10.ComandoObtenerCargo comando =
            (LogicaTangerine.Comandos.M10.ComandoObtenerCargo)LogicaTangerine.Fabrica.FabricaComandos.
            ObtenerFabricaCargo();

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("0", "Seleccione un cargo");

            List<Entidad> listaCargo = comando.Ejecutar();

            foreach (Entidad row in listaCargo)
            {
                DominioTangerine.Entidades.M10.CargoM10 Cargo = (DominioTangerine.Entidades.M10.CargoM10)row;
                options.Add(Cargo.Car_id.ToString(), Cargo.Nombre);

            }

            Vista.IcomboCargo.DataSource = options;
            Vista.IcomboCargo.DataTextField = "value";
            Vista.IcomboCargo.DataValueField = "key";
            Vista.IcomboCargo.DataBind();

        }

        /// <summary>
        /// Metodo para la seleccion del pais con los combos anidados de estado segun pais seleccionado
        /// </summary>
        public void SelectedPaisChanged()
        {
            string country = Vista.IcomboPais.SelectedItem.Text;
            Entidad Parametro = DominioTangerine.Fabrica.FabricaEntidades.ObtenerEstadoM10();
            ((DominioTangerine.Entidades.M10.LugarDireccion)Parametro).LugNombre = Vista.IcomboPais.SelectedItem.Text;

            Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerFabricaEstado(Parametro);

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("0", "Seleccione un estado");

            List<Entidad> listaEstado = comando.Ejecutar();

            foreach (Entidad row in listaEstado)
            {
                DominioTangerine.Entidades.M10.LugarDireccion Pais = 
                (DominioTangerine.Entidades.M10.LugarDireccion)row;
                options.Add(Pais.Id.ToString(), Pais.LugNombre);
            }

            Vista.IcomboEstado.DataSource = options;
            Vista.IcomboEstado.DataTextField = "value";
            Vista.IcomboEstado.DataValueField = "key";
            Vista.IcomboEstado.DataBind();

        }

        /// <summary>
        /// Metodo para la accion del agregar empleado 
        /// </summary>
        public void AgregarEmpleado()
        {
       
            try
            {
                Entidad Parametro = DominioTangerine.Fabrica.FabricaEntidades.AgregarEmpledoM10();

                ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_p_nombre = Vista.ItextFirstName;
                ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_s_nombre = Vista.ItextSecondNamee;
                ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_p_apellido = Vista.ItextFirstLastName;
                ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_s_apellido = Vista.ItextSecondLastName;
                ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_genero = Vista.IcomboGenero.SelectedItem.Text.ToString();
                ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_cedula = int.Parse(Vista.ItextCedula);
                ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_fecha_nac = DateTime.ParseExact(Vista.ItextDateEmployee, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_activo = active;
                ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_nivel_estudio = Vista.IcomboNivelEstudio.SelectedItem.Text.ToString();
                ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_email = Vista.ItextEmailPerson;
                ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Jobs = jobForEmployee();
                ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_telefono = Vista.ItextPhonePerson;
                ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).ListaDireccion = NuevaDireccion();


            //Creación y Ejecución del Objeto Comando de Agregar Empleado.
            LogicaTangerine.Comando<bool> comando = LogicaTangerine.Fabrica.FabricaComandos.ComandoAgregarEmpleado(Parametro);
            Confirmacion = comando.Ejecutar();

            HttpContext.Current.Response.Redirect("../M1/EmpleadosAdmin.aspx?EmployeeId=1");
               

            }

            catch (AgregarEmpleadoException ex)
            {
                HttpContext.Current.Response.Redirect("../M1/EmpleadosAdmin.aspx?EmployeeId=3");
               
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect("../M1/EmpleadosAdmin.aspx?EmployeeId=2");

            }
        }
    }
}
