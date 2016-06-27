using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine.Entidades.M10
{
    public class EmpleadoM10 : Entidad
    {
        #region Atributos
        public int emp_num_ficha;
        public int emp_cedula;
        public String emp_genero;
        public String emp_p_nombre;
        public String emp_s_nombre;
        public String emp_p_apellido;
        public String emp_s_apellido;
        public DateTime emp_fecha_nac;
        public String emp_nivel_estudio;
        public String emp_email;
        public String emp_activo;
        public int fk_lug_dir_id;
        public int emp_id;
        public string emp_estudio;
        public string emp_modalidad;
        public double emp_salario;
        private string emp_FechaInicio;    
        private string emp_FechaFin;      
        private string emp_Direccion;
        private int emp_LugId;
        private string emp_cargo;
        private string emp_telefono;      
        private string address;
        private List<Entidad> addressComplete = new List<Entidad>();
        public CargoM10 jobs;
        private List<Entidad> listProjects = new List<Entidad>();
        private List<LugarDireccion> listaDireccion = new List<LugarDireccion>();
        #endregion

        #region constructores

        public EmpleadoM10()
        {

        }
        
        public EmpleadoM10(int id)
        {
            emp_id = id;
        }


        public EmpleadoM10(int empId, string empPNombre, string empSNombre, string empPApellido, string empSApellido, int empCedula,
                      DateTime empFecha, string empActivo, string empEmail, string empGenero, string empEstudio, 
                      string empModalidad, double empSalario, Entidad cargo)
      {
        
          this.emp_id = empId;
          this.emp_p_nombre = empPNombre;
          this.emp_s_nombre = empSNombre;
          this.emp_p_apellido = empPApellido;
          this.emp_s_apellido = empSApellido;
          this.emp_cedula = empCedula;
          this.emp_fecha_nac = empFecha;
          this.emp_activo = empActivo;
          this.emp_email = empEmail;
          this.emp_genero = empGenero;
          this.emp_estudio = empEstudio;
          this.emp_modalidad = empModalidad;
          this.emp_salario = empSalario;
          this.jobs =(CargoM10)cargo;
      }

        

        public EmpleadoM10(int empId, string empPNombre, string empSNombre, string empPApellido, string empSApellido,
                           string empGenero, int empCedula, DateTime empFecha, string empActivo, string empNivelEstudio,
                           string empEmailEmployee, int empLugId, Entidad empCargo, double empSalario, string empFechaInicio,
                           string empFechaFin, string empDireccion)
        {
            
            this.emp_id = empId;
            this.emp_p_nombre = empPNombre;
            this.emp_s_nombre = empSNombre;
            this.emp_p_apellido = empPApellido;
            this.emp_s_apellido = empSApellido;
            this.emp_genero = empGenero;
            this.emp_cedula = empCedula;
            this.emp_fecha_nac = empFecha;
            this.emp_activo = empActivo;
            this.emp_nivel_estudio = empNivelEstudio;
            this.emp_email = empEmailEmployee;
            this.emp_LugId = empLugId;
            this.jobs = (CargoM10)empCargo;
            this.emp_salario = empSalario;
            this.emp_FechaInicio = empFechaInicio;
            this.emp_FechaFin = empFechaFin;
            this.emp_Direccion = empDireccion;
        }




        public EmpleadoM10(string empPNombre, string empSNombre, string empPApellido, string empSApellido, string empGenero, int empCedula,
                     DateTime empFecha, string empActivo, string empEstudio, string empEmail, Entidad cargo, string telefono, List<LugarDireccion> ListaLugar) 
                  
        { 
            this.emp_p_nombre = empPNombre;
            this.emp_s_nombre = empSNombre;
            this.emp_p_apellido = empPApellido;
            this.emp_s_apellido = empSApellido;
            this.emp_cedula = empCedula;
            this.emp_fecha_nac = empFecha;
            this.emp_activo = empActivo;
            this.emp_email = empEmail;
            this.emp_genero = empGenero;
            this.emp_estudio = empEstudio;
            this.ListaDireccion = ListaLugar;
            this.jobs = (CargoM10)cargo;
            this.Emp_telefono = telefono;
        }


        #endregion


        #region Get's Set's
               
        public List<LugarDireccion> ListaDireccion
        {
            get { return listaDireccion; }
            set { listaDireccion = value; }
        }
        public string Emp_telefono
        {
            get { return emp_telefono; }
            set { emp_telefono = value; }
        }
        public int Emp_num_ficha
        {
            get
            {
                return this.emp_num_ficha;
            }
            set
            {
                this.emp_num_ficha = value;
            }
        }

        public int Emp_cedula
        {
            get
            {
                return this.emp_cedula;
            }
            set
            {
                this.emp_cedula = value;
            }
        }

        public String Emp_genero
        {
            get
            {
                return this.emp_genero;
            }
            set
            {
                this.emp_genero = value;
            }
        }

        public String Emp_p_nombre
        {
            get
            {
                return this.emp_p_nombre;
            }
            set
            {
                this.emp_p_nombre = value;
            }
        }

        public String Emp_s_nombre
        {
            get
            {
                return this.emp_s_nombre;
            }
            set
            {
                this.emp_s_nombre = value;
            }
        }

        public String Emp_p_apellido
        {
            get
            {
                return this.emp_p_apellido;
            }
            set
            {
                this.emp_p_apellido = value;
            }
        }

        public String Emp_s_apellido
        {
            get
            {
                return this.emp_s_apellido;
            }
            set
            {
                this.emp_s_apellido = value;
            }
        }

        public DateTime Emp_fecha_nac
        {
            get
            {
                return this.emp_fecha_nac;
            }
            set
            {
                this.emp_fecha_nac = value;
            }
        }

        public String Emp_nivel_estudio
        {
            get
            {
                return this.emp_nivel_estudio;
            }
            set
            {
                this.emp_nivel_estudio = value;
            }
        }

        public String Emp_email
        {
            get
            {
                return this.emp_email;
            }
            set
            {
                this.emp_email = value;
            }
        }

        public String Emp_activo
        {
            get
            {
                return this.emp_activo;
            }
            set
            {
                this.emp_activo = value;
            }
        }

        public int Fk_lug_dir_id
        {
            get
            {
                return this.fk_lug_dir_id;
            }
            set
            {
                this.fk_lug_dir_id = value;
            }
        }

        public string Adrress
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        public List<Entidad> ListProjects
        {
            get
            {
                return this.listProjects;
            }
            set
            {
                this.listProjects = value;
            }
        }

        public CargoM10 Jobs
        {
            get
            {
                return this.jobs;
            }

            set
            {
                this.jobs = value;
            }
        }


        public string Emp_Direccion
        {
            get { return emp_Direccion; }
            set { emp_Direccion = value; }
        }

        public int Emp_LugId
        {
            get { return emp_LugId; }
            set { emp_LugId = value; }
        }

        public string Emp_FechaInicio
        {
            get { return emp_FechaInicio; }
            set { emp_FechaInicio = value; }
        }

        public string Emp_FechaFin
        {
            get { return emp_FechaFin; }
            set { emp_FechaFin = value; }
        }

        #endregion

                
       
    }
}
