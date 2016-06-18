using DatosTangerine.InterfazDAO.M7;
using DatosTangerine.M7;
using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.DAO.M7
{
    public class DaoProyecto : DAOGeneral, IDaoProyecto
    {
        #region IDAO Proyecto
        public bool DeleteProyecto(Entidad proyecto)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ContactProyectoxAcuerdoPago()
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ContactProyectoPorEmpleado(Entidad empleado)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ContactProyectoPorGerente(Entidad empleado)
        {
            throw new NotImplementedException();
        }

        public Entidad ContactNombrePropuestaId(Entidad parametro)
        {

            Entidad propuesta = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPropuesta();
            try
            {
                List<Parametro> parameters = new List<Parametro>();

                Parametro theParam = new Parametro(ResourceProyecto.ParamIdPropuestaPrpu, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceProyecto.ContactNombrePropuestaID, parameters);

                //Guardar los datos 
                DataRow row = dt.Rows[0];
                ((DominioTangerine.Entidades.M7.Propuesta)propuesta).Nombre = row[ResourceProyecto.PrpuNombre].ToString();

            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return propuesta;
        }

        public int ContactMaxIdProyecto()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IDAO
        public bool Agregar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Entidad parametro)
        {
            throw new NotImplementedException();
        }

        public Entidad ConsultarXId(Entidad parametro)
        {
            // AQUI VA EL LOGGER!
            Entidad proyecto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
            try
            {
                List<Parametro> parameters = new List<Parametro>(); 

                Parametro theParam = new Parametro(ResourceProyecto.ParamId_Proyecto, SqlDbType.Int, ((DominioTangerine.Entidades.M7.Proyecto)parametro).Id.ToString(), false);
                parameters.Add(theParam);

                //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceProyecto.ContactProyecto, parameters);
                //Guardar los datos 
                DataRow row = dt.Rows[0];
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Id = int.Parse(row[ResourceProyecto.ProyIdProyecto].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Nombre = row[ResourceProyecto.ProyNombre].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Codigo = row[ResourceProyecto.ProyCodigo].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechainicio = DateTime.Parse(row[ResourceProyecto.ProyFechaInicio].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechaestimadafin = DateTime.Parse(row[ResourceProyecto.ProyFechaEstFin].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Costo = double.Parse(row[ResourceProyecto.ProyCosto].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Descripcion = row[ResourceProyecto.ProyDescripcion].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Realizacion = row[ResourceProyecto.ProyRealizacion].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus = row[ResourceProyecto.ProyEstatus].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Razon = row[ResourceProyecto.ProyRazon].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Acuerdopago = row[ResourceProyecto.ProyAcuerdoPago].ToString();
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idpropuesta = int.Parse(row[ResourceProyecto.ProyIdPropuesta].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idresponsable = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());
                ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idgerente = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());
            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return proyecto;
        }

        public List<Entidad> ConsultarTodos()
        {
           List<Parametro> parameters = new List<Parametro>();
           List<Entidad> listProyecto = new List<Entidad>();

            try
            {
                //Guardo la tabla que me regresa el procedimiento de consultar contactos
                DataTable dt = EjecutarStoredProcedureTuplas(ResourceProyecto.ContactProyectos, parameters);

                //Guardar los datos 
                foreach (DataRow row in dt.Rows)
                {
                    Entidad proyecto = DominioTangerine.Fabrica.FabricaEntidades.ObtenerProyecto();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Id = int.Parse(row[ResourceProyecto.ProyIdProyecto].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Nombre = row[ResourceProyecto.ProyNombre].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Codigo = row[ResourceProyecto.ProyCodigo].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechainicio = DateTime.Parse(row[ResourceProyecto.ProyFechaInicio].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Fechaestimadafin = DateTime.Parse(row[ResourceProyecto.ProyFechaEstFin].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Costo = double.Parse(row[ResourceProyecto.ProyCosto].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Descripcion = row[ResourceProyecto.ProyDescripcion].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Realizacion = row[ResourceProyecto.ProyRealizacion].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Estatus = row[ResourceProyecto.ProyEstatus].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Razon = row[ResourceProyecto.ProyRazon].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Acuerdopago = row[ResourceProyecto.ProyAcuerdoPago].ToString();
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idpropuesta = int.Parse(row[ResourceProyecto.ProyIdPropuesta].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idresponsable = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());
                    ((DominioTangerine.Entidades.M7.Proyecto)proyecto).Idgerente = int.Parse(row[ResourceProyecto.ProyIdCompania].ToString());

                    listProyecto.Add(proyecto);

                }


            }
            catch (Exception ex)
            {
                throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
            }

            return listProyecto;
        }
        #endregion
    }
}
