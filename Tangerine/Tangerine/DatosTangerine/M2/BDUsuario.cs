using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosTangerine.M2
{
    class BDUsuario
    {
        BDConexion laConexion;
        List<Parametro> parametros;
        Parametro elParametro;

        public bool agregarUsuario(Usuario usuario)
        {
            parametros = new List<Parametro>();
            laConexion = new BDConexion();

            try
            {
                elParametro = new Parametro("", SqlDbType.VarChar, usuario.Usuario, false);
                parametros.Add(elParametro);

                elParametro = new Parametro("", SqlDbType.VarChar, usuario.Contrasenia, false);
                parametros.Add(elParametro);

                elParametro = new Parametro("", SqlDbType.Int, usuario.FichaEmpleado.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro("", SqlDbType.Date, usuario.FechaCreacion.ToString(), false);
                parametros.Add(elParametro);

                elParametro = new Parametro("", SqlDbType.VarChar, usuario.Rol.GetNombre(), false);
                parametros.Add(elParametro);

                List<Resultado> results = laConexion.EjecutarStoredProcedure("", parametros);
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

            return true;
        }
    }
}
