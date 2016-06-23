using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M10;
using Tangerine_Contratos.M10;
using Tangerine_Presentador.M10;
using Tangerine_Contratos.M1;

namespace Tangerine.GUI.M1
{
    public partial class CrearEmpleado : System.Web.UI.Page, IContratoCrearEmpleado
    {
        private PresentadorCrearEmpleado presentador;
        string active = "Activo";
        Hashtable elementos = new Hashtable();


        public CrearEmpleado()
        {
            presentador = new PresentadorCrearEmpleado(this);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            #region LLENAR combo de genero
            if (!IsPostBack)
            {
                presentador.LlenarComboEmpleado();
                presentador.LlenarComboNivelEstudio();
                presentador.ObtenerPaises();
                presentador.ObtenerCargos();
            }
            #endregion
        }

        protected void SelectedJob_Change(object sender, EventArgs e)
        {
            try
            {
                JobSummary.InnerText = "";
                JobSummary.InnerText += elementos[SelectedListJob.SelectedItem.Text].ToString();
            }
            catch (Exception ex)
            {
                JobSummary.InnerText = "";
            }

        }

        protected void SelectedCountry_Change(object sender, EventArgs e)
        {

            presentador.SelectedPaisChanged();


        }

        protected void SelectedState_Change(object sender, EventArgs e)
        {

        }

        protected void SelectedStudy_Change(object sender, EventArgs e)
        {

        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                presentador.AgregarEmpleado();

                Response.Redirect("../M1/EmpleadosAdmin.aspx?EmployeeId=0");

            }


        }


        private Cargo jobForEmployee()
        {
            return new Cargo(SelectedListJob.SelectedItem.Text.ToString(), JobSummary.Value,
                                    DateTime.ParseExact(DateJob.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                                    JobMode.Text, Double.Parse(SalaryJob.Text));

        }

        private void FillSelectedListGender()
        {
            SelectedListGender.Items.Insert(0, "Seleccione Genero");
            SelectedListGender.Items.Insert(1, "Masculino");
            SelectedListGender.Items.Insert(2, "Femenino");
            SelectedListGender.DataBind();
        }

        private void FillLevelListStudy()
        {
            LevelListStudy.Items.Insert(0, "Seleccione Nivel de Estudio");
            LevelListStudy.Items.Insert(1, "Universitario en proceso");
            LevelListStudy.Items.Insert(2, "Universitario completado");
            LevelListStudy.Items.Insert(3, "Bachiller");
            LevelListStudy.DataBind();
        }

        private void FillSelectedListJob()
        {
            LogicaM10 componentes = new LogicaM10();
            ;
            int x = 1;
            SelectedListJob.Items.Insert(0, "Seleccione un cargo");
            foreach (Cargo cargos in componentes.ItemsForListJobs())
            {
                elementos.Add(cargos.Nombre, cargos.Descripcion);
                SelectedListJob.Items.Insert(x, cargos.Nombre);
                x++;
            }

        }
        

        private void FillSelectedListState()
        {
            SelectedListState.Items.Insert(0, "Seleccione un Estado");
            SelectedListGender.DataBind();
        }

        #region Contrato

        DropDownList IContratoCrearEmpleado.IcomboGenero
        {
            get { return SelectedListGender; }
            set { SelectedListGender = value; }
        }

        DropDownList IContratoCrearEmpleado.IcomboNivelEstudio
        {
            get { return LevelListStudy; }
            set { LevelListStudy = value; }
        }

        DropDownList IContratoCrearEmpleado.IcomboPais
        {
            get { return SelectedListCountry; }
            set { SelectedListCountry = value; }
        }

        DropDownList IContratoCrearEmpleado.IcomboCargo
        {
            get { return SelectedListJob; }
            set { SelectedListJob = value; }
        }
        DropDownList IContratoCrearEmpleado.IcomboEstado
        {
            get { return SelectedListState; }
            set { SelectedListState = value; }
        }

        TextBox IContratoCrearEmpleado.ItextCedula
        {
            get { return Cedula2; }
            set { Cedula2 = value; }
        }



        TextBox IContratoCrearEmpleado.ItextFirstName
        {
            get { return PrimerNombre; }
            set { PrimerNombre = value; }
        }
        TextBox IContratoCrearEmpleado.ItextSecondName
        {
            get { return SecondName; }
            set { SecondName = value; }
        }
        TextBox IContratoCrearEmpleado.ItextFirstLastName
        {
            get { return FirstLastName; }
            set { FirstLastName = value; }
        }
        TextBox IContratoCrearEmpleado.ItextSecondLastName
        {
            get { return SecondLastName; }
            set { SecondLastName = value; }
        }
        TextBox IContratoCrearEmpleado.ItextDateEmployee
        {
            get { return DateEmployee; }
            set { DateEmployee= value; }
        }
        TextBox IContratoCrearEmpleado.ItextDateJob
        {
            get { return DateJob; }
            set { DateJob= value; }
        }
        TextBox IContratoCrearEmpleado.ItextJobMode
        {
            get { return JobMode; }
            set { JobMode= value; }
        }
        TextBox IContratoCrearEmpleado.ItextSalaryJob
        {
            get { return SalaryJob; }
            set { SalaryJob = value; }
        }
        TextBox IContratoCrearEmpleado.ItextCityAddress
        {
            get { return CityAddress; }
            set { CityAddress= value; }
        }
        TextBox IContratoCrearEmpleado.ItextAddresEspecific
        {
            get { return AddresEspecific; }
            set { AddresEspecific= value; }
        }
        TextBox IContratoCrearEmpleado.ItextEmailPerson
        {
            get { return EmailPerson; }
            set { EmailPerson= value; }
        }
        TextBox IContratoCrearEmpleado.ItextPhonePerson
        {
            get { return PhonePerson; }
            set { PhonePerson = value; }
        }


        #endregion


    }
}