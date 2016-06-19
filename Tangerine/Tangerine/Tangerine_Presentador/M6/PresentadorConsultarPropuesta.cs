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
            /*
             * Aqui va el uso del recurso para imprimir la tabla 
             * (guiarse del que hicimos en ../GUI/M4/ConsultarCompania)
             * Ver recurso ya hecho por el M6 para la entrega anterior
             */
            Comando <List<Entidad>> cmdConsultarPropuestas = LogicaTangerine.Fabrica.FabricaComandos.ComandoConsultarTodosPropuesta();
            
            Comando<Entidad> cmdConsultarCompania;

            List<Entidad> listaPropuestas = cmdConsultarPropuestas.Ejecutar();

            try
            {
                foreach (Entidad _laPropuesta in listaPropuestas)
                {
                    cmdConsultarCompania = LogicaTangerine.Fabrica.FabricaComandos.CrearConsultarCompania(_laPropuesta);
                    
                    Entidad _laCompania = cmdConsultarCompania.Ejecutar();

                    DominioTangerine.Entidades.M6.Propuesta laPropuesta = (DominioTangerine.Entidades.M6.Propuesta)_laPropuesta;
                    DominioTangerine.Entidades.M4.CompaniaM4 laCompania = (DominioTangerine.Entidades.M4.CompaniaM4)_laCompania; 

                    propuesta += RecursosPresentadorPropuesta.AbrirTR;
                    propuesta += RecursosPresentadorPropuesta.AbrirTD + laPropuesta.Nombre.ToString() + RecursosPresentadorPropuesta.CerrarTD;
                    propuesta += RecursosPresentadorPropuesta.AbrirTD + laCompania.NombreCompania.ToString() + RecursosPresentadorPropuesta.CerrarTD;
                    propuesta += RecursosPresentadorPropuesta.AbrirTD + laPropuesta.Feincio.ToShortDateString() + RecursosPresentadorPropuesta.CerrarTD;
                        
                    if (laPropuesta.Estatus.Equals("Aprobado"))
                    {
                        propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.aprobado + RecursosPresentadorPropuesta.CerrarTD;   
                    }
                    
                    if (laPropuesta.Estatus.Equals("Pendiente"))
                    {
                        propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.pendiente + RecursosPresentadorPropuesta.CerrarTD;   
                    }
                    
                    if (laPropuesta.Estatus.Equals("Cerrado"))
                    {
                        propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.cerrado + RecursosPresentadorPropuesta.CerrarTD;   
                    }

                    if (laPropuesta.Moneda.Equals("Bolivar"))
                    {
                        propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.bolivar + RecursosPresentadorPropuesta.CerrarTD;   
                    }
                    
                    if (laPropuesta.Moneda.Equals("Dolar"))
                    {
                        propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.dolar + RecursosPresentadorPropuesta.CerrarTD;   
                    }
                    
                    if (laPropuesta.Moneda.Equals("Euro"))
                    {
                        propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.euro + RecursosPresentadorPropuesta.CerrarTD;   
                    }
                    
                    if (laPropuesta.Moneda.Equals("Bitcoin"))
                    {
                        propuesta += RecursosPresentadorPropuesta.AbrirTD + RecursosPresentadorPropuesta.bitcoin + RecursosPresentadorPropuesta.CerrarTD;   
                    }

                    propuesta += RecursosPresentadorPropuesta.AbrirTD + laPropuesta.Costo + RecursosPresentadorPropuesta.CerrarTD;

                    
                    //Acciones de cada propuesta
                    propuesta += RecursosPresentadorPropuesta.AbrirTD2
                        + RecursosPresentadorPropuesta.botonConsultar + laPropuesta.Nombre.ToString() + RecursosPresentadorPropuesta.botonCerra
                        + RecursosPresentadorPropuesta.botonModificar + laPropuesta.Nombre.ToString() + RecursosPresentadorPropuesta.botonCerra;
                    propuesta += RecursosPresentadorPropuesta.CerrarTD;
                    propuesta += RecursosPresentadorPropuesta.CerrarTR;
                    
                }
                
            } 
            catch (Exception ex)
            {

            } 
        }


        public void imprimirBotones()
        {
            /*
             * Same here... En M4 se pico la impresion de la tabla en DATOS y BOTONEs (acciones).
             */
        }


        public void imprimirStatus()
        {
            /*
             * Same here... pero con los diferentes status (meter todos esos IF aqui)
             */
        }


        public void imprimirMoneda()
        {
            /*
             * Same here... pero con los tipos de moneda.
             */
        }
    }
}
