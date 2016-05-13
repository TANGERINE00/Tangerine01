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
    public class BDPropuesta
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

                parametro = new Parametro(RecursosPropuesta.ParamEstatusProp, SqlDbType.VarChar, laPropuesta.Estatus, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamMonedaProp, SqlDbType.VarChar, laPropuesta.Moneda, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamCantidaProp, SqlDbType.Int, laPropuesta.Entrega.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamCostoProp, SqlDbType.Int, laPropuesta.Costo.ToString(), false);
                parametros.Add(parametro);



                //Se manda a ejecutar en BDConexion el stored procedure M6_AgregarPropuesta y todos los parametros que recibe
                List<Resultado> resultado = theConnection.EjecutarStoredProcedure(RecursosPropuesta.AgregarPropuesta, parametros);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }









        /// <summary>
        /// Metodo diseñado para M7, que devuelve la lista de propuestas con estatus aprobado y que no están en proyecto
        /// </summary>
        /// <param name="propid">Parametro de entrada de tipo propuesta</param>
        /// <returns>Retorna la lista de propuestas con estatus= Aprobado y que no se encuentran aún en Proyecto</returns>



       
        
        public static List<Propuesta> PropuestaProyecto()
        {
            List<Parametro> parametros = new List<Parametro>();
            List<Propuesta> listaPropuesta = new List<Propuesta>();
            BDConexion theConnection = new BDConexion();
            Parametro parametro = new Parametro();


            try 
            {
                theConnection.Conectar();

                //Guardo la tabla que me regresa el procedimiento de consultar propuestas
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(RecursosPropuesta.ConsultarPropuesta, parametros);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    int conEstatus = int.Parse(row[RecursosPropuesta.PropEstatus].ToString());
                    String conNombre = row[RecursosPropuesta.PropNombre].ToString();
                    

                    //Creo un objeto de tipo Propuesta con los datos de la fila y lo guardo en una lista de propuestas
                    Propuesta propuesta = new Propuesta(conNombre, conEstatus);
                    listaPropuesta.Add(propuesta);
                }


            }

            catch (Exception ex)
            {
                 throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }



            return listaPropuesta;
        
        
        
        }







    }
}
