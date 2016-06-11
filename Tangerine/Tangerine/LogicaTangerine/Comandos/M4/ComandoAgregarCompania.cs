using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.Fabrica;
using DatosTangerine.DAO;
using DominioTangerine.Entidades.M4;


namespace LogicaTangerine.Comandos.M4
{
    class ComandoAgregarCompania : Comando<Boolean>
    {
        public override Boolean Ejecutar()
        {
            DAOGeneral Compania = FabricaDAOSqlServer.crearDaoCompania();
            return true; //Compania.Agregar(_laEntidad);
        }
    }

}