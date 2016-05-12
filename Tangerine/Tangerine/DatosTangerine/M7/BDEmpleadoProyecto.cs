using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine; 
using DatosTangerine;

namespace DatosTangerine.M7
{
    public class BDEmpleadoProyecto
    {
        BDConexion theConnection;
        List<Parametro> parameters;
        Parametro theParam = new Parametro();

        /// <summary>
        /// Metodo para agregar los Empleados que tiene un proyecto en la base de datos.
        /// </summary>
        /// <param name="TheProyecto">objeto de tipo Proyecto para agregar en bd la lista que este tiene</param>
        /// <returns>true si fue agregado</returns>

        public Boolean AddProyectoEmpleado(Proyecto TheProyecto)
        {
            {
               

                for (int i = 0; i < TheProyecto.get_empleados().Count(); i++)
                {
                    try
                    {
                        parameters = new List<Parametro>();
                        theConnection = new BDConexion();
                        //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                        //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)



                        theParam = new Parametro(ResourceProyecto.ParamId_Proyecto, SqlDbType.Int, TheProyecto.Idproyecto.ToString(), false);
                        parameters.Add(theParam);

                        theParam = new Parametro(ResourceProyecto.ParamPCIdContacto, SqlDbType.Int, TheProyecto.get_empleados()[i].emp_num_ficha.ToString(), false);
                        parameters.Add(theParam);



                        //Se manda a ejecutar en BDConexion el stored procedure M7_AgregarProyecto y todos los parametros que recibe
                        List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceProyecto.AddProyectoEmpleado, parameters);

                    }
                    catch (Exception ex)
                    {
                        throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                    }

                }
                return true;
            }
        }

        /// <summary>
        /// Metodo para consultar los empleados de un proyecto específico que pertenecen a la base de datos.
        /// Recibe un parametros:  TheProyecto que es un objeto de tipo proyecto.
        ///                     
        /// </summary>
        /// <returns>Un objeto de tipo Proyecto</returns>
        /// <summary>
        /// Metodo para consultar los contactos de un proyecto específico que pertenecen a la base de datos.
        /// Recibe un parametros:  TheProyecto que es un objeto de tipo proyecto.
        /// </summary>
        /// <returns>Lista de contactos </returns>
        public void ContactProyectoEmpleado(Proyecto TheProyecto)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            List<Empleado> listEmpleado = new List<Empleado>();

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceProyecto.ParamId_Proyecto, SqlDbType.Int, TheProyecto.Idproyecto.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceProyecto.ContactProyectoEmpleado, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int PEIdEmpleado = int.Parse(row[ResourceProyecto.PEIdEmpleado].ToString());

                    //creo un objeto de tipo Contacto con los datos del id y lo guardo
                    Empleado contacto = new Empleado();
                    contacto.emp_num_ficha = PEIdEmpleado;
                    listEmpleado.Add(contacto);

                }

                TheProyecto.set_empleados(listEmpleado);
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
        }



        /// <summary>
        /// Metodo para eliminar los contactos de un proyecto de la base de datos.
        /// </summary>
        /// <param name="TheProyecto">objeto de tipo Proyecto a eliminar en bd</param>
        /// <returns>true si fue eliminado</returns>
        public Boolean DeleteProyectoEmpleado(Proyecto TheProyecto)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceProyecto.ParamId_Proyecto, SqlDbType.Int, TheProyecto.Idproyecto.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M7_EliminarProyecto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceProyecto.DeleteProyectoEmpleado, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }
    }
}
