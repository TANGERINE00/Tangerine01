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

                parametro = new Parametro(RecursosPropuesta.ParamTipoDuProp, SqlDbType.VarChar, laPropuesta.TipoDuracion, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamDuracProp, SqlDbType.VarChar, laPropuesta.CantDuracion, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamFechaIProp, SqlDbType.Date, laPropuesta.Feincio.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamFechaFProp, SqlDbType.Date, laPropuesta.Fefinal.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamEstatusProp, SqlDbType.VarChar, laPropuesta.Estatus, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamMonedaProp, SqlDbType.VarChar, laPropuesta.Moneda, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamAcuerdoProp, SqlDbType.VarChar, laPropuesta.Acuerdopago, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamCantidaProp, SqlDbType.Int, laPropuesta.Entrega.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamCostoProp, SqlDbType.Int, laPropuesta.Costo.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamIdCompa, SqlDbType.Int, laPropuesta.IdCompañia.ToString(), false);
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



       
        
        public   List<Propuesta> PropuestaProyecto()
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
                    String conEstatus =   row[RecursosPropuesta.PropEstatus].ToString();
                    String conNombre = row[RecursosPropuesta.PropNombre].ToString();
                    

                    //Creo un objeto de tipo Propuesta con los datos de la fila y lo guardo en una lista de propuestas
                    Propuesta propuestas = new Propuesta();
                    listaPropuesta.Add(propuestas);
                }


            }

            catch (Exception ex)
            {
                 throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }



            return listaPropuesta;
        
        
        
        }



        
        /// <summary>
        /// Método para listar los requerimientos por propuesta 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>




        public static List<Requerimiento>
         ConsultarRequerimientosPorPropuesta(int id)
        {

            //if (id == -1)
            //{
            //    throw new ExcepcionesTotem.Modulo5.
            //       ProyectoNoEncontradoException(
            //       RecursosBDModulo5.EXCEPCION_PRO_NO_ENC_CODIGO,
            //       RecursosBDModulo5.EXCEPCION_PRO_NO_ENC_MENSAJE,
            //       new Exception()
            //       );
            //}

            List<Parametro> parametros = new List<Parametro>();

            List<Requerimiento> listaRequerimientos =
               new List<Requerimiento>();

            Parametro parametro = new Parametro(
               RecursosPropuesta.ParamIdProp,
               SqlDbType.Int, id.ToString(), false);
            parametros.Add(parametro);

            try
            {
                BDConexion conexion = new BDConexion();

                DataTable dataTableRequerimientos =
                   conexion.EjecutarStoredProcedureTuplas(
                   RecursosPropuesta.ListarRequerimiento
                   ,
                   parametros);

                foreach (DataRow fila in dataTableRequerimientos.Rows)
                {
                    listaRequerimientos.Add(
                        new DominioTangerine.Requerimiento(
                           Convert.ToInt32(fila[RecursosPropuesta.ReqProp]),
                           fila[RecursosPropuesta.ReqProp].ToString(),
                           fila[RecursosPropuesta.ReqNombre].ToString()
                       )
                    );
                }
            }
            catch (Exception ex)
            {
                 throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listaRequerimientos;
        }








        /// <summary>
        /// Metodo para consultar propuesta por id (nombre)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>



        public static List<Propuesta>
         ConsultarPropuestaporNombre(String id)
        {

            //if (id == -1)
            //{
            //    throw new ExcepcionesTotem.Modulo5.
            //       ProyectoNoEncontradoException(
            //       RecursosBDModulo5.EXCEPCION_PRO_NO_ENC_CODIGO,
            //       RecursosBDModulo5.EXCEPCION_PRO_NO_ENC_MENSAJE,
            //       new Exception()
            //       );
            //}

            List<Parametro> parametros = new List<Parametro>();

            List<Propuesta> listaPropuestas =
               new List<Propuesta>();

            Parametro parametro = new Parametro(
               RecursosPropuesta.PropNombre,
               SqlDbType.Int, id.ToString(), false);
            parametros.Add(parametro);

            try
            {
                BDConexion conexion = new BDConexion();

                DataTable dataTablePropuestas =
                   conexion.EjecutarStoredProcedureTuplas(
                   RecursosPropuesta.ConsultarPropuestaNombre
                   ,
                   parametros);

                foreach (DataRow fila in dataTablePropuestas.Rows)
                {
                    listaPropuestas.Add(
                        new DominioTangerine.Propuesta(
                           Convert.ToInt32(fila[RecursosPropuesta.ReqProp]),
                           fila[RecursosPropuesta.PropDescripcion].ToString(),
                           fila[RecursosPropuesta.PropDuracion].ToString(),
                           fila[RecursosPropuesta.PropTipoDuracion].ToString(),
                           fila[RecursosPropuesta.PropAcuerdo].ToString(),
                           fila[RecursosPropuesta.PropEstatus].ToString(),
                           fila[RecursosPropuesta.PropMoneda].ToString(),
                           fila[RecursosPropuesta.PropCantidad].ToString(),
                           fila[RecursosPropuesta.PropFechaIni].ToString(),
                           fila[RecursosPropuesta.PropFechaFin].ToString(),
                           fila[RecursosPropuesta.PropCosto].ToString()
                        




                       )
                    );
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listaPropuestas;
        }






     
        
           

    


    }
}
