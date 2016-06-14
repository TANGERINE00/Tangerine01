using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosTangerine.InterfazDAO.M9;
using DominioTangerine.Entidades.M9;
using DominioTangerine;
using System.Data;

namespace DatosTangerine.DAO.M9
{
    public class DAOPago : DAOGeneral , IDAOPago
    {
    
        public bool Agregar (Entidad pagoParam)
        {
            DominioTangerine.Entidades.M9.Pago pago = (DominioTangerine.Entidades.M9.Pago)pagoParam;
            List<Parametro> parametros = new List<Parametro>();

            Parametro parametro = new Parametro(RecursoDAOPago.ParamCod,SqlDbType.Int, pago.codPago.ToString(),false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursoDAOPago.ParamMonto, SqlDbType.Int, pago.montoPago.ToString(), false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursoDAOPago.ParamMoneda, SqlDbType.Int, pago.monedaPago, false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursoDAOPago.ParamForma, SqlDbType.Int, pago.formaPago, false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursoDAOPago.ParamIdFactura, SqlDbType.Int, pago.idFactura.ToString(), false);
            parametros.Add(parametro);

            List<Resultado> resultados = EjecutarStoredProcedure(RecursoDAOPago.AgregarPago, parametros);
            
            if (resultados!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        public bool CargarStatus (int factura, int status)
        {
            return true;
        }
    
        public Boolean Modificar (Entidad e)
        {
          throw new NotImplementedException();
        }

        public Entidad ConsultarXId(Entidad id)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }
    
    
    
    }


}
