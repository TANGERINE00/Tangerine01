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
        public Boolean AddFactura(Facturacion theFactura)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();
            

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int, theFactura.idFactura.ToString(), false);
                parameters.Add(theParam);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamFecha_Emision, SqlDbType.Date, theFactura.fechaFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Total, SqlDbType.Int, theFactura.montoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Restante, SqlDbType.Int, theFactura.montoRestanteFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamDescripcion, SqlDbType.Int, theFactura.descripcionFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int, theFactura.idProyectoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int, theFactura.idCompaniaFactura.ToString(), false);
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
        public Boolean DeleteFactura(Facturacion theFactura)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

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
        public Boolean ChangeFactura(Facturacion theFactura)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int, theFactura.idFactura.ToString() , false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamFecha_Emision, SqlDbType.Date, theFactura.fechaFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Total, SqlDbType.Int, theFactura.montoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Restante, SqlDbType.Int, theFactura.montoRestanteFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamDescripcion, SqlDbType.Int, theFactura.descripcionFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int, theFactura.idProyectoFactura.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdProyecto, SqlDbType.Int, theFactura.idCompaniaFactura.ToString(), false);
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
        public Facturacion ContactFactura(int idFactura)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

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
                int facMonto = int.Parse(row[ResourceFactura.FacMontoTotal].ToString());
                int facMontoRestante = int.Parse(row[ResourceFactura.FacMontoRestante].ToString());
                String facDescripcion = row[ResourceFactura.FacDescripcion].ToString();
                int facIdProyecto = int.Parse(row[ResourceFactura.FacIdProyecto].ToString());
                int facIdCompania = int.Parse(row[ResourceFactura.FacIdCompania].ToString());

                //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                Facturacion theFacturabeta = new Facturacion(facId, facFecha, facMonto, facMontoRestante, facDescripcion,
                                                    facIdProyecto, facIdCompania);

                theFactura = theFacturabeta;

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return theFactura;
        }

        public List<Facturacion> ContactFacturas()
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            List<Facturacion> listFactura = new List<Facturacion>();

            try
            {
                theConnection.Conectar();


                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceFactura.ContactFactura, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int facId = int.Parse(row[ResourceFactura.FacIdFactura].ToString());
                    DateTime facFecha = DateTime.Parse(row[ResourceFactura.FacFechaEmision].ToString());
                    int facMonto = int.Parse(row[ResourceFactura.FacMontoTotal].ToString());
                    int facMontoRestante = int.Parse(row[ResourceFactura.FacMontoRestante].ToString());
                    String facDescripcion = row[ResourceFactura.FacDescripcion].ToString();
                    int facIdProyecto = int.Parse(row[ResourceFactura.FacIdProyecto].ToString());
                    int facIdCompania = int.Parse(row[ResourceFactura.FacIdCompania].ToString());

                    //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                    Facturacion theFactura = new Facturacion(facId, facFecha, facMonto, facMontoRestante, facDescripcion,
                                                        facIdProyecto, facIdCompania);
                    listFactura.Add(theFactura);

                }


            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listFactura;
        }

    }
}
