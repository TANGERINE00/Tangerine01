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
   public class BDProyecto
    {
        BDConexion theConnection;
        List<Parametro> parameters;
        Parametro theParam = new Parametro();

        /// <summary>
        /// Metodo para agregar un proyecto nuevo en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Proyecto para agregar en bd</param>
        /// <returns>true si fue agregado</returns>

        public Boolean AddProyecto(Proyecto TheProyecto)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();


            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                //theParam = new Parametro(ResourceProyecto.ParamId_Proyecto, SqlDbType.Int, TheProyecto.Idproyecto.ToString(), false);
                //parameters.Add(theParam);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceProyecto.ParamNombre, SqlDbType.VarChar, TheProyecto.Nombre.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamCodigo, SqlDbType.VarChar, TheProyecto.Codigo.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamFechaInicio, SqlDbType.Date, TheProyecto.Fechainicio.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamFechaEstFin, SqlDbType.Date, TheProyecto.Fechaestimadafin.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamCosto, SqlDbType.Int, TheProyecto.Costo.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamDescripcion, SqlDbType.VarChar, TheProyecto.Descripcion.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamRealizacion, SqlDbType.VarChar, TheProyecto.Realizacion.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamEstatus, SqlDbType.VarChar, TheProyecto.Estatus.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamRazon, SqlDbType.VarChar, TheProyecto.Razon.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamAcuerdoPago, SqlDbType.VarChar, TheProyecto.Acuerdopago.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamIdPropuesta, SqlDbType.Int, TheProyecto.Idpropuesta.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamIdCompania, SqlDbType.Int, TheProyecto.Idresponsable.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamIdGerente, SqlDbType.Int, TheProyecto.Idgerente.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M7_AgregarProyecto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceProyecto.AddNewProyecto, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }



        /// <summary>
        /// Metodo para eliminar un Proyecto de la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Proyecto a eliminar en bd</param>
        /// <returns>true si fue eliminado</returns>
        public Boolean DeleteProyecto(Proyecto TheProyecto)
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
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceProyecto.DeleteProyecto, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }


        /// <summary>
        /// Metodo para modificar un Proyecto en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Facturacion para modificar en bd</param>
        /// <returns>true si fue modificado</returns>
        public Boolean ChangeProyecto(Proyecto TheProyecto)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceProyecto.ParamId_Proyecto, SqlDbType.Int, TheProyecto.Idproyecto.ToString(), false);
                parameters.Add(theParam);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceProyecto.ParamNombre, SqlDbType.VarChar, TheProyecto.Nombre.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamCodigo, SqlDbType.VarChar, TheProyecto.Codigo.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamFechaInicio, SqlDbType.Date, TheProyecto.Fechainicio.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamFechaEstFin, SqlDbType.Date, TheProyecto.Fechaestimadafin.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamCosto, SqlDbType.Int, TheProyecto.Costo.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamDescripcion, SqlDbType.VarChar, TheProyecto.Descripcion.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamRealizacion, SqlDbType.VarChar, TheProyecto.Realizacion.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamEstatus, SqlDbType.VarChar, TheProyecto.Estatus.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamRazon, SqlDbType.VarChar, TheProyecto.Razon.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamAcuerdoPago, SqlDbType.VarChar, TheProyecto.Acuerdopago.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamIdPropuesta, SqlDbType.Int, TheProyecto.Idpropuesta.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamIdCompania, SqlDbType.Int, TheProyecto.Idresponsable.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceProyecto.ParamIdGerente, SqlDbType.Int, TheProyecto.Idgerente.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M7_ModificarProyecto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceProyecto.ChangeProyecto, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }


        /// <summary>
        /// Metodo para consultar un Proyecto específico que pertenecen a la base de datos.
        /// Recibe dos parametros: idProyecto que es el numero de Proyecto del mismo.
        ///                     
        /// </summary>
        /// <returns>Un objeto de tipo Proyecto</returns>
        /// <summary>
        /// Metodo para consultar una compañia en especifico.
        /// Recibe un parametros: idProyecto que es el id del Proyecto a consultar.
        /// </summary>
        /// <returns>Lista de Proyectos </returns>
        public Proyecto ContactProyecto(int idProyecto)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            Proyecto TheProyecto = new Proyecto();

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceProyecto.ParamId_Proyecto, SqlDbType.Int, idProyecto.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceProyecto.ContactProyecto, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];

                int proyId = int.Parse(row[ResourceProyecto.ProyIdProyecto].ToString());
                string proyNombre = row[ResourceProyecto.ProyNombre].ToString();
                string proyCodigo = row[ResourceProyecto.ProyCodigo].ToString();
                DateTime proyFechaInicio = DateTime.Parse(row[ResourceProyecto.ProyFechaInicio].ToString());
                DateTime proyFechaEstFin = DateTime.Parse(row[ResourceProyecto.ProyFechaEstFin].ToString());
                double proyCosto = double.Parse(row[ResourceProyecto.ProyCosto].ToString());
                String proyDescripcion = row[ResourceProyecto.ProyDescripcion].ToString();
                String proyRealizacion = row[ResourceProyecto.ProyRealizacion].ToString();
                String proyEstatus = row[ResourceProyecto.ProyEstatus].ToString();
                String proyRazon = row[ResourceProyecto.ProyRazon].ToString();
                String proyAcuerdoPago = row[ResourceProyecto.ProyAcuerdoPago].ToString();
                int proyIdPropuesta = int.Parse(row[ResourceProyecto.ProyIdPropuesta].ToString());
                int proyIdResponsable = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());
                int proyIdGerente = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());

                //Creo un objeto de tipo Proyecto con los datos de la fila y lo guardo. 
                Proyecto theProyectobeta = new Proyecto(proyId, proyNombre, proyCodigo, proyFechaInicio, proyFechaEstFin,
                                                    proyCosto, proyDescripcion, proyRealizacion, proyEstatus, proyRazon,
                                                    proyAcuerdoPago,proyIdPropuesta, proyIdResponsable, proyIdGerente);

                TheProyecto = theProyectobeta;

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return TheProyecto;
        }


        public List<Proyecto> ContactProyectos()
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            List<Proyecto> listProyecto = new List<Proyecto>();

            try
            {
                theConnection.Conectar();


                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceProyecto.ContactProyectos, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int proyId = int.Parse(row[ResourceProyecto.ProyIdProyecto].ToString());
                    string proyNombre = row[ResourceProyecto.ProyNombre].ToString();
                    string proyCodigo = row[ResourceProyecto.ProyCodigo].ToString();
                    DateTime proyFechaInicio = DateTime.Parse(row[ResourceProyecto.ProyFechaInicio].ToString());
                    DateTime proyFechaEstFin = DateTime.Parse(row[ResourceProyecto.ProyFechaEstFin].ToString());
                    double proyCosto = double.Parse(row[ResourceProyecto.ProyCosto].ToString());
                    String proyDescripcion = row[ResourceProyecto.ProyDescripcion].ToString();
                    String proyRealizacion = row[ResourceProyecto.ProyRealizacion].ToString();
                    String proyEstatus = row[ResourceProyecto.ProyEstatus].ToString();
                    String proyRazon = row[ResourceProyecto.ProyRazon].ToString();
                    String proyAcuerdoPago = row[ResourceProyecto.ProyAcuerdoPago].ToString();
                    int proyIdPropuesta = int.Parse(row[ResourceProyecto.ProyIdPropuesta].ToString());
                    int proyIdResponsable = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());
                    int proyIdGerente = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());

                    //Creo un objeto de tipo Proyecto con los datos de la fila y lo guardo. 
                    Proyecto theProyecto = new Proyecto(proyId, proyNombre, proyCodigo, proyFechaInicio, proyFechaEstFin,
                                                        proyCosto, proyDescripcion, proyRealizacion, proyEstatus, proyRazon,
                                                        proyAcuerdoPago,proyIdPropuesta, proyIdResponsable, proyIdGerente);

                    listProyecto.Add(theProyecto);

                }


            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listProyecto;
        }

       
       /// <summary>
       /// Metodo que consulta los proyecto en desarrollo con acuerdo de pago mensual, los cuales les toca facturar
       /// </summary>
       /// <returns> Lista de  Proyectos</returns>
       public List<Proyecto> ContactProyectosxAcuerdoPago()
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            List<Proyecto> listProyecto = new List<Proyecto>();

            try
            {
                theConnection.Conectar();


                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceProyecto.ContactProyectosxAcuerdoPago, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int proyId = int.Parse(row[ResourceProyecto.ProyIdProyecto].ToString());
                    string proyNombre = row[ResourceProyecto.ProyNombre].ToString();
                    string proyCodigo = row[ResourceProyecto.ProyCodigo].ToString();
                    DateTime proyFechaInicio = DateTime.Parse(row[ResourceProyecto.ProyFechaInicio].ToString());
                    DateTime proyFechaEstFin = DateTime.Parse(row[ResourceProyecto.ProyFechaEstFin].ToString());
                    double proyCosto = double.Parse(row[ResourceProyecto.ProyCosto].ToString());
                    String proyDescripcion = row[ResourceProyecto.ProyDescripcion].ToString();
                    String proyRealizacion = row[ResourceProyecto.ProyRealizacion].ToString();
                    String proyEstatus = row[ResourceProyecto.ProyEstatus].ToString();
                    String proyRazon = row[ResourceProyecto.ProyRazon].ToString();
                    String proyAcuerdoPago = row[ResourceProyecto.ProyAcuerdoPago].ToString();
                    int proyIdPropuesta = int.Parse(row[ResourceProyecto.ProyIdPropuesta].ToString());
                    int proyIdResponsable = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());
                    int proyIdGerente = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());

                    //Creo un objeto de tipo Proyecto con los datos de la fila y lo guardo. 
                    Proyecto theProyecto = new Proyecto(proyId, proyNombre, proyCodigo, proyFechaInicio, proyFechaEstFin,
                                                        proyCosto, proyDescripcion, proyRealizacion, proyEstatus, proyRazon,
                                                        proyAcuerdoPago, proyIdPropuesta, proyIdResponsable, proyIdGerente);

                    listProyecto.Add(theProyecto);

                }


            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listProyecto;
        }
      
       /// <summary>
       /// metodo para consultar los proyectos en los que trabaja un empleado
       /// </summary>
       /// <returns></returns>
       public List<Proyecto> ContactProyectoPorEmpleado(int IdEmpleado)
       {
           parameters = new List<Parametro>();
           theConnection = new BDConexion();

           List<Proyecto> listProyecto = new List<Proyecto>();

           try
           {
               theParam = new Parametro(ResourceProyecto.ParamPEIdEmpleado, SqlDbType.Int, IdEmpleado.ToString(), false);
               parameters.Add(theParam);
               theConnection.Conectar();


               //Guardo la tabla que me regresa el procedimiento de consultar contactos
               DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceProyecto.ContactProyectoPorEmpleado, parameters);

               //Guardar los datos 
               foreach (DataRow row in dt.Rows)
               {

                   int proyId = int.Parse(row[ResourceProyecto.ProyIdProyecto].ToString());
                   string proyNombre = row[ResourceProyecto.ProyNombre].ToString();
                   string proyCodigo = row[ResourceProyecto.ProyCodigo].ToString();
                   DateTime proyFechaInicio = DateTime.Parse(row[ResourceProyecto.ProyFechaInicio].ToString());
                   DateTime proyFechaEstFin = DateTime.Parse(row[ResourceProyecto.ProyFechaEstFin].ToString());
                   double proyCosto = double.Parse(row[ResourceProyecto.ProyCosto].ToString());
                   String proyDescripcion = row[ResourceProyecto.ProyDescripcion].ToString();
                   String proyRealizacion = row[ResourceProyecto.ProyRealizacion].ToString();
                   String proyEstatus = row[ResourceProyecto.ProyEstatus].ToString();
                   String proyRazon = row[ResourceProyecto.ProyRazon].ToString();
                   String proyAcuerdoPago = row[ResourceProyecto.ProyAcuerdoPago].ToString();
                   int proyIdPropuesta = int.Parse(row[ResourceProyecto.ProyIdPropuesta].ToString());
                   int proyIdResponsable = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());
                   int proyIdGerente = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());

                   //Creo un objeto de tipo Proyecto con los datos de la fila y lo guardo. 
                   Proyecto theProyecto = new Proyecto(proyId, proyNombre, proyCodigo, proyFechaInicio, proyFechaEstFin,
                                                       proyCosto, proyDescripcion, proyRealizacion, proyEstatus, proyRazon,
                                                       proyAcuerdoPago, proyIdPropuesta, proyIdResponsable, proyIdGerente);

                   listProyecto.Add(theProyecto);

               }


           }
           catch (Exception ex)
           {
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
           }

           return listProyecto;
       } 
    }
}
