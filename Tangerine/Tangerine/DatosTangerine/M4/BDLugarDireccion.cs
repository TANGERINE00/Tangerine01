using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DominioTangerine;

namespace DatosTangerine.M4
{
    public class BDLugarDireccion
    {
        BDConexion theConnection;
        List<Parametro> parameters;
        Parametro theParam = new Parametro();

        /// <summary>
        /// Metodo para consultar todos los Lugares tipo ciudad registradas en la BD.
        /// Recibe cero parametros.
        /// </summary>
        /// <returns>Lista de Lugares registrados</returns>
        public static List<LugarDireccion> ConsultPlaces()
        {
            List<Parametro> parameters = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            List<LugarDireccion> listPlace = new List<LugarDireccion>();

            try
            {
                theConnection.Conectar();

                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = theConnection.EjecutarStoredProcedureTuplas(ResourcePlace.ConsultPlaces, parameters);

                //Por cada fila de la tabla voy a guardar los datos 
                foreach (DataRow row in dt.Rows)
                {

                    int lugId = int.Parse(row[ResourcePlace.LugIdPlace].ToString());
                    String lugName = row[ResourcePlace.LugNamePlace].ToString();

                    LugarDireccion thePlace = new LugarDireccion(lugId, lugName);
                    listPlace.Add(thePlace);
                }

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listPlace;
        }

    }

}
