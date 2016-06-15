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
            //Entidad pago = DominioTangerine.Fabrica.FabricaEntidades.ObtenerPago_M9();
            
            DominioTangerine.Entidades.M9.Pago pago = (DominioTangerine.Entidades.M9.Pago)pagoParam;
            List<Parametro> parametros = new List<Parametro>();

            Parametro parametro = new Parametro(RecursoDAOPago.ParamCod,SqlDbType.Int, pago.codPago.ToString(),false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursoDAOPago.ParamMonto, SqlDbType.Int, pago.montoPago.ToString(), false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursoDAOPago.ParamMoneda, SqlDbType.VarChar, pago.monedaPago, false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursoDAOPago.ParamForma, SqlDbType.VarChar, pago.formaPago, false);
            parametros.Add(parametro);

            parametro = new Parametro(RecursoDAOPago.ParamIdFactura, SqlDbType.Int, pago.idFactura.ToString(), false);
            parametros.Add(parametro);

            List<Resultado> resultados = EjecutarStoredProcedure(RecursoDAOPago.AgregarPago, parametros);
            
            if (resultados!=null)
            {
                CargarStatus(pago.idFactura, 1);
                return true;
            }
            else
            {
                return false;
            }
        }
    
        public bool CargarStatus (int factura, int status)
        {
            List<Parametro> parametros = new List<Parametro>();

            Parametro parametro = new Parametro(RecursoDAOPago.ParamIdFactura, SqlDbType.Int, factura.ToString(),false);
            parametros.Add(parametro);
            parametro = new Parametro(RecursoDAOPago.ParamStatus, SqlDbType.Int, status.ToString(),false);
            parametros.Add(parametro);

            List<Resultado> resultados =  EjecutarStoredProcedure(RecursoDAOPago.CambiarStatus, parametros);
            if (resultados!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
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
