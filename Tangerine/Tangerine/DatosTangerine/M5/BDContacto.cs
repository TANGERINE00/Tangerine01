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

        public Boolean AddContact(Contacto theContact)
        {
            parameters = new List<Parametro>();
            theConnection = new BDConexion();

            try
            {
                
                theParam = new Parametro(ResourceContact.ParamName, SqlDbType.VarChar, theContact.Nombre,false);
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

                theParam = new Parametro(ResourceContact.ParamTComp, SqlDbType.Int, theContact.TipoCompañia.ToString(), false);
                parameters.Add(theParam);

                theParam = new Parametro(ResourceContact.ParamIdComp, SqlDbType.Int, theContact.IdCompañia.ToString(), false);
                parameters.Add(theParam);

                List<Resultado> results = theConnection.EjecutarStoredProcedure(ResourceContact.AddNewContact, parameters);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }


    }
}
