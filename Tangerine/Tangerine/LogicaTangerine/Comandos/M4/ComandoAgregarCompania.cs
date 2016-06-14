using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.Fabrica;
using DatosTangerine.DAO;
using DatosTangerine.DAO.M4;
using DominioTangerine.Entidades.M4;
using DominioTangerine.Fabrica;
using DominioTangerine;



namespace LogicaTangerine.Comandos.M4
{
    class ComandoAgregarCompania : Comando<Boolean>
    {
      

        public ComandoAgregarCompania(Entidad Company) {
             _laEntidad = Company;
        }

       /// <summary>
       /// Comando que permite insertar una compania a la base de dato
       /// </summary>
       /// <returns>booleano true or false</returns>
        public override Boolean Ejecutar()
        {

            DAOGeneral DaoComp = FabricaDAOSqlServer.crearDaoCompania();
            return true;//DaoComp.Agregar();
        }
    }

}