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
//----------------------------------------listar cliente Potencial -------------------------------------------------

        

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

   
    }




}
