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
                RolM2 rol = new RolM2( _rolUsuario );
                UsuarioM2 usuario = new UsuarioM2( _usuarioNombre , _contrasenaUsuario , DateTime.Now , 
                                                   "Activo" , rol , _fichaEmpleado);
                usuario.contrasena = usuario.GetMD5( usuario.contrasena );
                LogicaTangerine.Comando<Boolean> commandAgregarUsuario = FabricaComandos.agregarUsuario( usuario );
                resultado = commandAgregarUsuario.Ejecutar();
            }

            catch (Exception ex)
            {
                Logger.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ExcepcionesTangerine.M2.ExcepcionRegistro("Error al ejecutar " +
                                                                     "ComandoPrepararUsuario()", ex);
            }
            return resultado;
        }


    }
}
