﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M7;
using DatosTangerine.M6;
using DatosTangerine.M5;
using LogicaTangerine.M10;

namespace LogicaTangerine.M7
{
    public class LogicaProyecto
    {
        BDProyecto _Pro = new BDProyecto();
        BDEmpleadoProyecto _Empl = new BDEmpleadoProyecto();
        BDProyectoContanto _Cont = new BDProyectoContanto();
        BDPropuesta _Prop = new BDPropuesta();
        LogicaM10 logicaM10 = new LogicaM10();
        /// <summary>
        /// Metodo que agrega o crea nuevos proyectos
        /// </summary>
        /// <param name="P"></param>
        /// <param name="Empleados"></param>
        /// <param name="Contacto"></param>
        public Boolean agregarProyecto(Proyecto P)
        {
            if (_Pro.AddProyecto(P))
            {
                P.Idproyecto = _Pro.ContacMaxIdProyecto();
                if (_Empl.AddProyectoEmpleado(P) && _Cont.AddProyectoContacto(P))
                {
                    return true;

                }
                else
                {
                    return false;
                }
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
        /// Metodo para devolver una lista de empleados
        /// </summary>
        /// <param name="P">Proyecto</param>
        /// <returns>lista de los empleados</returns>
        public List<Empleado> obtenerListaEmpleados(Proyecto P)
        {
            if (_Empl.ContactProyectoEmpleado(P))
            {
                for (int i = 0; i < P.get_empleados().Count;i++ )
                {
                   P.get_empleados()[i] = logicaM10.GetEmployee(P.get_empleados()[i].Emp_num_ficha);
                }

            }

            return P.get_empleados();
        }

        /// <summary>
        /// Metodo para devolver el monto a cobrar por entrega
        /// </summary>
        /// <returns></returns>
        public double calcularPago(double por_viejo,double por_nuevo, double monto)
        {
            double por_cobro = por_nuevo - por_viejo;
            return monto * (por_cobro / 100);
        }

        /// <summary>
        /// Metodo que llena los campos de id en las listas de empleado y contacto dentro de proyecto usando las N:M
        /// </summary>
        /// <param name="P">proyecto</param>
        /// <returns>booleano</returns>
        public Boolean obtenerIDContactosyEmpleados(Proyecto P)
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

            return _Pro.ContactProyectos();

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
        public List<Proyecto> consultarProyectosDeUnGerente(int IDGerente)
        {
            return _Pro.ContactProyectoPorGerente(IDGerente);
        }

        /// <summary>
        /// Metodo que dado el id de una propuesta devuelve el nombre de la propuesta
        /// </summary>
        /// <param name="id"></param>
        /// <returns>nuembre de una propuesta</returns>
        public String ConsultarNombrePropuestaID(int id)
        {
            return _Pro.ContactNombrePropuestaID(id);
        }

        /// <summary>
        /// Metodo que devuelve todas las propuestas  aprobadas
        /// </summary>
        /// <returns>lista que contiene propuestas aprobadas</returns>
        public List<Propuesta> ConsultarPropuestasAprobadas()
        {
            return _Prop.PropuestaProyecto();
        }


        /// <summary>
        /// Metodo que genera el codigo predeterminado de un proyecto
        /// </summary>
        /// <param name="nombre">nombre completo del proyecto</param>
        /// <returns>String con el nombre</returns>
        public String generarCodigoProyecto(String nombre)
        {
            return "Proy-" + nombre[0] + nombre[1] + nombre[2] + nombre[3] + DateTime.Today.Year;
        }
   
       /// <summary>
       /// Metodo que calcula el monto a cobrar en proyectos los cuales el acuerdo de pago es mensual
       /// </summary>
       /// <param name="P">Proyecto</param>
       /// <returns>Doeuble con el monto</returns>
        public Double calcularPagoMesual (Proyecto P)
        {
           int dias = Int32.Parse((P.Fechaestimadafin - P.Fechainicio).Days.ToString());
           if (dias > 31)
           {
               return (P.Costo / dias) * 30;
           }
           else
           {
               return P.Costo;
            }
        }
    }

}