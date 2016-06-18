using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M2;
using ExcepcionesTangerine;

namespace LogicaTangerine.Comandos.M2.ComandosDAORol
{
    public class ComandoObtenerOpciones : Comando<DominioTangerine.Entidad>
    {
        public string _nombreMenu;
        public int _codigoRol;

        /// <summary>
        /// Constructor que recibe dos parametros, uno del tipo string y otro int
        /// </summary>
        /// <param name="nombreMenu"></param>
        /// <param name="codigoRol"></param>
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
            DominioTangerine.Entidad opciones;
            IDAORol OpcionesUsuario = FabricaDAOSqlServer.crearDaoRol();
            opciones = OpcionesUsuario.ObtenerOpciones( _nombreMenu , _codigoRol );
            return opciones;
        }
    }
}
