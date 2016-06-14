using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M1;
using DatosTangerine;
using DominioTangerine;
using DominioTangerine.Fabrica;
using DominioTangerine.Entidades.M1;

namespace DatosTangerine.DAO.M1
{
    public class DAOLogin: DAOGeneral,IDaoLogin
    {
        FabricaEntidades laFabrica = new FabricaEntidades();
        #region IDAO
        public Boolean Agregar(Entidad e)
        {
            throw new NotImplementedException();
        }
        public Boolean Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }
        public Entidad ConsultarXId(Entidad e)
        {
            throw new NotImplementedException();
        }
        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
        #endregion

        public Entidad ObtenerElUsuario(string nombre_usuario)
        {
            Cuenta laCuenta = (Cuenta)laFabrica.ObtenerCuenta();
            return laCuenta;

        }

        public String ValidarUsuarioCorreo(string correo_usuario)
        {
            String correo = "";
            return correo;

        }

    }
}
