using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;

namespace DatosTangerine.M10
{
    public class BDEmpleado
    {
        /// <summary>
        /// Metodo para agregar un empleado nuevo en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Empleado para agregar en bd</param>
        /// <returns>true si fue agregado</returns>
        public static bool AddEmpleado(Empleado theEmpleado)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceEmpleado.ParamFicha, SqlDbType.VarChar, theEmpleado.emp_num_ficha.ToString(), false);
                parameters.Add(theParam);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceEmpleado.ParamCedula, SqlDbType.VarChar, theEmpleado.emp_cedula.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceEmpleado.ParamGenero, SqlDbType.VarChar, theEmpleado.emp_genero, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceEmpleado.ParamPNombre, SqlDbType.VarChar, theEmpleado.emp_p_nombre, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceEmpleado.ParamSNombre, SqlDbType.VarChar, theEmpleado.emp_s_nombre, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceEmpleado.ParamPApellido, SqlDbType.VarChar, theEmpleado.emp_p_apellido, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceEmpleado.ParamSApellido, SqlDbType.Int, theEmpleado.emp_s_apellido, false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceEmpleado.AddNewEmpleado, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }
    }
}
