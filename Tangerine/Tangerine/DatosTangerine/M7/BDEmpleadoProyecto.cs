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
    class BDEmpleadoProyecto
    {
        BDConexion theConnection;
        List<Parametro> parameters;
        Parametro theParam = new Parametro();

        public Boolean AddProyecto(Proyecto TheProyecto)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            for (int i = 0; i < TheProyecto.get_empleados().Count(); i++)
            {
                try
                {
                    //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                    //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)



                    theParam = new Parametro(ResourceProyecto.ParamId_Proyecto, SqlDbType.Int, TheProyecto.Idproyecto.ToString(), false);
                    parameters.Add(theParam);

                    theParam = new Parametro(ResourceProyecto.ParamNombre, SqlDbType.Int, TheProyecto.get_empleados()[i], false);
                    parameters.Add(theParam);



                    //Se manda a ejecutar en BDConexion el stored procedure M7_AgregarProyecto y todos los parametros que recibe
                    List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceProyecto.AddNewProyecto, parameters);

                }
                catch (Exception ex)
                {
                    throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
                }

            }
                 return true;
        }
    }
}
