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
           emp_num_ficha = ficha;
           emp_cedula = cedula;
           emp_genero = genero;
           emp_p_nombre = pNombre;
           emp_s_nombre = sNombre;
           emp_p_apellido = pApellido;
           emp_s_apellido = sApellido;
           emp_fecha_nac = fechaNacimiento;
           emp_nivel_estudio = nivelEstudio;
           emp_email = email;
           emp_activo = activo;
           fk_lug_dir_id = 1;
       }
  
  }

    
}
