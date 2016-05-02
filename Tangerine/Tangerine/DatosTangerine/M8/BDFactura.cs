/*using System;
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
    public class BDContacto
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
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int, theFactura._idNumeroFactura, false);
                parameters.Add(theParam);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamFecha_Emision, SqlDbType.Date, theFactura._fecha, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Total, SqlDbType.Int, theFactura._monto, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Restante, SqlDbType.Int, theFactura._montoRestante, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamDescripcion, SqlDbType.Int, theFactura._descripcion, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamProyectoId, SqlDbType.Int, theFactura._idProyecto, false);
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
        public Boolean DeleteContact(Facturacion theFactura)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int, theFactura._idNumeroFactura, false);
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
        public Boolean ChangeContact(Facturacion theFactura)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceFactura.ParamIdFactura, SqlDbType.Int, theFactura. , false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamFecha_Emision, SqlDbType.Date, theFactura._fecha, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Total, SqlDbType.Int, theFactura._monto, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamMonto_Restante, SqlDbType.Int, theFactura._montoRestante, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamDescripcion, SqlDbType.Int, theFactura._descripcion, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamProyectoId, SqlDbType.Int, theFactura._idProyecto, false);
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
/*
        /// <summary>
        /// Metodo para consultar todos los Factura que pertenecen a una Empresa.
        /// Recibe dos parametros: typeCompany que es 1 si es Compania o 2 si es Cliente Potencial (Lead)
        ///                        idCompany que es el id de la Empresa (Compania o Lead)
        /// </summary>
        /// <returns>Lista de contactos de la Empresa</returns>
        public List<Contacto> ContactCompany(int typeCompany, int idCompany)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            List<Contacto> listContact = new List<Contacto>();

            try
            {
                theConnection.Conectar();

                theParam = new Parametro(ResourceFactura.ParamTComp, SqlDbType.Int, typeCompany.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceFactura.ParamIdComp, SqlDbType.Int, idCompany.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceFactura.ContactCompany, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    int facId = int.Parse(row[ResourceFactura.Fac_IdFactura].ToString());
                    String facFechaEmsion = row[ResourceFactura.Fac_FechaEmision].ToString();
                    String facMontoTotal = row[ResourceFactura.Fac_MontoTotal].ToString();
                    String facMontoRestante = row[ResourceFactura.Fac_MontoRestante].ToString();
                    String facIdProyecto = row[ResourceFactura.Fac_IdProyecto].ToString();
                   int conTypeC = int.Parse(row[ResourceFactura.ConTypeComp].ToString()); ////////////////////////////////////////
                    int conCompId = int.Parse(row[ResourceFactura.ConIdComp].ToString()); //////////////////////////////////////// 

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    Facturacion theFactura = new Factura(conId, conName, conLName, conDepart, conRol, conTele, conEmail);
                    listContact.Add(theContact);
                }

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listContact;
        }
    }
}*/
