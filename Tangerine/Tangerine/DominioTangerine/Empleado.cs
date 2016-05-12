using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominioTangerine
{
  public   class Empleado
    {

       public int emp_num_ficha ;
	   public int emp_cedula ;
	   public String emp_genero ;
	   public String emp_p_nombre ;
	   public String emp_s_nombre ;
	   public String emp_p_apellido ;
	   public String emp_s_apellido ;
	   public DateTime emp_fecha_nac ;
	   public String emp_nivel_estudio ;
	   public String emp_email ;
	   public String emp_activo ;
	   public int fk_lug_dir_id ;

       public Empleado()
       {
           emp_num_ficha = 0;
           emp_cedula = 0;
           emp_genero = String.Empty;
           emp_p_nombre = String.Empty;
           emp_s_nombre = String.Empty;
           emp_p_apellido = String.Empty;
           emp_s_apellido = String.Empty;
           emp_fecha_nac = DateTime.Now;
           emp_nivel_estudio = String.Empty;
           emp_email = String.Empty;
           emp_activo = String.Empty;
	       fk_lug_dir_id = 0;
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
  
  }

    
}
