using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangerine_Contratos.M6;
using LogicaTangerine;
using DominioTangerine;
using System.Web;

namespace Tangerine_Presentador.M6
{
    public class PresentadorConsultarPropuesta
    {
        IContratoConsultarPropuesta vistaConsultar;

        public PresentadorConsultarPropuesta(IContratoConsultarPropuesta vista)
        {
            this.vistaConsultar = vista;
        }


        public string propuesta
        {
            get
            {
                return this.vistaConsultar.Tabla.Text;
            }

            set
            {
                this.vistaConsultar.Tabla.Text = value;
            }
        }


        public void consultarPropuestas()
        {
            Comando <List<Entidad>> cmdConsultarPropuestas = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarTodosPropuesta();
            
            Comando<Entidad> cmdConsultarCompania;

            List<Entidad> listaPropuestas = cmdConsultarPropuestas.Ejecutar();

            try
            {
                foreach (Entidad _laPropuesta in listaPropuestas)
                {
                    //Creo un objeto de tipo Propuesta para poder obtener el fk de id de compania.
                    DominioTangerine.Entidades.M6.Propuesta laPropuesta = (DominioTangerine.Entidades.M6.Propuesta)_laPropuesta;
                    
                    //Creo objeto tipo Entidad(Compania) para luego pasarlo al comando de consulta y obtener los datos en BD.
                    //Inicializo el objeto solo con el Id (los demas campos en NULL).
                    Entidad _laCompania = DominioTangerine.Fabrica.FabricaEntidades.crearCompaniaConId(
                        Int32.Parse(laPropuesta.IdCompañia), null, null, null, null, null, DateTime.Today, 0, 0, 0, 0);

                    cmdConsultarCompania = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompania(_laCompania);
                    
                    //Guardo en un objeto de tipo Entidad los datos de la compania, finalmente la casteo a tipo Compania.
                    _laCompania = cmdConsultarCompania.Ejecutar();

                    DominioTangerine.Entidades.M4.CompaniaM4 laCompania = (DominioTangerine.Entidades.M4.CompaniaM4)_laCompania; 

                    propuesta += RecursosPresentadorPropuesta.AbrirTR;
                    propuesta += RecursosPresentadorPropuesta.AbrirTD + laPropuesta.Nombre.ToString() 
                    + RecursosPresentadorPropuesta.CerrarTD;
                    propuesta += RecursosPresentadorPropuesta.AbrirTD + laCompania.NombreCompania.ToString() + 
                        RecursosPresentadorPropuesta.CerrarTD;
                    propuesta += RecursosPresentadorPropuesta.AbrirTD + laPropuesta.Feincio.ToShortDateString() +
                        RecursosPresentadorPropuesta.CerrarTD;

                    imprimirStatus(laPropuesta);

                    imprimirMoneda(laPropuesta);

                    imprimirBotones(laPropuesta);
                } 
            } 
            catch (Exception ex)
            {

            } 
        }


        public void imprimirBotones(DominioTangerine.Entidades.M6.Propuesta laPropuesta)
        {
            propuesta += RecursosPresentadorPropuesta.AbrirTD2
                        + RecursosPresentadorPropuesta.botonConsultar + laPropuesta.Nombre.ToString() +
                        RecursosPresentadorPropuesta.botonCerra
                        + RecursosPresentadorPropuesta.botonModificar + laPropuesta.Nombre.ToString() + 
                        RecursosPresentadorPropuesta.botonCerra;
            propuesta += RecursosPresentadorPropuesta.CerrarTD;
            propuesta += RecursosPresentadorPropuesta.CerrarTR;
        }


        public void imprimirStatus(DominioTangerine.Entidades.M6.Propuesta laPropuesta)
        {
            if (laPropuesta.Estatus.Equals("Aprobado"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.aprobado +
                    RecursosPresentadorPropuesta.CerrarTD;
            }

            if (laPropuesta.Estatus.Equals("Pendiente"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.pendiente +
                    RecursosPresentadorPropuesta.CerrarTD;
            }

            if (laPropuesta.Estatus.Equals("Cerrado"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.cerrado +
                    RecursosPresentadorPropuesta.CerrarTD;
            }
        }


        public void imprimirMoneda(DominioTangerine.Entidades.M6.Propuesta laPropuesta)
        {
            if (laPropuesta.Moneda.Equals("Bolivar"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.bolivar + 
                    RecursosPresentadorPropuesta.CerrarTD;
            }

            if (laPropuesta.Moneda.Equals("Dolar"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.dolar +
                    RecursosPresentadorPropuesta.CerrarTD;
            }

            if (laPropuesta.Moneda.Equals("Euro"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.euro + 
                    RecursosPresentadorPropuesta.CerrarTD;
            }

            if (laPropuesta.Moneda.Equals("Bitcoin"))
            {
                propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.bitcoin +
                    RecursosPresentadorPropuesta.CerrarTD;
            }

            propuesta += RecursosPresentadorPropuesta.AbrirTD + laPropuesta.Costo + RecursosPresentadorPropuesta.CerrarTD;
        }
    }
}
