using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M10;

namespace Tangerine.GUI.M1
{
    public partial class EmpleadosAdmin : System.Web.UI.Page
    {
        string fecha;
        public string empleado
        {
            get
            {
                return this.tabla.Text;
            }
            set
            {
                this.tabla.Text = value;
            }
        }

        public string button
        {
            get
            {
                return this.nuevoempleado.Text;
            }
            set
            {
                this.nuevoempleado.Text = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LogicaM10 logicaM10 = new LogicaM10();
            

            if (!IsPostBack)
            {
                //Aqui ejecuto el filltable de la clase creada en logica para probar la conexion a la bd
                List<Empleado> listEmpleado = logicaM10.GetEmpleados();

                try
                {
                    foreach (Empleado theEmpleado in listEmpleado)
                    {
                        //Nombres
                        empleado += ResourceGUIM10.AbrirTR;
                        empleado += ResourceGUIM10.AbrirTD + theEmpleado.emp_p_nombre.ToString() +
                            ResourceGUIM10.Espacio +
                            theEmpleado.emp_s_nombre.ToString() + ResourceGUIM10.CerrarTD;
                        //Apellidos
                        empleado += ResourceGUIM10.AbrirTD + theEmpleado.emp_p_apellido.ToString() +
                            ResourceGUIM10.Espacio +
                            theEmpleado.emp_s_apellido.ToString() + ResourceGUIM10.CerrarTD;
                        //Cedula
                        empleado += ResourceGUIM10.AbrirTD + theEmpleado.emp_cedula.ToString() +
                            ResourceGUIM10.CerrarTD;
                        //Cargo
                        empleado += ResourceGUIM10.AbrirTD + theEmpleado.Job.Nombre +
                            ResourceGUIM10.CerrarTD;
                        //Sueldo base
                        empleado += ResourceGUIM10.AbrirTD + theEmpleado.Job.Sueldo +
                            ResourceGUIM10.CerrarTD;
                        //Fecha de contratacion
                        empleado += ResourceGUIM10.AbrirTD +
                             theEmpleado.Job.FechaContratacion.ToString("dd/MM/yyyy") +
                             ResourceGUIM10.CerrarTD;
                        //Estatus
                        if (theEmpleado.emp_activo=="Activo")
                            empleado += ResourceGUIM10.AbrirTD + ResourceGUIM10.AbrirActivo + theEmpleado.emp_activo +
                                ResourceGUIM10.CerrarActivo + ResourceGUIM10.CerrarTD;
                        else
                            empleado += ResourceGUIM10.AbrirTD + ResourceGUIM10.AbrirInactivo + theEmpleado.emp_activo +
                                ResourceGUIM10.CerrarInactivo + ResourceGUIM10.CerrarTD;
                        //Acciones de cada empleado
                        empleado += ResourceGUIM10.AbrirTD;
                        //Ver
                        empleado += ResourceGUIM10.BotonVerEmpAbrir + theEmpleado.emp_num_ficha +
                            ResourceGUIM10.BotonVerEmpCerrar;
                        //Modificar
                        empleado += ResourceGUIM10.BotonModificarEmpAbrir + theEmpleado.emp_num_ficha +
                            ResourceGUIM10.BotonModificarEmpCerrar;
                        empleado += ResourceGUIM10.BotonStatusEmpAbrir + theEmpleado.emp_num_ficha +
                            ResourceGUIM10.BotonStatusEmpCerrar;

                        empleado += ResourceGUIM10.CerrarTD;
                        empleado += ResourceGUIM10.CerrarTR;
                    }
                    button += ResourceGUIM10.VentanaAgregarEmpleado;
                }
                catch (Exception ex)
                {

                }
            }

        }
    }
}