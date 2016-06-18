using DominioTangerine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M5
{
    public interface IContratoConsultarContactos
    {

        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
        string contact { get; set; }
        string botonVolver { get; set; }
        string button { get; set; }
        string nombreEmpresa { get; set; }
        int GetTypeComp { get; }
        int GetIdComp { get; }
        string botonVolverCompania();
        string botonVolverLead();
        string empresaGen();
        string leadGen();
        int idCont();
        int statusAccion();
        int statusAgregado();
        string ContactoAgregadoMsj();
        string ContadoModificadoMsj();
        string ContactoEliminadoMsj();
        string CargarBotonNuevoContacto(int typeComp, int idComp);
        void Alerta(string msj, int typeMsg);
         void LlenarTabla(Contacto _theContact2, int typeComp, int idComp);
        string StatusModificado();
    }
}
