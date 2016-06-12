using System;
using System.Collections.Generic;
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
           throw new NotImplementedException();
       }


       /// <summary>
       /// Método para eliminar una compañía en la base de datos.
       /// </summary>
       /// <param name="theCompany">Objeto de tipo CompaniaM4 para borrar en la base de datos.</param>
       /// <returns>True si fue borrada exitosamente.</returns>

       public bool DeleteCompany(Entidad theCompany)
       {
           throw new NotImplementedException();
       }


       /// <summary>
       /// Método para habilitar una compañía en la base de datos.
       /// </summary>
       /// <param name="theCompany">Objeto de tipo CompaniaM4 para habilitar en la base de datos.</param>
       /// <returns>True si fue habilitada exitosamente.</returns>

       public bool EnableCompany(Entidad theCompany)
       {
           throw new NotImplementedException();
       }


       /// <summary>
       /// Método para inhabilitar una compañía en la base de datos.
       /// </summary>
       /// <param name="theCompany">Objeto de tipo CompaniaM4 para deshabilitar en la base de datos.</param>
       /// <returns>True si fue deshabilitada exitosamente.</returns>

       public bool DisableCompany(Entidad theCompany)
       {
           throw new NotImplementedException();
       }

       /// <summary>
       /// Método para agregar una compañia nueva en la base de datos.
       /// </summary>
       /// <param name="parameto">Objeto de tipo CompaniaM4 para agregar en la base de datos.</param>
       /// <returns>True si fue agregada exitosamente.</returns>

       public bool Agregar(Entidad parametro)
       {
           throw new NotImplementedException();
       }


       /// <summary>
       /// Método para modificar una compañía en la base de datos.
       /// </summary>
       /// <param name="theCompany">Objeto de tipo CompaniaM4 para modificar en la base de datos.</param>
       /// <returns>True si fue modificada exitosamente.</returns>

       public bool Modificar(Entidad parametro)
       {
           throw new NotImplementedException();
       }

       /// <summary>
       /// Método para consultar una compañía en específico.
       /// </summary>
       /// <param name="idCompany">Entero que es igual al id de la compañía a consultar.</param>
       /// <returns>Objeto CompaniaM4 correspondiente a la empresa consultada.</returns>

       
       public Entidad ConsultarXId(Entidad parametro)
       {
           throw new NotImplementedException();
       }


       /// <summary>
       /// Método para consultar todas las compañías registradas en la base de datos.
       /// </summary>
       /// <returns>Lista de compañías registradas.</returns>

       public List<Entidad> ConsultarTodos()
       {
           throw new NotImplementedException();
       }

      
    }
}
