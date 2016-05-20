using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M10;


namespace Tangerine.GUI.M1
{
    public partial class CrearEmpleado : System.Web.UI.Page
    {

        string active = "Activo";

        protected void Page_Load(object sender, EventArgs e)
        {
            FillSelectedListGender();
            FillLevelListStudy();
            FillSelectedListJob();
            FillSelectedListCountry();
            FillSelectedListState();
        }

        protected void SelectedGender_Change(object sender, EventArgs e)
        {

            
        }

        protected void SelectedJob_Change(object sender, EventArgs e)
        {
            JobSummary.InnerText += "descripcion de prueba";
        }

        protected void SelectedCountry_Change(object sender, EventArgs e)
        {
            SelectedListState.Items.Insert(0, "Seleccione un Estado");
            SelectedListState.Items.Insert(1, "Estado 1");
            SelectedListState.Items.Insert(2, "Estado 2");
            SelectedListState.DataBind();
        }

        protected void SelectedState_Change(object sender, EventArgs e)
        { 
        
        }

        protected void SelectedStudy_Change(object sender, EventArgs e)
        {
 
        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            List<LugarDireccion> direccion = newAddress();
            
            Cargo cargo = jobForEmployee();

            Empleado empleado = new Empleado(FirstName.Value, SecondNamee.Value, FirstLastName.Value,
                                                SecondLastName.Value, SelectedListGender.SelectedItem.Text.ToString(),
                                                int.Parse(Cedula.Value),
                                                DateTime.ParseExact(DateEmployee.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                                                active, LevelListStudy.SelectedItem.Text, EmailPerson.Value,cargo,direccion);

            
        }

        private List<LugarDireccion> newAddress()
        {
            List<LugarDireccion> direccion = new List<LugarDireccion>();

            direccion.Add(new LugarDireccion(SelectedListCountry.SelectedItem.Text.ToString(), "Pais"));
            direccion.Add(new LugarDireccion(SelectedListState.SelectedItem.Text.ToString(), "Estado"));
            direccion.Add(new LugarDireccion(CityAddress.Value, "Ciudad"));
            direccion.Add(new LugarDireccion(AddresEspecific.Value, "Direccion"));

            return direccion;
        }

        private Cargo jobForEmployee()
        {
            return new Cargo(SelectedListJob.SelectedItem.Text.ToString(), JobSummary.Value,
                                    DateTime.ParseExact(DateJob.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                                    JobMode.Value, Double.Parse(SalaryJob.Value));
            
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
            SelectedListJob.Items.Insert(0, "Seleccione un Cargo");
            SelectedListJob.Items.Insert(1, "Programador");
            SelectedListJob.Items.Insert(2, "Analista de procesos");
            SelectedListJob.Items.Insert(3, "Arquitecto");
            SelectedListGender.DataBind();
        }

        private void FillSelectedListCountry()
        {
            LogicaM10 componentes = new LogicaM10();
            int x = 1;
            SelectedListCountry.Items.Insert(0, "Seleccione un pais");
            foreach(LugarDireccion paises in componentes.ItemsForListCountry())
            {
                SelectedListCountry.Items.Insert(x, paises.LugNombre);
                x++;
            }
        }

        private void FillSelectedListState()
        {
            SelectedListState.Items.Insert(0, "Seleccione un Estado");
            SelectedListGender.DataBind();
        }
    }
}