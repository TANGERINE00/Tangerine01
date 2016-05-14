using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M7;

namespace LogicaTangerine.M7
{
    public class LogicaProyecto
    {
        BDProyecto _Pro = new BDProyecto();
        BDEmpleadoProyecto _Empl = new BDEmpleadoProyecto();
        BDProyectoContanto _Cont = new BDProyectoContanto();

        /// <summary>
        /// Metodo que agrega o crea nuevos proyectos
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Empleados"></param>
        /// <param name="Contacto"></param>
        public Boolean agregarProyecto(Proyecto P)
        {
            if (_Pro.AddProyecto(P) && _Empl.AddProyectoEmpleado(P) && _Cont.AddProyectoContacto(P))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo para Modificar un Proyecto
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Empleados"></param>
        /// <param name="Contacto"></param>
        /// <returns></returns>
        public Boolean modificarProyecto(Proyecto P)
        {

            if (_Pro.ChangeProyecto(P) && _Cont.DeleteProyectoContacto(P) &&
                _Cont.AddProyectoContacto(P) && _Empl.DeleteProyectoEmpleado(P) && _Empl.AddProyectoEmpleado(P))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Metodo que llena los campos de id en las listas de empleado y contacto dentro de proyecto usando las N:M
        /// </summary>
        /// <param name="P">proyecto</param>
        /// <returns>booleano</returns>
        public Boolean obtenerIDContactosyEmpleados  (Proyecto P)
        {
            if (_Empl.ContactProyectoEmpleado(P) && _Cont.ContactProyectoContacto(P))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        /// <summary>
        /// Metodo para consultar todos los proyectos
        /// </summary>
        /// <returns></returns>
        public List<Proyecto> consultarProyectos() 
        {
            
            return   _Pro.ContactProyectos();
            
        }

        /// <summary>
        /// Metodo que devuelve un proyecto dado el ID
        /// </summary>
        /// <param name="ID"> id del proyecto</param>
        /// <returns>Un Proyecto </returns>
        public Proyecto consultarProyecto(int ID)
        {

            return _Pro.ContactProyecto(ID);

            }
    
    /// <summary>
    /// Metodo que devuelve los proyecto en desarrollo con acuerdo de pago mensual, los cuales les toca facturar hoy
    /// </summary>
    /// <returns>lista de proyectos</returns>
    public List<Proyecto> consultarAcuerdoPagoMensual()
    {
        return _Pro.ContactProyectosxAcuerdoPago();
    }
    

   /// <summary>
   ///  Metodo que devuelve los proyecto en los que trabja un empleado dado
   /// </summary>
   /// <param name="IDEmpleado"> indentificador unico de un empleado </param>
   /// <returns>lista de proyectos</returns>
    public List<Proyecto> consultarProyectosDeUnTrabajador(int IDEmpleado)
    {
        return _Pro.ContactProyectoPorEmpleado(IDEmpleado);
    }

    /// <summary>
    ///  Metodo que devuelve los proyecto en los que trabja un Gerente dado
    /// </summary>
    /// <param name="IDGerente"> indentificador unico de un empleado </param>
    /// <returns>lista de proyectos</returns>
    public List<Proyecto> consultarProyectosDeUnGerente( int IDGerente )
    {
        return _Pro.ContactProyectoPorGerente(IDGerente);
    }
    }
    
}