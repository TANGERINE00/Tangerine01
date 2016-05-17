using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaTangerine.M10;
using DominioTangerine;

namespace Tangerine.GUI.M1
{
    public partial class VerEmpleado : System.Web.UI.Page
    {
        private String dataEmployee
        {
            get
            {
                return this.FormViewEmployee.Text;
            }
            set
            {
                this.FormViewEmployee.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
  
            int employeeCode;
            LogicaM10 logicEmployee = new LogicaM10();

            employeeCode = int.Parse(Request.QueryString["EmployeeId"]);

            Empleado employee = logicEmployee.GetEmployee(employeeCode);

            dataEmployee = ViewFormEmployee(employee);
        }

        private string EmployeeAge(string year)
        {
            int age;

            age = Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(year);
            
            return age.ToString();
        }

        private String ViewFormEmployee(Empleado employee)
        {
            dataEmployee += ResourceGUIM10.OpenDivRow;
           
            dataEmployee += ResourceGUIM10.OpenDivColDataInfo + "<h4> Datos personales</h4>" ;
           
            dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                            employee.Emp_cedula.ToString() + ResourceGUIM10.CloseInputTextDisabled +
                            ResourceGUIM10.CloseDiv + ResourceGUIM10.OpenFormGroup +
                            ResourceGUIM10.OpenInputText + employee.Emp_p_nombre.ToString() +
                            ResourceGUIM10.Espacio + employee.Emp_s_nombre.ToString() +
                            ResourceGUIM10.Espacio + employee.Emp_p_apellido.ToString() +
                            ResourceGUIM10.Espacio + employee.Emp_s_apellido.ToString() +
                            ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;
            
            dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                            employee.Emp_genero.ToString() + ResourceGUIM10.CloseInputTextDisabled +
                            ResourceGUIM10.CloseDiv;

            dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                            employee.Emp_fecha_nac.ToString("dd/MM/yyyy") +
                            ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

            dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                            EmployeeAge(employee.Emp_fecha_nac.ToString("yyyy")).ToString() + ResourceGUIM10.CloseInputTextDisabled +
                            ResourceGUIM10.CloseDiv;

            dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                            employee.Adrress+ ResourceGUIM10.CloseInputTextDisabled +
                            ResourceGUIM10.CloseDiv;

            //cierre de col
            dataEmployee += ResourceGUIM10.CloseDiv;

            dataEmployee += ResourceGUIM10.OpenDivColDataInfo + "<h4> Datos contrato</h4>";

            dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                            Convert.ToDateTime(employee.Job.FechaIni).ToString("dd/MM/yyyy") + 
                            ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

            dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                            employee.Job.FechaFin + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

            dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                            employee.Job.Nombre + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

            dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                            employee.Job.Sueldo.ToString() + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

            dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                            employee.Emp_activo + ResourceGUIM10.CloseInputTextDisabled + ResourceGUIM10.CloseDiv;

            //cierre de col
            dataEmployee += ResourceGUIM10.CloseDiv;

            //cierre de row
            dataEmployee += ResourceGUIM10.CloseDiv;

            dataEmployee += ResourceGUIM10.OpenDivRow;

            dataEmployee += ResourceGUIM10.OpenDivColDataInfo + "<h4> Datos de contacto</h4>";

            dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                            employee.Emp_email.ToString() + ResourceGUIM10.CloseInputTextDisabled +
                            ResourceGUIM10.CloseDiv;

            dataEmployee += ResourceGUIM10.OpenFormGroup + ResourceGUIM10.OpenInputText +
                            "04168098294" + ResourceGUIM10.CloseInputTextDisabled +
                            ResourceGUIM10.CloseDiv;

            //cierre de row
            dataEmployee += ResourceGUIM10.CloseDiv;              
                            

            return dataEmployee;
 
        }
    }
}
