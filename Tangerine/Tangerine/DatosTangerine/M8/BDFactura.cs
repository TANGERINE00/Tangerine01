using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;

namespace DatosTangerine.M8
{
    public class BDFactura
    {
        BDConexion theConnection;
        List<Parametro> parameters;
        Parametro theParam = new Parametro();

        /// <summary>
        /// Metodo para agregar una factura nuevo en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Facturacion para agregar en bd</param>
        /// <returns>true si fue agregado</returns>
        public static bool AddFactura( Facturacion theFactura )
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamFecha_Emision, SqlDbType.DateTime, theFactura.fechaFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Total, SqlDbType.Int, theFactura.montoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Restante, SqlDbType.Int, theFactura.montoRestanteFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamDescripcion, SqlDbType.VarChar, theFactura.descripcionFactura, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamEstatus, SqlDbType.Int, theFactura.estatusFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int, theFactura.idProyectoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdCompania, SqlDbType.Int, theFactura.idCompaniaFactura.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M8_AgregarFactura y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceFactura.AddNewFactura, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

        /// <summary>
        /// Metodo para eliminar un factura de la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Facturacion a eliminar en bd</param>
        /// <returns>true si fue eliminado</returns>
        public static bool DeleteFactura( Facturacion theFactura )
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int, theFactura.idFactura.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M8_AgregarFactura y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceFactura.DeleteFactura, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

        /// <summary>
        /// Metodo para modificar un factura en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Facturacion para modificar en bd</param>
        /// <returns>true si fue modificado</returns>
        public static bool ChangeFactura( Facturacion theFactura )
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int, theFactura.idFactura.ToString(), false);
                parameters.Add(theParam);
                
                theParam = new Parametro(ResourceFactura.ParamFecha_Emision, SqlDbType.DateTime, theFactura.fechaFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Total, SqlDbType.Int, theFactura.montoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Restante, SqlDbType.Int, theFactura.montoRestanteFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamDescripcion, SqlDbType.VarChar, theFactura.descripcionFactura, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamEstatus, SqlDbType.Int, theFactura.estatusFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int, theFactura.idProyectoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdCompania, SqlDbType.Int, theFactura.idCompaniaFactura.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M8_ModificarFactura y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceFactura.ChangeFactura, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

        /// <summary>
        /// Metodo para consultar una Factura específica que pertenecen a la base de datos.
        /// Recibe dos parametros: idFactura que es el numero de factura de la misma.
        ///                     
        /// </summary>
        /// <returns>Un objeto de tipo Facturacion</returns>
        /// <summary>
        /// Metodo para consultar una compañia en especifico.
        /// Recibe un parametros: idFactura que es el id de la Factura a consultar.
        /// </summary>
        /// <returns>Lista de facturas </returns>
        public static Facturacion ContactFactura( int idFactura )
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            Facturacion theFactura = new Facturacion();

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int, idFactura.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceFactura.ContactFactura, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];

                int facId = int.Parse(row[ResourceFactura.FacIdFactura].ToString());
                DateTime facFecha = DateTime.Parse(row[ResourceFactura.FacFechaEmision].ToString());
                double facMonto = double.Parse(row[ResourceFactura.FacMontoTotal].ToString());
                double facMontoRestante = double.Parse(row[ResourceFactura.FacMontoRestante].ToString());
                String facDescripcion = row[ResourceFactura.FacDescripcion].ToString();
                int facEstatus = int.Parse(row[ResourceFactura.FacEstatus].ToString());
                int facIdProyecto = int.Parse(row[ResourceFactura.FacIdProyecto].ToString());
                int facIdCompania = int.Parse(row[ResourceFactura.FacIdCompania].ToString());

                //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                Facturacion theFacturabeta = new Facturacion(facId, facFecha, facMonto, facMontoRestante, facDescripcion,
                                                    facEstatus, facIdProyecto, facIdCompania);

                theFactura = theFacturabeta;

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return theFactura;
        }
        public static List<Facturacion> ContactFacturas()
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            List<Facturacion> listFactura = new List<Facturacion>();

            try
            {
                theConnection.Conectar();


                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceFactura.ConsultFacturas, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int facId = int.Parse(row[ResourceFactura.FacIdFactura].ToString());
                    DateTime facFecha = DateTime.Parse(row[ResourceFactura.FacFechaEmision].ToString());
                    double facMonto = double.Parse(row[ResourceFactura.FacMontoTotal].ToString());
                    double facMontoRestante = double.Parse(row[ResourceFactura.FacMontoRestante].ToString());
                    String facDescripcion = row[ResourceFactura.FacDescripcion].ToString();
                    int facEstatus = int.Parse(row[ResourceFactura.FacEstatus].ToString());
                    int facIdProyecto = int.Parse(row[ResourceFactura.FacIdProyecto].ToString());
                    int facIdCompania = int.Parse(row[ResourceFactura.FacIdCompania].ToString());

                    //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                    Facturacion theFactura = new Facturacion(facId, facFecha, facMonto, facMontoRestante, facDescripcion,
                                                        facEstatus, facIdProyecto, facIdCompania);
                    listFactura.Add(theFactura);

                }


            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listFactura;
        }

        public static Compania ConsultCompany( int idCompany )
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

            Compania theCompany = new Compania();

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceFactura.ParamId, SqlDbType.Int, idCompany.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceFactura.ConsultCompany, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];


                String comName = row[ResourceFactura.ComNameCompany].ToString();
                int comId = 0;
                String comRif = null;
                String comEmail = null;
                String comTelefono = null;
                String comAcronym = null;
                DateTime comRegisterDate = DateTime.Now;
                int comStatus = 0;
                int comIdPlace = 0;

                //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                Compania theCompanybeta = new Compania(comId, comName, comRif, comEmail, comTelefono, comAcronym,
                                                    comRegisterDate, comStatus, comIdPlace);

                theCompany = theCompanybeta;

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return theCompany;
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
        public static Proyecto ContactProyectoFactura( int idProyecto )
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();
            Proyecto TheProyecto = new Proyecto();

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceFactura.ParamId_Proyecto, SqlDbType.Int, idProyecto.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceFactura.ContactProyecto, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];

                int proyId = 0;
                string proyNombre = row[ResourceFactura.ProyNombre].ToString();
                string proyCodigo = null;
                DateTime proyFechaInicio = DateTime.Now;
                DateTime proyFechaEstFin = DateTime.Now;
                double proyCosto = 0;
                String proyDescripcion = null;
                String proyRealizacion = null;
                String proyEstatus = null;
                String proyRazon = null;
                String proyAcuerdoPago = null;
                int proyIdPropuesta = 0;
                int proyIdResponsable = 0;
                int proyIdGerente = 0;

                //Creo un objeto de tipo Proyecto con los datos de la fila y lo guardo. 
                Proyecto theProyectobeta = new Proyecto(proyId, proyNombre, proyCodigo, proyFechaInicio, proyFechaEstFin,
                                                    proyCosto, proyDescripcion, proyRealizacion, proyEstatus, proyRazon,
                                                    proyAcuerdoPago, proyIdPropuesta, proyIdResponsable, proyIdGerente);

                TheProyecto = theProyectobeta;

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return TheProyecto;
        }

    }
}
