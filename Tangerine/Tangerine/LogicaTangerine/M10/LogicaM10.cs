using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M10;

namespace LogicaTangerine.M10
{
    public class LogicaM10
    {
        public Empleado theEmpleado;
        List<Empleado> anwser;
        bool anwser2;
        public bool AddNewEmpleado(Empleado empleado)
        {
            try
            {
                return BDEmpleado.AddEmpleado(empleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
