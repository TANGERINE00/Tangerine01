using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine.Fabrica;
using ExcepcionesTangerine;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M2;

namespace LogicaTangerine.Comandos.M2.ComandosEspecificos
{
    public class ComandoVerificarAccesoAOpciones : Comando<List<String>>
    {
        public String _nombreRol;

        /// <summary>
        /// Constructor que recibe un parametro del tipo string
        /// </summary>
        /// <param name="nombreRol">Nombre del rol</param>
        public ComandoVerificarAccesoAOpciones( String nombreRol )
        {
            _nombreRol = nombreRol;
        }

        /// <summary>
        /// Método para verificar el acceso a las distintas opciones
        /// </summary>
        /// <returns>Retorna una lista</returns>
        public override List<String> Ejecutar()
        {
            List<String> lista = new List<String>();

            try
            {
                Comando<DominioTangerine.Entidad> theComando = FabricaComandos.obtenerComandoObtenerRolUsuarioPorNombre( _nombreRol );
                LogicaTangerine.Comandos.M2.ComandosDAORol.ComandoObtenerRolUsuarioPorNombre comando
                    = ( LogicaTangerine.Comandos.M2.ComandosDAORol.ComandoObtenerRolUsuarioPorNombre )theComando;
                DominioTangerine.Entidad theRol = comando.Ejecutar();
                DominioTangerine.Entidades.M2.RolM2 rol = ( DominioTangerine.Entidades.M2.RolM2 )theRol;

                foreach ( DominioTangerine.Entidades.M2.MenuM2 m in rol.menu )
                {
                    foreach ( DominioTangerine.Entidades.M2.OpcionM2 o in m.opciones )
                    {
                        lista.Add( o.nombre );
                    }
                }
            }
            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                throw new ExceptionM2Tangerine( "DS-202" , "Metodo no implementado" , ex );
            }
            return lista;
        }
    }
}
