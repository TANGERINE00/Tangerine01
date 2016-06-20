using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M7;
using LogicaTangerine;
using DominioTangerine;
using System.Web;
using DominioTangerine.Entidades.M7;
using DominioTangerine.Fabrica;
using LogicaTangerine.Fabrica;

namespace Tangerine_Presentador.M7
{
    public class PresentadorAgregarProyecto
    {
       private IContratoAgregarProyecto _vista;

        DateTime _fechaIni;
        DateTime _fechaFin;
        Double _costo;

        public PresentadorAgregarProyecto(IContratoAgregarProyecto vista)
        {
            _vista = vista;
        }


        public void agregarProyecto()
        {

            _fechaIni = DateTime.ParseExact(_vista.FechaInicio, "MM/dd/yyyy", null);
            _fechaFin = DateTime.ParseExact(_vista.FechaFin, "MM/dd/yyyy", null);
            _costo = Convert.ToDouble(_vista.Costo);

            /*DominioTangerine.Entidades.M7.Proyecto p = new DominioTangerine.Entidades.M7.Proyecto(_vista.NombreProyecto,
                                                   _vista.CodigoProyecto,_fechaIni, _fechaFin, _costo, "Descripcion",
                                                     "0", "En desarrollo", "", "AcuerdoPago", "IDPropuesta", "IdResponsable", "idgerente");
            */
        }

        public void cargarPropuestas()
        {
            Comando<List<Entidad>> comandoLista = FabricaComandos.ComandoConsultarPropuestaXProyecto();

            List<Entidad> listaPropuestas = comandoLista.Ejecutar();

            foreach (Entidad entidad in listaPropuestas)
            {
                DominioTangerine.Entidades.M6.Propuesta propuesta = (DominioTangerine.Entidades.M6.Propuesta) entidad;
                _vista.inputPropuesta.Items.Add(propuesta.Nombre);
            }
        }

        public void cargarCodigoProyecto()
        {
            //Comando<Entidad> comandoLista = FabricaComandos.ObtenerComandoGenerarCodigoProyecto();
        }

        public void CargarPagina()
        {
            cargarPropuestas();
            cargarCodigoProyecto();
        }


    }


}
