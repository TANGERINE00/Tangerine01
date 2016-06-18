using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M4;
using DominioTangerine.Entidades.M4;
using DominioTangerine;



namespace DatosTangerine.DAO.M4
{
    public class DaoCompania : DAOGeneral, IDaoCompania
    {


        /// <summary>
        /// Método para consultar el último id de compañía en la base de datos.
        /// </summary>
        /// <returns>Último id de compania registrada.</returns>
        
       public int ConsultLastCompanyId()
       {
           // AQUI VA EL LOGGER!
           int mayorId = 0;
           try
           {
               List<Parametro> parameters = new List<Parametro>();

               //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
               DataTable dt = EjecutarStoredProcedureTuplas(ResourceCompanyM4.ConsultLastCompanyId, parameters);
               //Guardar los datos 
               DataRow row = dt.Rows[0];

               mayorId = int.Parse(row[ResourceCompanyM4.ComIdCompany].ToString());
              
           }
           catch (Exception ex)
           {
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
           }

           return mayorId;
       }


       /// <summary>
       /// Método para eliminar una compañía en la base de datos.
       /// </summary>
       /// <param name="theCompany">Objeto de tipo CompaniaM4 para borrar en la base de datos.</param>
       /// <returns>True si fue borrada exitosamente.</returns>

       public bool DeleteCompany(Entidad theCompany)
       {
           // AQUI VA EL LOGGER!
           Parametro theParam = new Parametro();
           try
           {
               List<Parametro> parameters = new List<Parametro>();

               //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
               //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
               theParam = new Parametro(ResourceCompanyM4.ParamId, SqlDbType.Int,
                     ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).Id.ToString(), false);
               parameters.Add(theParam);


               //Se manda a ejecutar en BDConexion el stored procedure M4_AgregarCompania y todos los parametros que recibe
               List<Resultado> results = EjecutarStoredProcedure(ResourceCompanyM4.DeleteCompany, parameters);

           }
           catch (Exception ex)
           {
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
           }

           return true;
       }


       /// <summary>
       /// Método para habilitar una compañía en la base de datos.
       /// </summary>
       /// <param name="theCompany">Objeto de tipo CompaniaM4 para habilitar en la base de datos.</param>
       /// <returns>True si fue habilitada exitosamente.</returns>

       public bool EnableCompany(Entidad theCompany)
       {
           // AQUI VA EL LOGGER!
           Parametro theParam = new Parametro();
           try
           {
               List<Parametro> parameters = new List<Parametro>();

               //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
               //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
               theParam = new Parametro(ResourceCompanyM4.ParamId, SqlDbType.Int, theCompany.Id.ToString(), false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamStatus, SqlDbType.Int, "1", false);
               parameters.Add(theParam);

               //Se manda a ejecutar en BDConexion el stored procedure M4_InhabilitarHabilitar y todos los parametros que recibe
               List<Resultado> results = EjecutarStoredProcedure(ResourceCompanyM4.DisableAbleComany, parameters);

           }
           catch (Exception ex)
           {
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
           }

           return true;
       }


       /// <summary>
       /// Método para inhabilitar una compañía en la base de datos.
       /// </summary>
       /// <param name="theCompany">Objeto de tipo CompaniaM4 para deshabilitar en la base de datos.</param>
       /// <returns>True si fue deshabilitada exitosamente.</returns>

       public bool DisableCompany(Entidad theCompany)
       {
           // AQUI VA EL LOGGER!
           Parametro theParam = new Parametro();
           try
           {
               List<Parametro> parameters = new List<Parametro>();

               //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
               //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
               theParam = new Parametro(ResourceCompanyM4.ParamId, SqlDbType.Int, theCompany.Id.ToString(), false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamStatus, SqlDbType.Int, "0", false);
               parameters.Add(theParam);

               //Se manda a ejecutar en BDConexion el stored procedure M4_InhabilitarHabilitar y todos los parametros que recibe
               List<Resultado> results = EjecutarStoredProcedure(ResourceCompanyM4.DisableAbleComany, parameters);

           }
           catch (Exception ex)
           {
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
           }

           return true;
       }

       /// <summary>
       /// Método para agregar una compañia nueva en la base de datos.
       /// </summary>
       /// <param name="theCompany">Objeto de tipo CompaniaM4 para agregar en la base de datos.</param>
       /// <returns>True si fue agregada exitosamente.</returns>

