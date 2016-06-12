using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.Fabrica;
using DatosTangerine.DAO;
using DominioTangerine.Entidades.M4;
using DominioTangerine.Fabrica;


namespace LogicaTangerine.Comandos.M4
{
    class ComandoAgregarCompania : Comando<Boolean>
    {
        public ComandoAgregarCompania(CompaniaM4 Compania)  : base (Compania) {}

       /// <summary>
       /// Comando que permite insertar una compania a la base de dato
       /// </summary>
       /// <returns>booleano true or false</returns>
        public override Boolean Ejecutar()
        {
            DAOGeneral Compania = FabricaDAOSqlServer.crearDaoCompania();
            return true; //Compania.Agregar(_laEntidad);
        }
    }

}