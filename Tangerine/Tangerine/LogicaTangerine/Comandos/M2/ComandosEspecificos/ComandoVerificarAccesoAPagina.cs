using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaTangerine.Fabrica;
using ExcepcionesTangerine;

namespace LogicaTangerine.Comandos.M2.ComandosEspecificos
{
    public class ComandoVerificarAccesoAPagina : Comando<bool>
    {
        public string _paginaAVerificar, _nombreRol;

        /// <summary>
        /// Constructor que recibe dos parametros del tipo string
        /// </summary>
        /// <param name="paginaAVerificar"></param>
        /// <param name="nombreRol"></param>
        public ComandoVerificarAccesoAPagina( string paginaAVerificar , string nombreRol )
        {
            _paginaAVerificar = paginaAVerificar;
            _nombreRol = nombreRol;
        }

        public override bool Ejecutar()
        {
            bool resultado = false;

            string[] paginaSeparada = _paginaAVerificar.Split('/');
            int tamanoPagina = paginaSeparada.Length;

            try
            {
                Comando<DominioTangerine.Entidad> theComando = FabricaComandos.obtenerComandoObtenerRolUsuarioPorNombre( _nombreRol );
                LogicaTangerine.Comandos.M2.ComandosDAORol.ComandoObtenerRolUsuarioPorNombre comando = ( LogicaTangerine.Comandos.M2.ComandosDAORol.ComandoObtenerRolUsuarioPorNombre )theComando;
                DominioTangerine.Entidad theRol = comando.Ejecutar();
                DominioTangerine.Entidades.M2.RolM2 rol = ( DominioTangerine.Entidades.M2.RolM2 )theRol;

                foreach (DominioTangerine.Entidades.M2.MenuM2 m in rol.menu)
                {
                    foreach (DominioTangerine.Entidades.M2.OpcionM2 o in m.opciones)
                    {
                        string[] opcionSeparada = o.url.Split('/');
                        int tamanoOpcion = opcionSeparada.Length;

                        if (tamanoOpcion >= 2)
                        {
                            if (opcionSeparada[tamanoOpcion - 1].Equals(paginaSeparada[tamanoPagina - 1])
                                 && opcionSeparada[tamanoOpcion - 2].Equals(paginaSeparada[tamanoPagina - 2]))
                            {
                                resultado = true;
                                return resultado;
                            }
                        }
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M2.ExcepcionPrivilegios("Error al ejecutar " +
                                                                        "VerificarAccesoAPagina()" +
                                                                        " [Pagina Errónea]", ex);
            }
            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M2.ExcepcionPrivilegios("Error al ejecutar " +
                                                                        "VerificarAccesoAPagina()", ex);
            }
            return resultado;
        }
    }
}
