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

namespace LogicaTangerine.Comandos.M4

{
    class ComandoConsultarLugarXNombreID : Comando <List<Entidad>>
    {
        

         public override List<Entidad> Ejecutar()
         {
             try
             {
                 IDaoLugarDireccion DaoLugar = FabricaDAOSqlServer.crearDaoLugarDireccion();
                 return DaoLugar.ConsultCityPlaces();
             }
             catch (NotImplementedException e)
             {
                 return null ;
                 throw new ExceptionM4Tangerine("DS-404", "Metodo no implementado", e);
             }
         }
    }
}
