using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.DAO;
using DatosTangerine.Fabrica;
using DatosTangerine.InterfazDAO.M2;
using DominioTangerine.Entidades.M2;
using ExcepcionesTangerine;
using ExcepcionesTangerine.M2;
using LogicaTangerine.Fabrica;

namespace LogicaTangerine.Comandos.M2.ComandosDAOUsuario
{
    public class ComandoPrepararUsuario : Comando<Boolean>
    {
        String _usuarioNombre, _contrasenaUsuario, _rolUsuario;
        int _fichaEmpleado;

        /// <summary>
        /// Constructor que recibe tres parametros de tipo string y uno de tipo int
        /// </summary>
        /// <param name="usuarioNombre"></param>
        /// <param name="contrasenaUsuario"></param>
        /// <param name="rolUsuario"></param>
        /// <param name="fichaEmpleado"></param>
        public ComandoPrepararUsuario( String usuarioNombre , String contrasenaUsuario , String rolUsuario , int fichaEmpleado )
        {
            _usuarioNombre = usuarioNombre;
            _contrasenaUsuario = contrasenaUsuario;
            _rolUsuario = rolUsuario;
            _fichaEmpleado = fichaEmpleado;
        }

        /// <summary>
        /// Método para crear la instancia de la clase DaoUsuario y usar el método ComandoAgregarUsuario
        /// </summary>
        /// <returns>Retorna una instancia del tipo DaoUsuario</returns>
        public override bool Ejecutar()
        {
            bool resultado = true;
            try
            {
                DominioTangerine.Entidad theRol = DominioTangerine.Fabrica.FabricaEntidades.crearRolNombre( _rolUsuario );
                DominioTangerine.Entidades.M2.RolM2 rol = ( DominioTangerine.Entidades.M2.RolM2 )theRol;
                DominioTangerine.Entidad theUsuario = DominioTangerine.Fabrica.FabricaEntidades.crearUsuarioCompleto( _usuarioNombre , 
                                                      _contrasenaUsuario , DateTime.Now , "Activo" , rol , _fichaEmpleado );
                DominioTangerine.Entidades.M2.UsuarioM2 usuario = ( DominioTangerine.Entidades.M2.UsuarioM2 )theUsuario;
                usuario.contrasena = usuario.GetMD5( usuario.contrasena );
                LogicaTangerine.Comando<Boolean> commandAgregarUsuario = FabricaComandos.agregarUsuario( usuario );
                resultado = commandAgregarUsuario.Ejecutar();
            }

            catch ( Exception ex )
            {
                Logger.EscribirError( System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name , ex );
                throw new ExceptionM2Tangerine( "DS-202" , "Error en datos, posiblemente ficha no existente" , ex );
            }
            return resultado;
        }


    }
}