       public bool Agregar(Entidad theCompany)
       {
           // AQUI VA EL LOGGER!
           Parametro theParam = new Parametro();
           try
           {
               List<Parametro> parameters = new List<Parametro>();

               //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
               //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
               theParam = new Parametro(ResourceCompanyM4.ParamNombre, SqlDbType.VarChar,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).NombreCompania, false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamRif, SqlDbType.VarChar,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).RifCompania, false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamEmail, SqlDbType.VarChar,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).EmailCompania, false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamTelefono, SqlDbType.VarChar,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).TelefonoCompania, false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamAcronimo, SqlDbType.VarChar,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).AcronimoCompania, false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamFechaRegistro, SqlDbType.Date,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).FechaRegistroCompania.ToString(), false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamStatus, SqlDbType.Int,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).StatusCompania.ToString(), false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamPresupuesto, SqlDbType.Int,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).PresupuestoCompania.ToString(), false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamPlazoPago, SqlDbType.Int,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).PlazoPagoCompania.ToString(), false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamIdLugar, SqlDbType.Int,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).IdLugar.ToString(), false);
               parameters.Add(theParam);

               //Se manda a ejecutar en BDConexion el stored procedure M4_AgregarCompania y todos los parametros que recibe
               List<Resultado> results = EjecutarStoredProcedure(ResourceCompanyM4.AddNewCompany, parameters);

           }
           catch (Exception ex)
           {
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
           }

           return true;
       }


       /// <summary>
       /// Método para modificar una compañía en la base de datos.
       /// </summary>
       /// <param name="theCompany">Objeto de tipo CompaniaM4 para modificar en la base de datos.</param>
       /// <returns>True si fue modificada exitosamente.</returns>

       public bool Modificar(Entidad theCompany)
       {
           // AQUI VA EL LOGGER!
           Parametro theParam = new Parametro();
           try
           {
               List<Parametro> parameters = new List<Parametro>();

               //Las dos lineas siguientes tienen que repetirlas tantas veces como parametros reciba su stored procedure a llamar
               //Parametro recibe (nombre del primer parametro en su stored procedure, el tipo de dato, el valor, false)
               theParam = new Parametro(ResourceCompanyM4.ParamId, SqlDbType.Int,
                     ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).Id.ToString(), false);
               parameters.Add(theParam);
               
               theParam = new Parametro(ResourceCompanyM4.ParamNombre, SqlDbType.VarChar,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).NombreCompania, false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamRif, SqlDbType.VarChar,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).RifCompania, false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamEmail, SqlDbType.VarChar,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).EmailCompania, false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamTelefono, SqlDbType.VarChar,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).TelefonoCompania, false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamAcronimo, SqlDbType.VarChar,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).AcronimoCompania, false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamFechaRegistro, SqlDbType.Date,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).FechaRegistroCompania.ToString(), false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamStatus, SqlDbType.Int,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).StatusCompania.ToString(), false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamPresupuesto, SqlDbType.Int,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).PresupuestoCompania.ToString(), false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamPlazoPago, SqlDbType.Int,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).PlazoPagoCompania.ToString(), false);
               parameters.Add(theParam);

               theParam = new Parametro(ResourceCompanyM4.ParamIdLugar, SqlDbType.Int,
                   ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).IdLugar.ToString(), false);
               parameters.Add(theParam);

               //Se manda a ejecutar en BDConexion el stored procedure M4_AgregarCompania y todos los parametros que recibe
               List<Resultado> results = EjecutarStoredProcedure(ResourceCompanyM4.ChangeCompany, parameters);

           }
           catch (Exception ex)
           {
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
           }

           return true;
       }

       /// <summary>
       /// Método para consultar una compañía en específico.
       /// </summary>
       /// <param name="idCompany">Entero que es igual al id de la compañía a consultar.</param>
       /// <returns>Objeto CompaniaM4 correspondiente a la empresa consultada.</returns>


       public Entidad ConsultarXId(Entidad theCompany)
       {
           // AQUI VA EL LOGGER!
           Entidad compania;
           try
           {
               List<Parametro> parameters = new List<Parametro>();

               Parametro theParam = new Parametro(ResourceCompanyM4.ParamId, SqlDbType.Int, ((DominioTangerine.Entidades.M4.CompaniaM4)theCompany).Id.ToString(), false);
               parameters.Add(theParam);

               //Guardo la tabla que me regresa el procedimiento de consultar Proyecto
               DataTable dt = EjecutarStoredProcedureTuplas(ResourceCompanyM4.ConsultCompany, parameters);
               //Guardar los datos 
               DataRow row = dt.Rows[0];

               int comId = int.Parse(row[ResourceCompanyM4.ComIdCompany].ToString());
               String comName = row[ResourceCompanyM4.ComNameCompany].ToString();
               String comRif = row[ResourceCompanyM4.ComRifCompany].ToString();
               String comEmail = row[ResourceCompanyM4.ComEmailCompany].ToString();
               String comTelephone = row[ResourceCompanyM4.ComTelephoneCompany].ToString();
               String comAcronym = row[ResourceCompanyM4.ComAcronymCompany].ToString();
               DateTime comRegisterDate = DateTime.Parse(row[ResourceCompanyM4.ComRegisterDateCompany].ToString());
               int comStatus = int.Parse(row[ResourceCompanyM4.ComStatusCompany].ToString());
               int comBudget = int.Parse(row[ResourceCompanyM4.ComBudgetCompany].ToString());
               int comDeadline = int.Parse(row[ResourceCompanyM4.ComDeadlineCompany].ToString());
               int comIdPlace = int.Parse(row[ResourceCompanyM4.ComIdPlace].ToString());

               //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
               compania = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(comId, comName, comRif, comEmail, comTelephone, comAcronym,
                                                   comRegisterDate, comStatus, comBudget, comDeadline, comIdPlace);
           }
           catch (Exception ex)
           {
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
           }

           return compania;
       }


       /// <summary>
       /// Método para consultar todas las compañías registradas en la base de datos.
       /// </summary>
       /// <returns>Lista de compañías registradas.</returns>

       public List<Entidad> ConsultarTodos()
       {
           List<Parametro> parameters = new List<Parametro>();
           List<Entidad> listCompany = new List<Entidad>();

           try
           {
               //Guardo la tabla que me regresa el procedimiento de consultar contactos
               DataTable dt = EjecutarStoredProcedureTuplas(ResourceCompanyM4.ConsultCompanies, parameters);

               //Guardar los datos 
               foreach (DataRow row in dt.Rows)
               {
                   int comId = int.Parse(row[ResourceCompanyM4.ComIdCompany].ToString());
                   String comName = row[ResourceCompanyM4.ComNameCompany].ToString();
                   String comRif = row[ResourceCompanyM4.ComRifCompany].ToString();
                   String comEmail = row[ResourceCompanyM4.ComEmailCompany].ToString();
                   String comTelephone = row[ResourceCompanyM4.ComTelephoneCompany].ToString();
                   String comAcronym = row[ResourceCompanyM4.ComAcronymCompany].ToString();
                   DateTime comRegisterDate = DateTime.Parse(row[ResourceCompanyM4.ComRegisterDateCompany].ToString());
                   int comStatus = int.Parse(row[ResourceCompanyM4.ComStatusCompany].ToString());
                   int comBudget = int.Parse(row[ResourceCompanyM4.ComBudgetCompany].ToString());
                   int comDeadline = int.Parse(row[ResourceCompanyM4.ComDeadlineCompany].ToString());
                   int comIdPlace = int.Parse(row[ResourceCompanyM4.ComIdPlace].ToString());

                   //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                   Entidad compania = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(comId, comName, comRif, comEmail, comTelephone, comAcronym,
                                                                                comRegisterDate, comStatus, comBudget, comDeadline, comIdPlace);
                   
                   listCompany.Add(compania);

               }


           }
           catch (Exception ex)
           {
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
           }

           return listCompany;
       }



        /// <summary>
        /// Metodo que busca en la base de datos todas aquellas que tienen como estatus Activo
        /// </summary>
        /// <returns></returns>
       public List<Entidad> ConsultarCompaniasActivas()
       {
           List<Parametro> parameters = new List<Parametro>();
           List<Entidad> listCompany = new List<Entidad>();

           try
           {
               //Guardo la tabla que me regresa el procedimiento de consultar contactos
               DataTable dt = EjecutarStoredProcedureTuplas(ResourceCompanyM4.ConsultEnableCompanies, parameters);

               //Guardar los datos 
               foreach (DataRow row in dt.Rows)
               {
                   int comId = int.Parse(row[ResourceCompanyM4.ComIdCompany].ToString());
                   String comName = row[ResourceCompanyM4.ComNameCompany].ToString();
                   String comRif = row[ResourceCompanyM4.ComRifCompany].ToString();
                   String comEmail = row[ResourceCompanyM4.ComEmailCompany].ToString();
                   String comTelephone = row[ResourceCompanyM4.ComTelephoneCompany].ToString();
                   String comAcronym = row[ResourceCompanyM4.ComAcronymCompany].ToString();
                   DateTime comRegisterDate = DateTime.Parse(row[ResourceCompanyM4.ComRegisterDateCompany].ToString());
                   int comStatus = int.Parse(row[ResourceCompanyM4.ComStatusCompany].ToString());
                   int comBudget = int.Parse(row[ResourceCompanyM4.ComBudgetCompany].ToString());
                   int comDeadline = int.Parse(row[ResourceCompanyM4.ComDeadlineCompany].ToString());
                   int comIdPlace = int.Parse(row[ResourceCompanyM4.ComIdPlace].ToString());

                   //Creo un objeto de tipo Compania con los datos de la fila y lo guardo.
                   Entidad compania = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(comId, comName, comRif, comEmail, comTelephone, comAcronym,
                                                                                comRegisterDate, comStatus, comBudget, comDeadline, comIdPlace);

                   listCompany.Add(compania);

               }


           }
           catch (Exception ex)
           {
               throw new ExcepcionesTangerine.ExceptionsTangerine(RecursoGeneralBD.Mensaje_Generico_Error, ex);
           }

           return listCompany;
       }
    }
}
