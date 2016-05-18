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

            SelectedListGender.Items.Insert(0, "Seleccione Genero");
            SelectedListGender.Items.Insert(1, "Masculino");
            SelectedListGender.Items.Insert(2, "Femenino");
            SelectedListGender.DataBind();

            LevelListStudy.Items.Insert(0,"Seleccione Nivel de Estudio");
            LevelListStudy.Items.Insert(1, "Universitario en proceso");
            LevelListStudy.Items.Insert(2, "Universitario completado");
            LevelListStudy.Items.Insert(3, "Bachiller");
            LevelListStudy.DataBind();

            SelectedListJob.Items.Insert(0, "Seleccione un Cargo");
            SelectedListJob.Items.Insert(1,"Programador");
            SelectedListJob.Items.Insert(2, "Analista de procesos");
            SelectedListJob.Items.Insert(3, "Arquitecto");
            SelectedListGender.DataBind();

            SelectedListCountry.Items.Insert(0,"Seleccione un Pais");
            SelectedListCountry.Items.Insert(1, "Venezuela");
            SelectedListCountry.Items.Insert(2, "Brazil");
            SelectedListGender.DataBind();

            SelectedListState.Items.Insert(0,"Seleccione un Estado");
            SelectedListGender.DataBind();
          
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
            List<LugarDireccion> direccion = new List<LugarDireccion>();
            
            direccion.Add(new LugarDireccion(0, SelectedListCountry.SelectedItem.Text.ToString(),"Pais",0));
            direccion.Add(new LugarDireccion(0, SelectedListState.SelectedItem.Text.ToString(), "Estado", 0));
            direccion.Add(new LugarDireccion(0, CityAddress.Value,"Ciudad",0));
            direccion.Add(new LugarDireccion(0, AddresEspecific.Value,"Direccion",0));

            Empleado empleado = new Empleado(0, FirstName.Value, SecondNamee.Value, FirstLastName.Value,
                                                SecondLastName.Value, SelectedListGender.SelectedItem.Text.ToString(),
                                                int.Parse(Cedula.Value),
                                                DateTime.ParseExact(DateEmployee.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                                                active, LevelListStudy.SelectedItem.Text, EmailPerson.Value, 0);

            Cargo cargo = new Cargo(0,SelectedListJob.SelectedItem.Text.ToString(), JobSummary.Value, 0, 0,
                                    DateTime.ParseExact(DateJob.Value, "MM/dd/yyyy", CultureInfo.InvariantCulture),
                                    JobMode.Value, Double.Parse(SalaryJob.Value));
                     
        }
    }
}