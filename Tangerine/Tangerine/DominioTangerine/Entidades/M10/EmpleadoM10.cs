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
        //public int emp_num_ficha;
        //public int emp_cedula;
        //public String emp_genero;
        //public String emp_p_nombre;
        //public String emp_s_nombre;
        //public String emp_p_apellido;
        //public String emp_s_apellido;
        //public DateTime emp_fecha_nac;
        //public String emp_nivel_estudio;
        //public String emp_email;
        //public String emp_activo;
        //public int fk_lug_dir_id;

        //List<Entidad> listProjects = new List<Entidad>();        
        //private List<Entidad> listProjects = new List<Entidad>();
        //private List<Entidad> addressComplete = new List<Entidad>();
        //private string address;
        //private string empPNombre;
        //private string empSNombre;
        //private string empPApellido;
        //private string empSApellido;
        //private string empActivo;
        //private string empEmail;
        //private string empGenero;
        //private string empModalidad;
        //private int empCedula;
        //private int empId;
        //private int empNumFicha;
        //private double empSalario;
        //private DateTime empFecha;
        //private Entidad job;
        //private Entidad cargoEmpleado;
        //public Cargo jobs;
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
        private string address;
        public CargoM10 jobs;
        private List<Proyecto> listProjects = new List<Proyecto>();
        private List<LugarDireccion> addressComplete = new List<LugarDireccion>();
        //private int empId;
        //private string empPNombre;
        //private string empSNombre;
        //private string empPApellido;
        //private string empSApellido;
        //private string empGenero;
        //private int empCedula;
        //private DateTime empFecha;
        //private string empActivo;
        //private string empNivelEstudio;
        //private string empEmailEmployee;
        //private int empLugId;
        //private string empCargo;
        //private double empSalario;
        //private string empFechaInicio;
        //private string empFechaFin;
        //private string empDireccion;
        #endregion

        #region constructores

        //public EmpleadoEntidad()
        //{
        //    emp_num_ficha = 0;
        //    emp_cedula = 0;
        //    emp_genero = String.Empty;
        //    emp_p_nombre = String.Empty;
        //    emp_s_nombre = String.Empty;
        //    emp_p_apellido = String.Empty;
        //    emp_s_apellido = String.Empty;
        //    emp_fecha_nac = DateTime.Now;
        //    emp_nivel_estudio = String.Empty;
        //    emp_email = String.Empty;
        //    emp_activo = String.Empty;
        //    fk_lug_dir_id = 0;
        //}


        // public EmpleadoEntidad()
        //{
        //    emp_num_ficha = 0;
        //    emp_cedula = 0;
        //    emp_genero = String.Empty;
        //    emp_p_nombre = String.Empty;
        //    emp_s_nombre = String.Empty;
        //    emp_p_apellido = String.Empty;
        //    emp_s_apellido = String.Empty;
        //    emp_fecha_nac = DateTime.Now;
        //    emp_nivel_estudio = String.Empty;
        //    emp_email = String.Empty;
        //    emp_activo = String.Empty;
        //    fk_lug_dir_id = 0;
        //}

        /*


        public Empleado(string primerNombre, string segundoNombre, string primerApellido, string segundoApellido,
                              string genero, DateTime fechaNacimiento, string nivelEsudio, string email, string activo)
        {
            this.emp_p_nombre = primerNombre;
            this.emp_s_nombre = segundoNombre;
            this.emp_p_apellido = primerApellido;
            this.emp_s_apellido = segundoApellido;
            this.emp_genero = genero;
            this.emp_fecha_nac = fechaNacimiento;
            this.emp_nivel_estudio = nivelEsudio;
            this.emp_email = email;
            this.emp_activo = activo;
        }

       


        public Empleado(string pNombre, string sNombre, string pApellido, string sApellido,
                string email, string genero, DateTime fechaNacimiento, int ficha, int cedula,
                string nivelEstudio, string activo)
        {
            this.emp_num_ficha = ficha;
            this.emp_cedula = cedula;
            this.emp_genero = genero;
            this.emp_p_nombre = pNombre;
            this.emp_s_nombre = sNombre;
            this.emp_p_apellido = pApellido;
            this.emp_s_apellido = sApellido;
            this.emp_fecha_nac = fechaNacimiento;
            this.emp_nivel_estudio = nivelEstudio;
            this.emp_email = email;
            this.emp_activo = activo;
            this.fk_lug_dir_id = 1;
        }

        public Empleado(int empId, string empPNombre, string empSNombre, string empPApellido, string empSApellido,
                        int empCedula, DateTime empFecha, string empActivo, int empLugId)
        {
            this.emp_num_ficha = empId;
            this.emp_cedula = empCedula;
            this.emp_p_nombre = empPNombre;
            this.emp_s_nombre = empSNombre;
            this.emp_p_apellido = empPApellido;
            this.emp_s_apellido = empSApellido;
            this.emp_fecha_nac = empFecha;
            this.emp_activo = empActivo;
            this.fk_lug_dir_id = empLugId;
        }

        public Empleado(int empId, string empPNombre, string empSNombre, string empPApellido, string empSApellido,
                       string empGenero, int empCedula, DateTime empFecha, string empActivo, string empEstudio,
                       string empEmail, int empLugId)
        {
            this.emp_num_ficha = empId;
            this.emp_cedula = empCedula;
            this.emp_p_nombre = empPNombre;
            this.emp_s_nombre = empSNombre;
            this.emp_p_apellido = empPApellido;
            this.emp_s_apellido = empSApellido;
            this.emp_genero = empGenero;
            this.emp_fecha_nac = empFecha;
            this.emp_activo = empActivo;
            this.emp_nivel_estudio = empEstudio;
            this.emp_email = empEmail;
            this.fk_lug_dir_id = empLugId;
        }
       

        public Empleado(int empleadoId, string empPNombre, string empSNombre, string empPApellido, string empSApellido,
                         string empGenero, int empCedula, DateTime empFecha, string empActivo, string empEstudio,
                         string empEmail, Cargo cargoEmpleado, List<Entidad> address)
        {
            this.emp_num_ficha = empleadoId;
            this.emp_p_nombre = empPNombre;
            this.emp_s_nombre = empSNombre;
            this.emp_p_apellido = empPApellido;
            this.emp_s_apellido = empSApellido;
            this.emp_genero = empGenero;
            this.emp_cedula = empCedula;
            this.emp_fecha_nac = empFecha;
            this.emp_activo = empActivo;
            this.emp_nivel_estudio = empEstudio;
            this.emp_email = empEmail;
            this.job = cargoEmpleado;
            this.addressComplete = address;
        }



        public Empleado(int empId, string empPNombre, string empSNombre, string empPApellido, string empSApellido,
                        string empGenero, int empCedula, DateTime empFecha, string empActivo, string empNivelEstudio,
                        string empEmailEmployee, int empLugId, string empCargo, double empSlario, String empFechaInicio,
                        string empFechaFin, string empDireccion)
        {
            this.emp_num_ficha = empId;
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
            this.fk_lug_dir_id = empLugId;
            this.address = empDireccion;
            this.job = Fabrica.FabricaEntidades.ObtenerCargo2(empCargo, empSlario, empFechaInicio, empFechaFin);
        }
        */
        public EmpleadoM10(int empId, string empPNombre, string empSNombre, string empPApellido, string empSApellido, int empCedula,
                      DateTime empFecha, string empActivo, string empEmail, string empGenero, string empEstudio, 
                      string empModalidad, double empSalario, Entidad cargo)
      {
          // TODO: Complete member initialization
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

        public EmpleadoM10()
        {
            
        }

        public EmpleadoM10(int empId, string empPNombre, string empSNombre, string empPApellido, string empSApellido,
                           string empGenero, int empCedula, DateTime empFecha, string empActivo, string empNivelEstudio,
                           string empEmailEmployee, int empLugId, Entidad empCargo, double empSalario, string empFechaInicio,
                           string empFechaFin, string empDireccion)
        {
            // TODO: Complete member initialization
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

        #endregion


        #region Get's Set's
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

        public List<Proyecto> ListProjects
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

        public List<LugarDireccion> AddressComplete
        {
            get
            {
                return this.addressComplete;
            }
            set
            {
                this.addressComplete = value;
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








        //#region Get's Set's
        //public string Address
        //{
        //    get { return address; }
        //    set { address = value; }
        //}


        //public string EmpPNombre
        //{
        //    get { return empPNombre; }
        //    set { empPNombre = value; }
        //}


        //public string EmpSNombre
        //{
        //    get { return empSNombre; }
        //    set { empSNombre = value; }
        //}


        //public string EmpPApellido
        //{
        //    get { return empPApellido; }
        //    set { empPApellido = value; }
        //}


        //public string EmpSApellido
        //{
        //    get { return empSApellido; }
        //    set { empSApellido = value; }
        //}


        //public string EmpActivo
        //{
        //    get { return empActivo; }
        //    set { empActivo = value; }
        //}


        //public string EmpEmail
        //{
        //    get { return empEmail; }
        //    set { empEmail = value; }
        //}


        //public string EmpGenero
        //{
        //    get { return empGenero; }
        //    set { empGenero = value; }
        //}
        //private string empEstudio;

        //public string EmpEstudio
        //{
        //    get { return empEstudio; }
        //    set { empEstudio = value; }
        //}
        //public string EmpModalidad
        //{
        //    get { return empModalidad; }
        //    set { empModalidad = value; }
        //}

        //public int EmpCedula
        //{
        //    get { return empCedula; }
        //    set { empCedula = value; }
        //}
        //public int EmpId
        //{
        //    get { return empId; }
        //    set { empId = value; }
        //}
        //public int EmpNumFicha
        //{
        //    get { return empNumFicha; }
        //    set { empNumFicha = value; }
        //}



        //#endregion
    }
}
