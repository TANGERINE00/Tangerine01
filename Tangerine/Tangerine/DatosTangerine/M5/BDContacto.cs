using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;

namespace DatosTangerine.M5
{
    public class BDContacto
    {
        BDConexion theConnection;
        List<Parametro> parameters;
        Parametro theParam = new Parametro();

        /// <summary>
        /// Metodo para agregar una contacton nuevo en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Contacto para agregar en bd</param>
        /// <returns>true si fue agregado</returns>
        public Boolean AddContact(Contacto theContact)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceContact.ParamName, SqlDbType.VarChar, theContact.Nombre,false);
                parameters.Add(theParam);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceContact.ParamLName, SqlDbType.VarChar, theContact.Apellido, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamDepa, SqlDbType.VarChar, theContact.Departamento, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamRol, SqlDbType.VarChar, theContact.Cargo, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamTele, SqlDbType.VarChar, theContact.Telefono, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamEmail, SqlDbType.VarChar, theContact.Correo, false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamTComp, SqlDbType.Int, theContact.TipoCompañia.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamIdComp, SqlDbType.Int, theContact.IdCompañia.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceContact.AddNewContact, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }


        /// <summary>
        /// Metodo para eliminar una contacto de la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Contacto a eliminar en bd</param>
        /// <returns>true si fue eliminado</returns>
        public Boolean DeleteContact(Contacto theContact)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceContact.ParamId, SqlDbType.Int, theContact.IdContacto.ToString(), false);
                parameters.Add(theParam);

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceContact.DeleteContact, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

    }
}
