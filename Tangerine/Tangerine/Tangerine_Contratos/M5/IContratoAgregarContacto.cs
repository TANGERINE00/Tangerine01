using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangerine_Contratos.M5
{
    public interface IContratoAgregarContacto
    {
        string botonVolver { get; set; }
        string input_nombre { get; set; }
        string input_apellido { get; set; }
        string input_correo { get; set; }
        string item_cargo { get; set; }
        string input_departamento { get; set; }
        string input_telefono { get; set; }
        string alertaClase { set; }
        string alertaRol { set; }
        string alerta { set; }
        int GetTypeComp();
        int GetIdComp();
        void btnaceptar_Click( object sender, EventArgs e );
        string CargarBotonVolver( int typeComp, int idComp );
        void BotonAceptar( int typeComp, int idComp );
    }
}