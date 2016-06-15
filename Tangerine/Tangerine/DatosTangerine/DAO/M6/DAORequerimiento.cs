using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DatosTangerine.M6;
using DatosTangerine.InterfazDAO.M6;
using DominioTangerine;
using DominioTangerine.Entidades.M6;
using ExcepcionesTangerine;

namespace DatosTangerine.DAO.M6
{
    public class DAORequerimiento : DAOGeneral, IDAORequerimiento
    {

        #region IDAO

        /// <summary>
        /// Metodo para agregar una propuesta en la base de datos.
        /// </summary>
        ///  <param name="parametro">objeto de tipo Propuesta para agregar en BD</param>
        ///  <param name="theConnection">Objeto de tipo BDConexion para la conexion a la BD</param>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>true si fue agregado</returns>
        public bool Agregar(Entidad elRequerimiento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
                RecursosPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            DominioTangerine.Entidades.M6.Requerimiento requerimiento = (DominioTangerine.Entidades.M6.Requerimiento)elRequerimiento;

            List<Parametro> parametros = new List<Parametro>();
            Parametro parametro = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                parametro = new Parametro(RecursosPropuesta.ParamCodigoReq, SqlDbType.VarChar, requerimiento.CodigoRequerimiento, false);
                parametros.Add(parametro);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                parametro = new Parametro(RecursosPropuesta.ParamDescriReq, SqlDbType.VarChar, requerimiento.Descripcion, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamIdPropuestaReq, SqlDbType.VarChar, requerimiento.CodigoPropuesta, false);
                parametros.Add(parametro);

                //Se manda a ejecutar en BDConexion el stored procedure M6_AgregarRequerimiento y todos los parametros que recibe
                List<Resultado> resultado = EjecutarStoredProcedure(RecursosPropuesta.AgregarRequerimiento, parametros);

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return true;
        }


        /// <summary>
        /// Metodo que permite modificar una propuesta en la BD
        /// </summary>
        /// <param name="propuesta"></param>
        /// <returns></returns>
        public Boolean Modificar(Entidad elRequerimiento)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, 
               RecursosPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            DominioTangerine.Entidades.M6.Requerimiento requerimiento = (DominioTangerine.Entidades.M6.Requerimiento)elRequerimiento;
            List<Parametro> parameters = new List<Parametro>();
            Parametro theParam = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                theParam = new Parametro(RecursosPropuesta.ReqDescripcion, SqlDbType.VarChar, requerimiento.Descripcion, false);
                parameters.Add(theParam);

                theParam = new Parametro(RecursosPropuesta.ReqPropNombre, SqlDbType.VarChar, requerimiento.CodigoRequerimiento, false);
                parameters.Add(theParam);

                List<Resultado> results = EjecutarStoredProcedure(RecursosPropuesta.Modificar_Requerimiento, parameters);

            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }

            return true;
        }


        /// <summary>
        /// Metodo para consultar propuesta por id (nombre)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entidad ConsultarXId(Entidad id)
        {
            Entidad requerimiento = null;

            return requerimiento;
        }


        /// <summary>
        /// Metodo que consulta todas las propuestas
        /// </summary>
        ///
        /// <returns>Retorna la lista de propuestas</returns>
        public List<Entidad> ConsultarTodos()
        {
            List<Entidad> listaRequerimiento = new List<Entidad>();

            return listaRequerimiento;
        }

        #endregion


        #region IDAORequerimiento

        /// <summary>
        /// Método para listar los requerimientos por propuesta 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Entidad> ConsultarRequerimientosXPropuesta(String id)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursosPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parametros = new List<Parametro>();

            List<Entidad> listaRequerimientos = new List<Entidad>();

            Parametro parametro = new Parametro(RecursosPropuesta.ReqPropNombre, SqlDbType.VarChar, id, false);
            parametros.Add(parametro);

            try
            {
                DataTable dataTableRequerimientos = EjecutarStoredProcedureTuplas(RecursosPropuesta.ListarRequerimiento, parametros);

                foreach (DataRow fila in dataTableRequerimientos.Rows)
                {
                    listaRequerimientos.Add(DominioTangerine.Fabrica.FabricaEntidades.ObtenerRequerimiento(
                        id,
                        fila[RecursosPropuesta.ReqCodigo].ToString(),
                        fila[RecursosPropuesta.ReqDescripcion].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listaRequerimientos;
        }
        
        #endregion

    }
}
