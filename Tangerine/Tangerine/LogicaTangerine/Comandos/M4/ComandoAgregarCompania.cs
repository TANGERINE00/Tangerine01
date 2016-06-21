using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.Fabrica;
using DatosTangerine.DAO;
using DatosTangerine.DAO.M4;
using DatosTangerine.InterfazDAO.M4;
using DominioTangerine.Entidades.M4;
using DominioTangerine.Fabrica;
using DominioTangerine;
using ExcepcionesTangerine.M4;



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
            try
            {
                IDaoCompania DaoComp = FabricaDAOSqlServer.crearDaoCompania();
                return DaoComp.Agregar(_laEntidad);
            }
            catch (NotImplementedException e)
            {
                throw new ExceptionM4Tangerine ("DS-404", "Metodo no implementado" , e );
            }
        }
    }

}