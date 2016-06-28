using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M2;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M2;

namespace LogicaTangerine.Comandos.M2.ComandosDAORol
{
    public class ComandoObtenerOpciones : Comando<DominioTangerine.Entidad>
    {
        public string _nombreMenu;
        public int _codigoRol;

        /// <summary>
        /// Constructor que recibe dos parametros, uno del tipo string y otro int
        /// </summary>
        /// <param name="nombreMenu">Nombre del usuario</param>
        /// <param name="codigoRol">Codigo del rol</param>
        public ComandoObtenerOpciones( string nombreMenu , int codigoRol )
        {
            _nombreMenu = nombreMenu;
            _codigoRol = codigoRol;
        }

        /// <summary>
        /// Método para crear la instancia de la clase DaoRol y usar el método ObtenerOpciones
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoRol</returns>
        public override DominioTangerine.Entidad Ejecutar()
        {
            try
            {
                DominioTangerine.Entidad opciones;
                IDAORol OpcionesUsuario = FabricaDAOSqlServer.crearDaoRol();
                opciones = OpcionesUsuario.ObtenerOpciones( _nombreMenu , _codigoRol );
                return opciones;
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                throw new ExceptionM2Tangerine( "DS-202" , "Metodo no implementado" , ex );
            }
        }
    }
}
