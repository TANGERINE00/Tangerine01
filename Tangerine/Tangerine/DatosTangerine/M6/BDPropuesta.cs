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
        /// Metodo para agregar un Requerimiento en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Requerimiento para agregar en bd</param>
        /// <returns>true si fue agregado</returns>


        public static bool agregarRequerimiento(Requerimiento elRequerimiento)
        {
            List<Parametro> parametros = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro parametro = new Parametro();

            try
            {
            //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
            //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                parametro = new Parametro(RecursosPropuesta.ParamCodigoReq, SqlDbType.VarChar, elRequerimiento.CodigoRequerimiento, false);
                parametros.Add(parametro);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                parametro = new Parametro(RecursosPropuesta.ParamDescriReq, SqlDbType.VarChar, elRequerimiento.Descripcion, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamIdPropuestaReq, SqlDbType.VarChar, elRequerimiento.CodigoPropuesta, false);
                parametros.Add(parametro);


                //Se manda a ejecutar en BDConexion el stored procedure M6_AgregarRequerimiento y todos los parametros que recibe
                List<Resultado> resultado = theConnection.EjecutarStoredProcedure(RecursosPropuesta.AgregarRequerimiento, parametros);

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





        public  List<Propuesta> PropuestaProyecto()
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
                    String codigonumP = row[RecursosPropuesta.PropCodigo].ToString();
                    String conNombre = row[RecursosPropuesta.PropNombre].ToString();
                    String conDescripcion = row[RecursosPropuesta.PropDescripcion].ToString();
                    String contipoDuracion = row[RecursosPropuesta.PropTipoDuracion].ToString();
                    String conDuracion = row[RecursosPropuesta.PropDuracion].ToString();
                    String conAcuerdo = row[RecursosPropuesta.PropAcuerdo].ToString();
                    String conEstatus = row[RecursosPropuesta.PropEstatus].ToString();
                    String conMoneda = row[RecursosPropuesta.PropMoneda].ToString();
                    int conEntregas = Convert.ToInt32(row[RecursosPropuesta.PropCantidad]);
                    DateTime conFechaIni = Convert.ToDateTime(row[RecursosPropuesta.PropFechaIni]);
                    DateTime conFechaFin = Convert.ToDateTime(row[RecursosPropuesta.PropFechaFin]);
                    int conCosto = Convert.ToInt32(row[RecursosPropuesta.PropCosto]);
                    String conFkComp = row[RecursosPropuesta.PropIdCompania].ToString();


                      
                    //Creo un objeto de tipo Propuesta con los datos de la fila y lo guardo en una lista de propuestas
                    Propuesta propuestas = new Propuesta(codigonumP,conNombre, conDescripcion, contipoDuracion, conDuracion,
                        conAcuerdo, conEstatus, conMoneda, conEntregas, conFechaIni, conFechaFin, conCosto, conFkComp);
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
        /// Metodo que consulta todas las propuestas
        /// </summary>
        ///
        /// <returns>Retorna la lista de propuestas</returns>





        public static List<Propuesta> ListarLasPropuestas()
        {
            List<Parametro> parametros = new List<Parametro>();
            List<Propuesta> listaPropuesta = new List<Propuesta>();
            BDConexion theConnection = new BDConexion();
            Parametro parametro = new Parametro();


            try
            {
                theConnection.Conectar();

                //Guardo la tabla que me regresa el procedimiento de consultar propuestas
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(RecursosPropuesta.ConsultarTodasPropuestas, parametros);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    String conNombre = row[RecursosPropuesta.PropNombre].ToString();
                    String conDescripcion = row[RecursosPropuesta.PropDescripcion].ToString();
                    String contipoDuracion = row[RecursosPropuesta.PropTipoDuracion].ToString();
                    String conDuracion = row[RecursosPropuesta.PropDuracion].ToString();
                    String conAcuerdo = row[RecursosPropuesta.PropAcuerdo].ToString();
                    String conEstatus = row[RecursosPropuesta.PropEstatus].ToString();
                    String conMoneda = row[RecursosPropuesta.PropMoneda].ToString();
                    int conEntregas = Convert.ToInt32(row[RecursosPropuesta.PropCantidad]);
                    DateTime conFechaIni = Convert.ToDateTime(row[RecursosPropuesta.PropFechaIni]);
                    DateTime conFechaFin = Convert.ToDateTime(row[RecursosPropuesta.PropFechaFin]);
                    int conCosto = Convert.ToInt32(row[RecursosPropuesta.PropCosto]);
                    String conFkComp = row[RecursosPropuesta.PropIdCompania].ToString();



                    //Creo un objeto de tipo Propuesta con los datos de la fila y lo guardo en una lista de propuestas
                    Propuesta propuestas = new Propuesta(conNombre, conDescripcion, contipoDuracion, conDuracion,
                        conAcuerdo, conEstatus, conMoneda, conEntregas, conFechaIni, conFechaFin, conCosto, conFkComp);
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




        public static List<Requerimiento> ConsultarRequerimientosPorPropuesta(String id)
        {

            List<Parametro> parametros = new List<Parametro>();

            List<Requerimiento> listaRequerimientos =
               new List<Requerimiento>();

            Parametro parametro = new Parametro(
               RecursosPropuesta.ReqPropNombre,
               SqlDbType.VarChar, id, false);
            parametros.Add(parametro);

            try
            {
                BDConexion conexion = new BDConexion();

                DataTable dataTableRequerimientos =
                   conexion.EjecutarStoredProcedureTuplas(RecursosPropuesta.ListarRequerimiento,parametros);

                foreach (DataRow fila in dataTableRequerimientos.Rows)
                {
                    listaRequerimientos.Add(
                        new DominioTangerine.Requerimiento(
                          fila[RecursosPropuesta.ReqCodigo].ToString(),
                          fila[RecursosPropuesta.ReqDescripcion].ToString()

                          
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



        public static Propuesta ConsultarPropuestaporNombre(String id)



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

           

            Parametro parametro = new Parametro(
               RecursosPropuesta.Prop_Nombre,
               SqlDbType.VarChar, id, false);
            parametros.Add(parametro);

            //try
            //{
                BDConexion conexion = new BDConexion();

                DataTable dataTablePropuestas =
                   conexion.EjecutarStoredProcedureTuplas(
                   RecursosPropuesta.ConsultarPropuestaNombre
                   ,
                   parametros);

                 Propuesta propuesta = null;

                foreach (DataRow fila in dataTablePropuestas.Rows)
                {
                    
                      propuesta=  new DominioTangerine.Propuesta(
                           
                           fila[RecursosPropuesta.PropDescripcion].ToString(),
                           fila[RecursosPropuesta.PropDuracion].ToString(),
                           fila[RecursosPropuesta.PropTipoDuracion].ToString(),
                           fila[RecursosPropuesta.PropAcuerdo].ToString(),
                           fila[RecursosPropuesta.PropEstatus].ToString(),
                           fila[RecursosPropuesta.PropMoneda].ToString(),
                           Convert.ToInt32(fila[RecursosPropuesta.PropCantidad]),
                           Convert.ToDateTime(fila[RecursosPropuesta.PropFechaIni]),
                           Convert.ToDateTime(fila[RecursosPropuesta.PropFechaFin]),
                           Convert.ToInt32(fila[RecursosPropuesta.PropCosto]),
                           fila[RecursosPropuesta.PropIdCompania].ToString()


                    );
                }
            //}
            ////catch (Exception ex)
            ////{
            ////    throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            ////}

            return propuesta;
        }


        /// <summary>
        /// Metodo para eliminar una Propuesta de la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Contacto a eliminar en bd</param>
        /// <returns>true si fue eliminado</returns>
        public static Boolean BorrarPropuesta(string nombrePropuesta)
        {
           
            /*
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                ResourceContact.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);
            */

            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(RecursosPropuesta.Prop_Nombre, SqlDbType.VarChar, nombrePropuesta, false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(RecursosPropuesta.EliminarPropuesta, parameters);

            }
            catch (SqlException ex)
            {
               // Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }
            catch (FormatException ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.M5.WrongFormatException(RecursosPropuesta.ReqPropNombre,
                     RecursosPropuesta.Mensaje_Error_Formato, ex);
            }
            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }
            catch (Exception ex)
            {
                //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }
            //Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                //RecursosPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }






        //public static Boolean Modificar_Requerimiento (Requerimiento elrequerimiento) 
        //{
        //    List<Parametro> parameters = new List<Parametro>();
        //    BDConexion Connection = new BDConexion();
        //    Parametro theParam = new Parametro();

        //    try
        //    {
        //        //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
        //        //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)


               
        //        theParam = new Parametro(RecursosPropuesta.ReqDescripcion, SqlDbType.VarChar, elrequerimiento.Descripcion, false);
        //        parameters.Add(theParam);

        //        theParam = new Parametro(RecursosPropuesta.ReqNombre, SqlDbType.VarChar, elrequerimiento.CodigoRequerimiento, false);
        //        parameters.Add(theParam);
                

                

        //        //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
        //        List<Resultado> results = Connection.EjecutarStoredProcedure(RecursosPropuesta.Modificar_Requerimiento, parameters);

        //    }
        //    catch (SqlException ex)
        //    {
        //        //Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

        //        throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoGeneralBD.Codigo,
        //            RecursoGeneralBD.Mensaje, ex);
        //    }
            
     
        //    return true;
        //}







    }
}
