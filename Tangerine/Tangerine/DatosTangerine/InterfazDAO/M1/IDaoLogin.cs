using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatosTangerine.InterfazDAO.M1
{
    public interface IDaoLogin : IDao
    {
        Entidad ObtenerElUsuario(string nombre_usuario);

        String ValidarUsuarioCorreo(string correo_usuario);
    }
}
