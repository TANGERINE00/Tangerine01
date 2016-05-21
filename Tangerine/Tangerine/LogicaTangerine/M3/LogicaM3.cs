using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominioTangerine;
using DatosTangerine.M3;


namespace LogicaTangerine.M3
{
    public class LogicaM3
    {
        
        //----------------------------------  listar cliente potencial------------------------------------------------
        public List<ClientePotencial> LogicalistarClientePotencial()
        {
            BDClientePotencial datosClientePotencial = new BDClientePotencial();
            List<ClientePotencial> objetolistaClientePotencial = new List<ClientePotencial>();
            objetolistaClientePotencial = datosClientePotencial.DatosListarClientePotencial();
            return objetolistaClientePotencial;
        }
//----------------------------------------agregar cliente Potencial -------------------------------------------------

        

        public bool AgregarNuevoclientePotencial(ClientePotencial elClientePotencial)
        {
            try
            {
                return BDClientePotencial.AgregarClientePotencial(elClientePotencial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //------------------------------------consultar un cliente en especifico-------------
        public ClientePotencial BuscarClientePotencial(int idClientePotencial)
        {
            try
            {
                return BDClientePotencial.ConsultarClientePotencial(idClientePotencial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   //--------------------------------------------borrar cliente-------------------


        public bool BorrarNuevoclientePotencial(ClientePotencial elClientePotencial)
        {
            try
            {
                return BDClientePotencial.BorrarClientePotencial(elClientePotencial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public bool ModificarNuevoclientePotencial(ClientePotencial elClientePotencial)
        {
            try
            {
                return BDClientePotencial.ModificarClientePotencial(elClientePotencial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
