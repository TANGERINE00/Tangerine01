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
    public partial class CrearEmpleado : System.Web.UI.Page
    {
        string _p_nombre = String.Empty;
        string _p_apellido = String.Empty;
        string _s_nombre = String.Empty;
        string _s_apellido = String.Empty;
        string _pais = String.Empty;
        string _estado = String.Empty;
        string _direccion = String.Empty;
        string _email = String.Empty;
        string _genero = String.Empty;
        string _telefono = String.Empty;
        string _correo = String.Empty;
        string _fecha_nacimiento;
        int _ficha;
        int _cedula;
        string _activo = "Activo";
        string _nivel_estudio = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            _p_nombre = primer_nombre.Value;
            _s_nombre = segundo_nombre.Value;
            _p_apellido = primer_apellido.Value;
            _s_apellido = segundo_apellido.Value;
            _pais = pais.Value;
            _estado = estado.Value;
            _direccion = direccion.Value;
            _email = email.Value;
            _genero = genero.Value;
            _fecha_nacimiento = "04/05/2016";
            _nivel_estudio = nivel_estudio.Value;
            
            _ficha = 1;
            _cedula = Int32.Parse(cedula.Value);

            //Los dos ultimos valores deben de venir de la ventana de consultar contactos (tipo empresa y id empresa)
            Empleado empleado = new Empleado(_p_nombre, _s_nombre, _p_apellido, _s_apellido, _email,
                _genero, DateTime.Parse(_fecha_nacimiento), _ficha, _cedula, _nivel_estudio, _activo);
            LogicaM10 empleadoLogica = new LogicaM10();
            empleadoLogica.AddNewEmpleado(empleado);
        }
    }
}