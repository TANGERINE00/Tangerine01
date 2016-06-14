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
    public class DAOPropuesta : DAOGeneral, IDAOPropuesta
    {

        #region IDAO

        /// <summary>
        /// Metodo para agregar una propuesta en la base de datos.
        /// </summary>
        ///  <param name="parametro">objeto de tipo Propuesta para agregar en BD</param>
        ///  <param name="theConnection">Objeto de tipo BDConexion para la conexion a la BD</param>
        ///  <param name="parametros">objeto de tipo lista parametro para la captura de los campos</param>
        /// <returns>true si fue agregado</returns>
        public bool Agregar(Entidad laPropuesta)
        {
            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosPropuesta.MensajeInicioInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            DominioTangerine.Entidades.M6.Propuesta propuesta = (DominioTangerine.Entidades.M6.Propuesta)laPropuesta;

            List<Parametro> parametros = new List<Parametro>();
            BDConexion theConnection = new BDConexion();
            Parametro parametro = new Parametro();

            try
            {
                //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
                //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
                parametro = new Parametro(RecursosPropuesta.ParamNombreProp, SqlDbType.VarChar, propuesta.Nombre, false);
                parametros.Add(parametro);

                //Parametro recibe (nombre del SEGUNDO parametro en su stored procedure, el tipo de dato, el valor, false)
                parametro = new Parametro(RecursosPropuesta.ParamDescriProp, SqlDbType.VarChar, propuesta.Descripcion, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamTipoDuProp, SqlDbType.VarChar, propuesta.TipoDuracion, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamDuracProp, SqlDbType.VarChar, propuesta.CantDuracion, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamFechaIProp, SqlDbType.Date, propuesta.Feincio.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamFechaFProp, SqlDbType.Date, propuesta.Fefinal.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamEstatusProp, SqlDbType.VarChar, propuesta.Estatus, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamMonedaProp, SqlDbType.VarChar, propuesta.Moneda, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamAcuerdoProp, SqlDbType.VarChar, propuesta.Acuerdopago, false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamCantidaProp, SqlDbType.Int, propuesta.Entrega.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamCostoProp, SqlDbType.Int, propuesta.Costo.ToString(), false);
                parametros.Add(parametro);

                parametro = new Parametro(RecursosPropuesta.ParamIdCompa, SqlDbType.Int, propuesta.IdCompañia.ToString(), false);
                parametros.Add(parametro);

                //Se manda a ejecutar en BDConexion el stored procedure M6_AgregarPropuesta y todos los parametros que recibe
                List<Resultado> resultado = theConnection.EjecutarStoredProcedure(RecursosPropuesta.AgregarPropuesta, parametros);
            }
            catch (SqlException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw new ExcepcionesTangerine.ExceptionTGConBD(RecursoGeneralBD.Codigo,
                    RecursoGeneralBD.Mensaje, ex);
            }

            catch (ExcepcionesTangerine.ExceptionTGConBD ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);

                throw ex;
            }

            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            Logger.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
                RecursosPropuesta.MensajeFinInfoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            return true;
        }


        /// <summary>
        /// Metodo que permite modificar una propuesta en la BD
        /// </summary>
        /// <param name="propuesta"></param>
        /// <returns></returns>
        public Boolean Modificar(Entidad propuesta)
        {
            return true;
        }


        /// <summary>
        /// Metodo para consultar propuesta por id (nombre)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Entidad ConsultarXId(Entidad id)
        {
            Entidad propuesta = null;

            return propuesta;
        }


        /// <summary>
        /// Metodo que consulta todas las propuestas
        /// </summary>
        ///
        /// <returns>Retorna la lista de propuestas</returns>
        public List<Entidad> ConsultarTodos()
        {
            List<Entidad> listaPropuesta = new List<Entidad>();

            return listaPropuesta;
        }
        
        #endregion


        #region IDAOPropuesta

        /// <summary>
        /// Metodo para eliminar una Propuesta de la base de datos.
        /// </summary>
        /// <param name="parametro">objeto de tipo Contacto a eliminar en bd</param>
        /// <returns>true si fue eliminado</returns>
        public Boolean BorrarPropuesta(string nombrePropuesta)
        {
            return true;
        }


        /// <summary>
        /// Metodo diseñado para M7, que devuelve la lista de propuestas con estatus aprobado y que no están en proyecto
        /// </summary>
        /// <returns>Retorna la lista de propuestas con estatus= Aprobado y que no se encuentran aún en Proyecto</returns>
        public List<Entidad> PropuestaProyecto()
        {
            List<Entidad> listaPropuesta = new List<Entidad>();

            return listaPropuesta;
        }
        #endregion

    }
}