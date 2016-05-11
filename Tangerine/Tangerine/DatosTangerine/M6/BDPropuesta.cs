using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;

namespace DatosTangerine.M6
{
    class BDPropuesta
    {

        /// <summary>
        /// Metodo para agregar una propuesta en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Propuesta para agregar en bd</param>
        /// <returns>true si fue agregado</returns>

        public static bool agregarPropuesta(Propuesta laPropuesta)
        {
            List<Parametro> parametros = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro parametro = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                parametro = new Parametro(RecursosPropuesta.ParamNombreProp, SqlDbType.VarChar, laPropuesta.Nombre, false);
                parametros.Add(parametro);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                parametro = new Parametro(RecursosPropuesta.ParamDescriProp, SqlDbType.VarChar, laPropuesta.Descripcion, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamDuracProp, SqlDbType.VarChar, laPropuesta.Duracion, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamFechaIProp, SqlDbType.Date, laPropuesta.Feincio.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamFechaFProp, SqlDbType.VarChar, laPropuesta.Fefinal.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamEmail, SqlDbType.VarChar, laPropuesta.Correo, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamEstatusProp, SqlDbType.VarChar, laPropuesta.Estatus, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamIdComp, SqlDbType.Int, laPropuesta.IdCompañia.ToString(), false);
                parametros.Add(parametro);

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(RecursosPropuesta.AddNewContact, parametros);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }






    }
}
