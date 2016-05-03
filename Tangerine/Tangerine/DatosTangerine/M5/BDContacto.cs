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
        /// Metodo para agregar una contacto nuevo en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Contacto para agregar en bd</param>
        /// <returns>true si fue agregado</returns>
        public static bool AddContact(Contacto theContact)
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro theParam = new Parametro();

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
        /// Metodo para eliminar un contacto de la base de datos.
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

        /// <summary>
        /// Metodo para modificar un contacto en la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Contacto para modificar en bd</param>
        /// <returns>true si fue modificado</returns>
        public Boolean ChangeContact(Contacto theContact)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(ResourceContact.ParamId, SqlDbType.Int, theContact.IdContacto.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamName, SqlDbType.VarChar, theContact.Nombre, false);
                parameters.Add(theParam);

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

                //Se manda a ejecutar en BDConexion el stored procedure M5_AgregarContacto y todos los parametros que recibe
                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceContact.ChangeContact, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }

        /// <summary>
        /// Metodo para consultar todos los Contactos que pertenecen a una Empresa.
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

                theParam = new Parametro(ResourceContact.ParamTComp, SqlDbType.Int, typeCompany.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamIdComp, SqlDbType.Int, idCompany.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourceContact.ContactCompany, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    int conId = int.Parse(row[ResourceContact.ConIdContact].ToString());
                    String conName = row[ResourceContact.ConNameContact].ToString();
                    String conLName = row[ResourceContact.ConLastNameContact].ToString();
                    String conDepart = row[ResourceContact.ConDepartmentContact].ToString();
                    String conRol = row[ResourceContact.ConRolContact].ToString();
                    String conTele = row[ResourceContact.ConPhoneContact].ToString();
                    String conEmail = row[ResourceContact.ConEmailContact].ToString();
                    int conTypeC = int.Parse(row[ResourceContact.ConTypeComp].ToString());
                    int conCompId = int.Parse(row[ResourceContact.ConIdComp].ToString());

                    //Creo un objeto de tipo Contacto con los datos de la fila y lo guardo en una lista de contactos
                    Contacto theContact = new Contacto(conId, conName, conLName, conDepart, conRol, conTele, conEmail, conTypeC, conCompId);
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
}
