using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DominioTangerine;
using LogicaTangerine;
using LogicaTangerine.M8;

namespace Tangerine.GUI.M8
{
    public partial class ModificarFacturaM8 : System.Web.UI.Page
    {

        int _numeroFactura = 0;
        DateTime _fechaEmision = DateTime.Now;
        int _montoTotal = 0;
        int _montoRestante = 0;
        string _descripcion = String.Empty;
        int _proyectoId = 0;
        int _companiaId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttomModificarFactura_Click ( object sender , EventArgs e )
        {
            _numeroFactura = int.Parse(textNumeroFactura_M8.Value);
            _fechaEmision = DateTime.Parse(textFecha_M8.Value);
            _companiaId = int.Parse(textCliente_M8.Value);
            _proyectoId = int.Parse(textProyecto_M8.Value);
            _descripcion = textDescripcion_M8.Value;
            _montoTotal = int.Parse(textMonto_M8.Value);
            _montoRestante = int.Parse(textMonto_M8.Value);

            Facturacion factura = new Facturacion( _numeroFactura , _fechaEmision , _montoTotal , _montoRestante , _descripcion , _proyectoId
                , _companiaId);
            LogicaM8 facturaLogic = new LogicaM8();
            facturaLogic.ChangeExistingFactura(factura);

        }
 
    }

}