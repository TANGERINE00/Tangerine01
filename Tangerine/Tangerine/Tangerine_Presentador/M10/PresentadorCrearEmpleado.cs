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
namespace Tangerine_Presentador.M10
{
    public class PresentadorCrearEmpleado
    {
        private string active = "Activo";
        private IContratoCrearEmpleado Vista;

        public PresentadorCrearEmpleado(IContratoCrearEmpleado Vista)
        {
            this.Vista = Vista;
        }

        public void LlenarComboEmpleado()
        {
            Vista.IcomboGenero.Items.Insert(0,"Seleccione Genero");
            Vista.IcomboGenero.Items.Insert(1, "Femenino");
            Vista.IcomboGenero.Items.Insert(2, "Masculino");            
        }
        public void LlenarComboNivelEstudio()
        {
            Vista.IcomboNivelEstudio.Items.Insert(0, "Seleccione Nivel");
            Vista.IcomboNivelEstudio.Items.Insert(1, "Bachiller");
            Vista.IcomboNivelEstudio.Items.Insert(2, "Técnico Superior Incompleto");
            Vista.IcomboNivelEstudio.Items.Insert(3, "Técnico Superior");
            Vista.IcomboNivelEstudio.Items.Insert(4, "Universitario Incompleto");
            Vista.IcomboNivelEstudio.Items.Insert(2, "Título Universitario");
        }

        private CargoM10 jobForEmployee()
        {
            return new CargoM10(Vista.IcomboCargo.SelectedItem.Text.ToString(), 
                       DateTime.ParseExact(Vista.ItextDateEmployee, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                       Vista.ItextJobMode, Double.Parse(Vista.ItextSalaryJob));
        }
        public void ObtenerPaises()
        {            
            LogicaTangerine.Comandos.M10.ComandoObtenerPais comando =
            (LogicaTangerine.Comandos.M10.ComandoObtenerPais)LogicaTangerine.Fabrica.FabricaComandos.ObtenerFabricaPaises();

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("0", "Seleccionar un país");

            List<Entidad> listaLugar = comando.Ejecutar();

            foreach (Entidad row in listaLugar)
            {
                DominioTangerine.Entidades.M10.LugarDireccion Pais = (DominioTangerine.Entidades.M10.LugarDireccion)row;
                options.Add(Pais.Id.ToString(),Pais.LugNombre);

            }

            Vista.IcomboPais.DataSource = options;
            Vista.IcomboPais.DataTextField ="value";
            Vista.IcomboPais.DataValueField = "key";
            Vista.IcomboPais.DataBind(); 
        }
        public void ObtenerCargos()
        {
            LogicaTangerine.Comandos.M10.ComandoObtenerCargo comando =
            (LogicaTangerine.Comandos.M10.ComandoObtenerCargo)LogicaTangerine.Fabrica.FabricaComandos.ObtenerFabricaCargo();

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("0", "Seleccionar un cargo");

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
        public void SelectedPaisChanged()
        {
            string country = Vista.IcomboPais.SelectedItem.Text;
            Entidad Parametro = DominioTangerine.Fabrica.FabricaEntidades.ObtenerEstadoM10();
            ((DominioTangerine.Entidades.M10.LugarDireccion)Parametro).LugNombre =  Vista.IcomboPais.SelectedItem.Text;

            Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerFabricaEstado(Parametro);

            Dictionary<string, string> options = new Dictionary<string, string>();
            options.Add("0", "Seleccionar un estado");

            List<Entidad> listaEstado = comando.Ejecutar();

            foreach (Entidad row in listaEstado)
            {
                DominioTangerine.Entidades.M10.LugarDireccion Pais = (DominioTangerine.Entidades.M10.LugarDireccion)row;
                options.Add(Pais.Id.ToString(), Pais.LugNombre);
            }

            Vista.IcomboEstado.DataSource = options;
            Vista.IcomboEstado.DataTextField = "value";
            Vista.IcomboEstado.DataValueField = "key";
            Vista.IcomboEstado.DataBind();
            
        }
        public void AgregarEmpleado()
        {
            

            Entidad Parametro = DominioTangerine.Fabrica.FabricaEntidades.AgregarEmpledoM10();
            
            ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_p_nombre = Vista.ItextFirstName;
            ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_s_nombre = Vista.ItextSecondNamee;
            ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_p_apellido = Vista.ItextFirstLastName;
            ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_s_apellido = Vista.ItextSecondLastName;
            ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_genero = Vista.IcomboGenero.SelectedItem.Text.ToString();
            ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_cedula = int.Parse(Vista.ItextCedula);
            ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_fecha_nac =DateTime.ParseExact(Vista.ItextDateEmployee, "MM/dd/yyyy",CultureInfo.InvariantCulture);
            ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_activo = active;
            ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_nivel_estudio = Vista.IcomboNivelEstudio.SelectedItem.Text.ToString();
            ((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Emp_email = Vista.ItextEmailPerson;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Job = jobForEmployee();
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro).Job = j;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;
            //((DominioTangerine.Entidades.M10.EmpleadoM10)Parametro). = Vista.;





            //LogicaM10 logicEmployee = new LogicaM10();
            
            //logicEmployee.AddNewEmpleado(empleado);
            //Response.Redirect("../M1/EmpleadosAdmin.aspx");
            
            
            //string country = Vista.IcomboPais.SelectedItem.Text;
           
            

            //Comando<List<Entidad>> comando = LogicaTangerine.Fabrica.FabricaComandos.ObtenerFabricaEstado(Parametro);

            //Dictionary<string, string> options = new Dictionary<string, string>();
            //options.Add("0", "Seleccionar un estado");

            //List<Entidad> listaEstado = comando.Ejecutar();

            //foreach (Entidad row in listaEstado)
            //{
            //    DominioTangerine.Entidades.M10.LugarDireccion Pais = (DominioTangerine.Entidades.M10.LugarDireccion)row;
            //    options.Add(Pais.Id.ToString(), Pais.LugNombre);
            //}

            //Vista.IcomboEstado.DataSource = options;
            //Vista.IcomboEstado.DataTextField = "value";
            //Vista.IcomboEstado.DataValueField = "key";
            //Vista.IcomboEstado.DataBind();

        }
    }
}
